using Company_Employee_AuthenticationSystem.Models;
using Company_Employee_AuthenticationSystem.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company_Employee_AuthenticationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;

        public LeaveController(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpGet]
        [Route("LeaveStatus")]
        public IActionResult LeaveStatus(int employeeID )
        {
            var employeeleave = _unitOfWork.LeaveRepository.Get(employeeID);

            if (employeeleave == null)  return NotFound (new{Message="leave Status not found" }) ;

            return Ok(employeeleave);
        }

        [HttpPost]
        public IActionResult SubmitLeaveRequest([FromBody] Leave leave)
        {
            leave.Status =2.ToString() ; //set status to pending by default
            _unitOfWork.LeaveRepository.Add(leave);
            return CreatedAtAction(nameof(LeaveStatus), new { leaveid = leave.LeaveId }, leave);



        }
    }
}
