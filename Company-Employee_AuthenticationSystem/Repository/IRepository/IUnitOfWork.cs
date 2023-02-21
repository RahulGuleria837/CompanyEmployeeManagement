namespace Company_Employee_AuthenticationSystem.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICompanyRepository CompanyRepository { get; }

        IEmployeeRepository EmployeeRepository { get; }
    }
}
