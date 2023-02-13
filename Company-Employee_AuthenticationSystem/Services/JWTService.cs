using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Company_Employee_AuthenticationSystem.Services.IServiceContract
{
    public class JWTService : IJWTService
    {
        private readonly AppSettings _appSettings;

        public JWTService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        #region Here we write the function to generate the jwt token.
        public ApplicationUser GenerateJWTToken(ApplicationUser user, bool generateRefreshToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var tokenDescritor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.Name, user.Id.ToString()),
                        // if user.role is null then the role will be consider as "Employee"
                        new Claim(ClaimTypes.Role, user.Role??"Employee")
                }),
                Expires = DateTime.UtcNow.AddMinutes(_appSettings.TokenValidation),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key)
, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescritor);
            user.Token = tokenHandler.WriteToken(token);
            if (generateRefreshToken)
            {
                user.RefreshToken = GenerateRefreshToken();
            }
            return user;
        }
        #endregion
        #region function that generate the refresh token
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rNG = RandomNumberGenerator.Create())
            {
                rNG.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }

        }
        public ApplicationUser GetToken(ApplicationUser user, bool refreshToken)
        {
            return GenerateJWTToken(user, refreshToken);
        }



        public ClaimsPrincipal? ExpiredTokenClaim(string token)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);

            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key)
,
                ClockSkew = TimeSpan.Zero
            };
            try
            {
                // here we get the claims from expired token.
                var claimUserValue = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);

                /* here we check token is not expire then we return null and not return the claims from token. and if expire then return
               the claims from expired token*/
                if (validatedToken.ValidTo > DateTime.UtcNow)
                    return null;
                return claimUserValue;

            }
            catch
            {
                return null;
            }
        }
        #endregion
    }


 
    

    }
        
    

