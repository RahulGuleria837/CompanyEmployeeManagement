using Company_Employee_AuthenticationSystem.Services.IServiceContract;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Company_Employee_AuthenticationSystem.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppSettings _appSettings;


        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }
        #region Function to add Refresh Token
        public async Task<ApplicationUser> AddRefreshToken(ApplicationUser applicationUser)
        {
            var addUser = await _userManager.UpdateAsync(applicationUser);
            if (addUser.Succeeded) return applicationUser;
            return null;

        }
        #endregion

        #region In this Function we authenicate the UserName and password and Generate JWT Token
        public async Task<ApplicationUser> AuthenicateUser(string userName, string password)
        {     // check User Name and Role and Password
            var checkUser = await _userManager.FindByNameAsync(userName);
            var checkUserRole = await _userManager.GetRolesAsync(checkUser);
            checkUser.Role = checkUserRole.FirstOrDefault();
            var userVerification = await _signInManager.CheckPasswordSignInAsync(checkUser, password,false);
           

           //jWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var tokenDescritor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, checkUser.Id.ToString()),
                    new Claim(ClaimTypes.Role, checkUser.Role?? "Employee")
                }),
                Expires = DateTime.UtcNow.AddSeconds(90),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var accessToken = tokenHandler.CreateToken(tokenDescritor);
            var refreshToekn = tokenHandler.CreateToken(tokenDescritor);
            checkUser.Token = tokenHandler.WriteToken(refreshToekn);

            if (checkUser.RefreshTokenExpiry > DateTime.Now) return checkUser;

            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                var c = Convert.ToBase64String(randomNumber);
                checkUser.RefreshToken = c;

            }
            //refresh token Expiry
            checkUser.RefreshTokenExpiry = DateTime.Now.AddDays(5);

            //saving refresh token in DB
            await _userManager.UpdateAsync(checkUser);

            checkUser.PasswordHash = "";
            if (!userVerification.Succeeded) return null;
            return checkUser;

        }
        #endregion
        public async Task<ApplicationUser> GetRefreshToken(ApplicationUser applicationUser)
        {
            var userToken = await _userManager.FindByNameAsync(applicationUser.UserName);
            if (userToken == null) return null;
            return userToken;
        }
        #region To check wether User is Unique or not
        public async Task<bool> IsUnique(string userName)
        {
           var checkInDb= await _userManager.FindByNameAsync(userName);
            if(checkInDb == null) return true;
            return false;
        }
        #endregion

        #region To register new user and assigning them roles
        public async Task<bool> RegisterUser(ApplicationUser userCredentials)
        {
            var user =await _userManager.CreateAsync(userCredentials, userCredentials.PasswordHash);
            if (!user.Succeeded) return false;
            await _userManager.AddToRoleAsync(userCredentials ,userCredentials.Role);
            return true;    
            
        }
        #endregion

        #region To Update Refresh Token
        public async Task<bool> UpdateRefreshToken(ApplicationUser applicationUser)
        {
            var user = await AddRefreshToken(applicationUser);
            if (user == null) return false;
            return true;
        }

        public async Task<ApplicationUser?> CheckUserInDb(string userName)
        {
            var UserInDb = await _userManager.FindByIdAsync(userName);
            if (UserInDb == null) return null;
            var userGetRole = await _userManager.GetRolesAsync(UserInDb);
            UserInDb.Role = userGetRole?.FirstOrDefault();
            return UserInDb;
        }
        #endregion
    }
}
