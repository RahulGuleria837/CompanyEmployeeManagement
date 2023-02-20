using Company_Employee_AuthenticationSystem.Models;
using Company_Employee_AuthenticationSystem.Repository.IRepository;

namespace Company_Employee_AuthenticationSystem.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _context;
        public CompanyRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
        public void Update(Company company)
        {
            _context.Update(company);
            _context.SaveChanges();
        }
    }
}
