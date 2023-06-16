using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NAGP.DevOps.Data.Migrations
{
    public partial class add_seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DateOfJoining = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.Sql($"Insert into Employees(Name,Age,DateOfJoining)" +
                                 $"Values('ABC1', 21, getdate())," +
                                 $"('ABC2', 21, getdate())," +
                                 $"('ABC3', 21, getdate())," +
                                 $"('ABC4', 21, getdate())," +
                                 $"('ABC5', 21, getdate());");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
