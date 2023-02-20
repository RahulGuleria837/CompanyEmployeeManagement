using System.ComponentModel.DataAnnotations;

namespace Company_Employee_AuthenticationSystem.Models
{
    public class EmployeeDesignation
    {
        [Key]
        public int EmployeeDesignationId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
