using Company_Employee_AuthenticationSystem.Models;
using Company_Employee_AuthenticationSystem.Repository.IRepository;

namespace Company_Employee_AuthenticationSystem.Repository
{
    public class EmployeeDesignationRepository : Repository<EmployeeDesignation>, IEmployeeDesignationRepository

    {
        private readonly ApplicationDbContext _context;
       
        public EmployeeDesignationRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }

        public void Update(EmployeeDesignation employeeDesignation)
        {
            _context.Update(employeeDesignation);
            _context.SaveChanges();
        }
    }
}
