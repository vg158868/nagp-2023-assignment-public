using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;
using NAGP.DevOps.Data;
using NAGP.DevOps.Services;
using NAGP.DevOps.Services.Contracts;
using System;
using System.IO;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("hosting.json", true)
                      .AddJsonFile("appsettings.json", true, true)
                       .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true)
                     .AddEnvironmentVariables()
                     .Build();

// Add services to the container.
builder.WebHost.ConfigureKestrel(options =>
{
    options.Listen(IPAddress.Any, 5001);
    options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(20);
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
    builder.AddDebug();
});
ILogger logger = loggerFactory.CreateLogger<Program>();

string connectionString = config.GetValue<string>("Settings:DevOpsDbConnectionString");
string dbPassword = config.GetValue<string>("Settings:Secrets:DbPassword");
connectionString = $"{connectionString.Trim()}Password={dbPassword.Trim()}";
logger.LogInformation(connectionString.Trim());
builder.Services.AddDbContext<DevOpsDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DevOpsDbContext>();
    //dbContext.Database.EnsureDeleted();

    // Update database based on migrations
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
