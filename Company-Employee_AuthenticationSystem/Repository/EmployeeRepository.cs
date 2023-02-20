using Company_Employee_AuthenticationSystem.Models;
using Company_Employee_AuthenticationSystem.Repository.IRepository;

namespace Company_Employee_AuthenticationSystem.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context):base(context)
        {
                _context= context;
        }
        public void Update(Employee employee)
        {
            _context.Update(employee);
            _context.SaveChanges();
        }
    }
}
