using Company_Employee_AuthenticationSystem.Models;
using Company_Employee_AuthenticationSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Company_Employee_AuthenticationSystem.Repository
{
    public class DesignationRepository : Repository<Designation>,IDesignationRepository
    {
        private readonly ApplicationDbContext _context;
        public DesignationRepository(ApplicationDbContext context):base(context) 
        {
                _context= context;
        }
        public void Update(Designation designation)
        {
            _context.Update(designation);
             _context.SaveChanges();
        }
    }
}
