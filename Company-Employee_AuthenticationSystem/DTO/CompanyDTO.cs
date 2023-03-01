using System.ComponentModel.DataAnnotations;

namespace Company_Employee_AuthenticationSystem.DTO
{
    public class CompanyDTO
    {
        [Key]
        public int CompanyId { get; set; }
        public string Company_Name { get; set; }
        public string Company_Address { get; set; }
        public string Company_GST { get; set; }
        public string? ApplicationUserId { get; set; }
    }
}
