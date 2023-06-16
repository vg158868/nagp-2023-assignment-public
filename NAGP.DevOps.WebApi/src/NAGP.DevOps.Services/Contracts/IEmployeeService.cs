using NAGP.DevOps.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAGP.DevOps.Services.Contracts
{
    public interface IEmployeeService
    {
        Task<List<EmployeesDto>> GetAllEmployeesAsync();
    }
}
