using AutoMapper;
using Company_Employee_AuthenticationSystem.DTO;
using Company_Employee_AuthenticationSystem.Models;
using Company_Employee_AuthenticationSystem.Repository;
using Company_Employee_AuthenticationSystem.Repository.IRepository;
using Company_Employee_AuthenticationSystem.Services.IServiceContract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company_Employee_AuthenticationSystem.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
     
        private IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _applicationDbContext;
   

        public EmployeeController( IMapper mapper, IUnitOfWork unitOfWork,RoleManager<IdentityRole> roleManager,IUserService userService,ApplicationDbContext context)
        {
           
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _userService = userService;
            _applicationDbContext = context;

        }

        [HttpGet]
        public  IActionResult  GetEmployee()
        {
            var listOfEmployee = _unitOfWork.EmployeeRepository.GetAll();
            if(listOfEmployee == null ) return NotFound(new {message="Employee not Found"});
            return Ok(listOfEmployee);
        }
        /*
                [HttpPost]
                public IActionResult SaveEmployees([FromBody]EmployeeDTO employeeDTO)
                {

                    if (!(employeeDTO != null) && ModelState.IsValid)
                    {
                        return Ok(new { message = "There is An Error" });
                        //return BadRequest(ModelState);
                    }

                    var employeeData = _mapper.Map<Employee>(employeeDTO);

                    _unitOfWork.EmployeeRepository.Add(employeeData);

                    return Ok(new {Message="New Employee Added"});
                }*/


        //this method will add Employees and from here we can know that which employee belongs to which company
        //here i have add a check that if user is entering a random company id so first it will find in the database
        //that the companyId entered by user is exist or not

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeDTO employeeDTO)
        {
            if (!(employeeDTO != null) && (ModelState.IsValid))
            {
                return BadRequest(ModelState);
            }

            //**

            // Check if a "Company" employee already exists for the company
            var companyEmployees = _applicationDbContext.Employees.Where(e => e.CompanyId == employeeDTO.CompanyId).ToList();
            if (companyEmployees != null && companyEmployees.Any())
            {
                var existingCompanyEmployee = companyEmployees.Where(e => e.Role == StandardDictionary.Role_Company).ToList();
                if (existingCompanyEmployee.Count == 1 && employeeDTO.Role == StandardDictionary.Role_Company)
                {
                    return BadRequest(new { message = "A 'Company' employee already exists for the company." });
                }
            }

            //**
            var employee = _mapper.Map<Employee>(employeeDTO);

            var userExists = await _userService.IsUnique(employeeDTO.Username);
            if (userExists == null) return BadRequest(userExists);
            var user = new ApplicationUser
            {
                UserName = employeeDTO.Username,
                Email = employeeDTO.Email,
                PasswordHash = employeeDTO.Password,
                Role = employeeDTO.Role,
            };




            var result = await _userService.RegisterUser(user);
            employee.ApplicationUserId = user.Id;
            _unitOfWork.EmployeeRepository.Add(employee);
            if (!result) return StatusCode(StatusCodes.Status500InternalServerError);

            //Here i am checking if any Company User exist

            //Here i am saving ApplicationUserId of CompanyUser in Company Table

            if (employeeDTO.Role == StandardDictionary.Role_Company)
            {
                var companyId = employeeDTO.CompanyId;
                var companyInDb = _applicationDbContext.Companies.Find(companyId);
                if (companyInDb == null) return NotFound(new { message = "company Not exist" });
                companyInDb.ApplicationUserId = employee.ApplicationUserId;
                _applicationDbContext.SaveChanges();
            }
            return Ok(new { Message = "Register successfully!!!" });
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

        [HttpDelete("{id:int}")]
        public   IActionResult DeleteEmployees([FromBody] int employeeid)
        {
            if (employeeid == null) return NotFound();
            _unitOfWork.EmployeeRepository.Remove(employeeid);
            return Ok(new {Message="Employee has been deleted"});
        }
    }
}
