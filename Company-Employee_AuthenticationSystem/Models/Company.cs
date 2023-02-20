using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_Employee_AuthenticationSystem.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string Company_Name { get; set; }
        public string Company_Address { get; set; }
        public string Company_GST { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<Employee> Company_Employees { get; set; }

    }
}
