using AutoMapper;
using Company_Employee_AuthenticationSystem.DTO;
using Company_Employee_AuthenticationSystem.Models;
using Company_Employee_AuthenticationSystem.Repository;
using Company_Employee_AuthenticationSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Company_Employee_AuthenticationSystem.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
     
        private IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController( IMapper mapper, IUnitOfWork unitOfWork)
        {
           
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public  IActionResult  GetEmployee()
        {
            var listOfEmployee = _unitOfWork.EmployeeRepository.GetAll();
            if(listOfEmployee == null ) return NotFound(new {message="Employee not Found"});
            return Ok(listOfEmployee);
        }

        [HttpPost]
        public IActionResult SaveEmployees([FromBody]EmployeeDTO employeeDTO)
        {

            if (!(employeeDTO != null) && ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeData = _mapper.Map<Employee>(employeeDTO);

            _unitOfWork.EmployeeRepository.Add(employeeData);

            return Ok(new {Message="New Employee Added"});

            
        }

        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            if ((employeeDTO == null) && ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updateEmployee = _mapper.Map<Employee>(employeeDTO);

            _unitOfWork.EmployeeRepository.Update(updateEmployee);
            return Ok(new {Message="Your Employee has been Updated"});
        }

        [HttpDelete]
        public   IActionResult DeleteEmployees([FromBody] int employeeid)
        {
            if (employeeid == null) return NotFound();
            _unitOfWork.EmployeeRepository.Remove(employeeid);
            return Ok(new {Message="Employee has been deleted"});
        }
    }
}
