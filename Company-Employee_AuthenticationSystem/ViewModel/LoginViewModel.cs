using System.ComponentModel.DataAnnotations;

namespace Company_Employee_AuthenticationSystem.LoginViewModel
{
    public class LoginViewModel
    {
        [Required]
        public  string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
