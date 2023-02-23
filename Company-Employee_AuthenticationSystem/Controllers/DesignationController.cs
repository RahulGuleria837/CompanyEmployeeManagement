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
    public class DesignationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DesignationController(ApplicationDbContext context, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("NewDesignation")]
        public IActionResult NewDesignation(DesignationDTO designationDTO)
        {
            if (designationDTO == null) { return NotFound(); }

            var newDesignation = _mapper.Map<DesignationDTO, Designation>(designationDTO);

            _unitOfWork.DesignationRepository.Add(newDesignation);
            return Ok(new { Message = "new Designatin has been added" });

        }
        [HttpPost]
        [Route("NewEmployeeDesignation")]
        public IActionResult NewEmployeeDesignation([FromBody] EmployeeDesignationDTO employeeDesignationDTO)
        {
            if ((employeeDesignationDTO == null) && (!ModelState.IsValid))
            {
                return BadRequest(ModelState);
            }
            var employeeDesignation = _mapper.Map<EmployeeDesignationDTO, EmployeeDesignation>(employeeDesignationDTO);
            _unitOfWork.EmployeeDesignationRepository.Add(employeeDesignation);
            return Ok(new { message = "Employee Designation Addded Sucessfully" });



        }

        [HttpGet]
        [Route("GetDesignation")]

        public IActionResult GetAllDesignation()
        {
            var getdesignation = _unitOfWork.DesignationRepository.GetAll();
            if (getdesignation == null) { return Ok(new { Message = "Data NOt found" }); }
            return Ok(getdesignation);
        }

        [HttpGet]
        [Route("GetEmployeeDesignation")]
        public IActionResult GetEmployeeDesignation()
        {
            var employeeDesignation = _unitOfWork.EmployeeDesignationRepository.GetAll();
            if (employeeDesignation == null) { return Ok(new { Message = "Data NOt found" }); }
            return Ok(employeeDesignation);
        }
    }
}