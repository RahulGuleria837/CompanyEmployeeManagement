using AutoMapper;
using Company_Employee_AuthenticationSystem.DTO;
using Company_Employee_AuthenticationSystem.Models;
using Company_Employee_AuthenticationSystem.Repository;
using Company_Employee_AuthenticationSystem.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company_Employee_AuthenticationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public LeaveController(IUnitOfWork unitOfWork, ApplicationDbContext context, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _mapper = mapper;
        }
        //To get All the Applied leave
        [Route("LeaveStatus")]
        [HttpGet]
         public IActionResult LeaveStatus()
         {
            var employeeleave = _unitOfWork.LeaveRepository.GetAll();

             if (employeeleave == null) return NotFound(new { Message = "leave Status not found" });

             return Ok(employeeleave);
         }
 
      /*  [Route("GetLeave")]
        [HttpGet]
       
        public IActionResult LeaveStatus(int employeeID)
        {
            var getLeave = _context.Leaves.Where(e=>e.EmployeeId == employeeID).ToList();
            if(getLeave == null) return NotFound(new {Message="Employee not Applied for Leave"});
            return Ok( new {getLeave, Message="list generated Sucessfully"});
        }
*/






        [Route("GenerateLeave")]
        [HttpPost]
     
        public async Task<IActionResult> AddLeave([FromBody] LeaveDTO leaveDTO)
        {
            // Map the LeaveDTO object to a Leave object using AutoMapper.
            var leave = _mapper.Map<LeaveDTO, Leave>(leaveDTO);

            // Get the last leave for this employee from the database.
            var findlastleave = _unitOfWork.LeaveRepository.GetAll(u => u.EmployeeId == leaveDTO.EmployeeId).LastOrDefault();
            if (findlastleave == null)
            {
                // here it means it is his first leave creation
                _unitOfWork.LeaveRepository.Add(leave);
                return Ok(new { Message = "Leave Created Successfully" });
            }

            // If the last leave for this employee has not ended and has not been cancelled, return an error message.
            if (findlastleave.EndDate > DateTime.Now && findlastleave.Status != (Leave.LeaveStatus)3)            {
                // this means it will not create another leave 
                return Ok(new { Message = "You take already a leave that not complete please check your leave on leave status button" });
            }
            // if last leave pass then we will create another leave
            _unitOfWork.LeaveRepository.Add(leave);

            return Ok(new { Message = "Leave Created Successfully" });

        }
    }
    /*  [HttpPut]
      public IActionResult SubmitLeaveRequest([FromBody] LeaveDTO leave)
      {
          leave.Status = (Leave.LeaveStatus)2; //set status to pending by default
          _unitOfWork.LeaveRepository.Add(leave);
          return CreatedAtAction(nameof(LeaveStatus), new { leaveid = leave.LeaveId }, leave);

      }*/
}
