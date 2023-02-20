using Company_Employee_AuthenticationSystem.Models;

namespace Company_Employee_AuthenticationSystem.Repository.IRepository
{
    public interface ICompanyRepository:IRepository<Company>
    {
        void Update(Company company);   
    }
}
