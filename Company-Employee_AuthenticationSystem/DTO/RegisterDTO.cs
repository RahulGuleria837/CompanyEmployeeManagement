using System.ComponentModel.DataAnnotations;

namespace Company_Employee_AuthenticationSystem.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }   

        public string? Role { get; set; }
    }
}
