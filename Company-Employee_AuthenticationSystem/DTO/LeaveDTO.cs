

namespace Company_Employee_AuthenticationSystem.DTO
{
    public class LeaveDTO
    {
        public int LeaveId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public enum LeaveStatus
        {

            Pending = 1,
            Approved = 2,
            Rejected = 3

        }
        public LeaveStatus Status { get; set; }

    }
}
