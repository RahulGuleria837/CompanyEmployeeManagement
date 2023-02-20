using Company_Employee_AuthenticationSystem.Models;

namespace Company_Employee_AuthenticationSystem.Repository.IRepository
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        void Update(Employee employee);
    }
}
