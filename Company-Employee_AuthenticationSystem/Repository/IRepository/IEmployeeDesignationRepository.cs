using Company_Employee_AuthenticationSystem.Models;

namespace Company_Employee_AuthenticationSystem.Repository.IRepository
{
    public interface IEmployeeDesignationRepository:IRepository<EmployeeDesignation>
    {
        void Update(EmployeeDesignation employeeDesignation);
    }
}
