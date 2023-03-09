using Company_Employee_AuthenticationSystem.Models;
using Company_Employee_AuthenticationSystem.Repository.IRepository;

namespace Company_Employee_AuthenticationSystem.Repository
{
    public class LeaveRepository : Repository<Leave>, ILeaveRepository
    {
        private readonly ApplicationDbContext _context;

        public LeaveRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void update(Leave leave)
        {
            throw new NotImplementedException();
        }
    }
}
