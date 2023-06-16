using Microsoft.EntityFrameworkCore;
using NAGP.DevOps.Data;
using NAGP.DevOps.Data.Entities;
using NAGP.DevOps.Dto;
using NAGP.DevOps.Services.Contracts;

namespace NAGP.DevOps.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DevOpsDbContext _devOpsDbContext;

        public EmployeeService(DevOpsDbContext devOpsDbContext)
        {
            _devOpsDbContext = devOpsDbContext;
        }
        public async Task<List<EmployeesDto>> GetAllEmployeesAsync()
        {
            var allEmployees = await _devOpsDbContext.Employees.AsQueryable().AsNoTracking().ToListAsync();

            return allEmployees.Select(x => new EmployeesDto()
            {
                EmployeeId = x.Id,
                Name = x.Name,
                Age = x.Age,
                JoiningDate = x.DateOfJoining
            }).ToList();
        }
    }
}