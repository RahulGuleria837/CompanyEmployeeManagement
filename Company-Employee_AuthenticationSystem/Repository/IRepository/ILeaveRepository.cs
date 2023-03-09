using Company_Employee_AuthenticationSystem.Models;

namespace Company_Employee_AuthenticationSystem.Repository.IRepository
{
    public interface ILeaveRepository:IRepository<Leave>
    {
        void update(Leave leave);
    }
}
