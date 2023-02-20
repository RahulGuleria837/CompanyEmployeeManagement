using System.ComponentModel.DataAnnotations;

namespace Company_Employee_AuthenticationSystem.Models
{
    public class Leave
    {
        [Key]
        public int LeaveId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
       public LeaveStatus LeaveStatus { get; set; }
        public DateTime LeaveTaken { get; set; }

        public string Status { get; set; }

    }
}
