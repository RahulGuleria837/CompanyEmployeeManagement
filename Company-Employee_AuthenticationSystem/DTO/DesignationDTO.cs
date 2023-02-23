using System.ComponentModel.DataAnnotations;

namespace Company_Employee_AuthenticationSystem.DTO
{
    public class DesignationDTO
    {
        [Key]
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
    }
}
