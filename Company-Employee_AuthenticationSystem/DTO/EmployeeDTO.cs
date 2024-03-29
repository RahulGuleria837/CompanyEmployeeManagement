﻿using System.ComponentModel.DataAnnotations;

namespace Company_Employee_AuthenticationSystem.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeeAddress { get; set; }
        [Required]
        public string Employee_Pancard_Number { get; set; }
        public string EmployeeAccount_Number { get; set; }
        public string EmployeePF_Number { get; set; }
        public int CompanyId { get; set; }

        [Required]
        public string? UserName { get; set; }

        [EmailAddress]
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
