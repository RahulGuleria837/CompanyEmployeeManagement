using System.Security.Claims;

namespace Company_Employee_AuthenticationSystem.Services.IServiceContract
{
    public interface IJWTService
    {
        ApplicationUser GetToken(ApplicationUser? user, bool refreshToken);

        ClaimsPrincipal? ExpiredTokenClaim(string token);
    }
}
