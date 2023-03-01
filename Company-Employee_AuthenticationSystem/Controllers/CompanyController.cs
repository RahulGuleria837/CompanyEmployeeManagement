using AutoMapper;
using Company_Employee_AuthenticationSystem.DTO;
using Company_Employee_AuthenticationSystem.Models;
using Company_Employee_AuthenticationSystem.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company_Employee_AuthenticationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class CompanyController : ControllerBase
    {
        private IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CompanyController(IMapper mapper, IUnitOfWork unitOfWork, ApplicationDbContext context,UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _context = context;
            _userManager = userManager;

        }
        [HttpGet]

        public IActionResult GetCompany()
        {
            var companyList = _unitOfWork.CompanyRepository.GetAll();
            if (companyList == null)
            { return NotFound(new { Message = "No data avilable" }); }
            return Ok(companyList);
        }
        [HttpPost]

        public IActionResult SaveCompany([FromBody] CompanyDTO companyDTO)
        {
            if (companyDTO == null && (!ModelState.IsValid)) return BadRequest();
            var companyData = _mapper.Map<Company>(companyDTO);
            _unitOfWork.CompanyRepository.Add(companyData);
            return Ok(new { Message = "New Employee Added to Table" });
        }
        [HttpPut]

        public IActionResult UpdateCompany([FromBody] CompanyDTO companyDTO)
        {
            if (companyDTO == null) return BadRequest();
            var updateCompany = _mapper.Map<Company>(companyDTO);
            _unitOfWork.CompanyRepository.Update(updateCompany);
            return Ok(new { Message = "Employee Details Updated" });

        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteCompany(int id)
        {
            _unitOfWork.CompanyRepository.Remove(id);
            return Ok(new { Message = "Employee has been Deleted" });

        }

        [HttpGet]
        [Route("EmployeesInTheCompany")]
        public IActionResult EmployeesInTheCompany(int companyId)
        {
            var employeeInDb = _context.Employees.Where(e => e.CompanyId == companyId).ToList();
            if (employeeInDb == null) return NotFound(new { message = "No employee registered in the company" });
            return Ok(new { employeeInDb, message = "Employee List Sucessfully" });
        }
    }
}
