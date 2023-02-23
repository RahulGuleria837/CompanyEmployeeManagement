using Company_Employee_AuthenticationSystem.Models;

namespace Company_Employee_AuthenticationSystem.Repository.IRepository
{
    public interface IDesignationRepository:IRepository<Designation>
    {
        void Update(Designation designation);
    }
}
