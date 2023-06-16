using Microsoft.AspNetCore.Mvc;
using NAGP.DevOps.Data;
using NAGP.DevOps.Services.Contracts;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("/employees")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }
    }
}
