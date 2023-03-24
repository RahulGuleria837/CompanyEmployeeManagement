using AutoMapper;
using Company_Employee_AuthenticationSystem.DTO;
using Company_Employee_AuthenticationSystem.Models;
using Company_Employee_AuthenticationSystem.Repository;
using Company_Employee_AuthenticationSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

     
        [HttpGet]
        [Route("GetDesignation")]

        public IActionResult GetAllDesignation()
        { //To See all Created Designation
            var getdesignation = _unitOfWork.DesignationRepository.GetAll();
            if (getdesignation == null) { return Ok(new { Message = "Data NOt found" }); }
            return Ok(getdesignation);
        }

        [HttpGet]
        [Route("GetEmployeeDesignation")]
        public IActionResult GetEmployeeDesignation()
        {
            //To Check All the designation
            var employeeDesignation = _unitOfWork.EmployeeDesignationRepository.GetAll();
            if (employeeDesignation == null) { return Ok(new { Message = "Data NOt found" }); }
            return Ok(employeeDesignation);
        }


        [HttpPost]
        [Route("AddDesignation")]
        public IActionResult AddDesignation([FromBody] DesignationDTO designationDTO)
        {
            //    //Here we checking, DesignationDto has data or not and Also serverSide validation

            if (!(designationDTO != null) && (ModelState.IsValid))
            {     //If above condition is true, then it will return and show message
                return BadRequest(ModelState);
            }
            var designation = _mapper.Map<DesignationDTO, Designation>(designationDTO);
            //Here we stores designation name That is pass and stores it in variable
            var desig = designationDTO.DesignationName;

            //Here we find that the designation is exist in database or not
            var designationInDb = _context.Designations.FirstOrDefault(designation => designation.DesignationName == desig);

            //if it is already exist in database then it will show error
            if (designationInDb != null)
            {
                //If above condition is true then it will return
                return Ok(new { status = 2, message = "Designation already in database" });
            }


            _unitOfWork.DesignationRepository.Add(designation);
            return Ok(new { status = 1, messgae = "Designation created sucessfully" });
        }


        //To give the Designation To the employee and Assign employee their Designation
        [HttpPost]
        [Route("AddEmployeeDesignation")]
        public IActionResult AddEmployeeDesignation([FromBody] EmployeeDesignationDTO employeeDesignationDTO)
        {
            if ((employeeDesignationDTO == null) && (!ModelState.IsValid))
            {
                return BadRequest(ModelState);
            }
            var dsgIdInDb = _context.Designations.FirstOrDefault(dsg => dsg.DesignationName == employeeDesignationDTO.DesignationName);
            if (dsgIdInDb == null)
            {
                return Ok(new { status = 2, message = "Designation not Added or Spelling Mistake" });
            }
            employeeDesignationDTO.DesignationId = dsgIdInDb.DesignationId;
            var employeeDesignation = _mapper.Map<EmployeeDesignationDTO, EmployeeDesignation>(employeeDesignationDTO);
            _unitOfWork.EmployeeDesignationRepository.Add(employeeDesignation);
            return Ok(new { message = "Employee Designation Addded Sucessfully" });

        }

        //To assign designation to the employee
        /*[Route("GetAssignDesignation")]*/
        [HttpGet("{companyId:int}")]
        public IActionResult GetAssignDesgination(int companyId)
        {
            //there we have use where condition
            var employees = _context.Employees
               .Where(e => e.CompanyId == companyId) // Filter employees by company ID
               .Include(e => e.EmployeeDesignation).  // Eagerly load EmployeeDesignation relationship
               ThenInclude(ed => ed.Designation)     // Eagerly load Designation relationship
               .Where(e=>e.EmployeeDesignation!=null)// Filter out employees without designations
               .Select(e => new
               {
                   EmployeeId = e.EmployeeId,
                   EmployeeName = e.EmployeeName,
                   Designations = e.EmployeeDesignation.Designation
               })
               .ToList();

            if (employees.Count == 0)
            {
                return NotFound(new { message = "No employee registered in the company" });
            }

            return Ok(employees);
        }



        /*[HttpPost]
        [Route("NewDesignation")]
        public IActionResult NewDesignation(DesignationDTO designationDTO)
        {
            if (designationDTO == null) { return NotFound(); }

            var newDesignation = _mapper.Map<DesignationDTO, Designation>(designationDTO);

            _unitOfWork.DesignationRepository.Add(newDesignation);
            return Ok(new { Message = "new Designatin has been added" });*/
        /*
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



                }*/


    }
}