namespace Company_Employee_AuthenticationSystem.Services.IServiceContract
{
    public interface IUserService
    {
        Task<bool> IsUnique(string userName);

        Task<ApplicationUser> AuthenicateUser(string userName, string password);

        Task<bool> RegisterUser(ApplicationUser userCredentials);

        Task<ApplicationUser> AddRefreshToken(ApplicationUser applicationUser);

        Task<ApplicationUser> GetRefreshToken(ApplicationUser applicationUser);

        Task<bool> UpdateRefreshToken(ApplicationUser applicationUser);

        Task<ApplicationUser?> CheckUserInDb(string userName);
    }
}