﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_Employee_AuthenticationSystem.Models
{
    public class EmployeeDesignation
    {
        [Key]
        public int EmployeeDesignationId { get; set; }
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public int? DesignationId { get; set; }
        [ForeignKey("DesignationId")]
        public Designation? Designation { get; set; }

        internal bool Any()
        {
            throw new NotImplementedException();
        }
    }
}
