using System.ComponentModel.DataAnnotations;

namespace Company_Employee_AuthenticationSystem.Models
{
    public class Designation
    {
        [Key]
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
