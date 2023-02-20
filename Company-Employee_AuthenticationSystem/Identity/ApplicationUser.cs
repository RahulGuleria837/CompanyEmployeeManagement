using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Company_Employee_AuthenticationSystem
{
  public class ApplicationUser : IdentityUser
  {
        [NotMapped]
        public string Token { get; set; }

    public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiry { get; set; }
    [NotMapped]
    public string? Role { get; set; }



  }
}
