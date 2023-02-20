using Company_Employee_AuthenticationSystem;
using Company_Employee_AuthenticationSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company_Employee_AuthenticationSystem
{
  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<EmployeeDesignation> EmployeeDesignations { get; set; }
       


        protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }
  }
}
