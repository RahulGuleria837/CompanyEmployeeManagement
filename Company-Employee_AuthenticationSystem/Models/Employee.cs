using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_Employee_AuthenticationSystem.Models
{
    public class Employee
    {
     
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeeAddress { get; set; }
        [Required]
        public string Employee_Pancard_Number { get; set; }
        public string EmployeeAccount_Number { get; set; }
        public string EmployeePF_Number { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public List<Designation>? Employee_Designations { get; set; }
    }
}
