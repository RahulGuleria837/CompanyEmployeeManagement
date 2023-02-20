using AutoMapper;
using Company_Employee_AuthenticationSystem.Models;
using Company_Employee_AuthenticationSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Company_Employee_AuthenticationSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(ApplicationDbContext context, IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _context = context;
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public  IActionResult  GetEmployee(Employee employee)
        {
            var getemployees = _employeeRepository.Get(employee);
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult SaveEmployees([FromBody]Employee employee)
        {
            _context.Employees.Add(employee);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        { 
            _context.Employees.Update(employee);
            return Ok();
        }

        [HttpDelete]
        public   IActionResult DeleteEmployees([FromBody] int id)
        {
            var employeeInDb = _context.Employees.Find(id);
            _context.Employees.Remove(employeeInDb);
            return Ok();
        }
    }
}
