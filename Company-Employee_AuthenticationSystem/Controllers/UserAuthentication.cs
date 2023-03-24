using AutoMapper;
using AutoMapper.Internal;
using Company_Employee_AuthenticationSystem.DTO;
using Company_Employee_AuthenticationSystem.Models;
using Company_Employee_AuthenticationSystem.Services.IServiceContract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Security.Claims;

namespace Company_Employee_AuthenticationSystem.LoginViewModel
{
    namespace Company_Employee_AuthenticationSystem.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class UserAuthentication : ControllerBase

        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly SignInManager<ApplicationUser> _signInManager;
            private readonly IUserService _userService;
            private readonly IJWTService _jwtservice;
            private readonly IMapper _mapper;

            public UserAuthentication(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUserService userService, IMapper mapper,IJWTService jwtService )
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _userService = userService;
                _mapper = mapper;
                _jwtservice = jwtService;
              
            }

            [HttpPost]
            [Route("Login")]
            public async Task<IActionResult> Login([FromBody] LoginViewModel login)
            {
                //we will check there if the User is Unique or alerady registerd
                if (await _userService.IsUnique(login.UserName))
                    return Ok(new { Message = "Register first then login" });

                var authenticataeUser = await _userService.AuthenicateUser(login.UserName, login.Password);
                if (authenticataeUser == null) { return Unauthorized(); }
                return Ok(new { AccessToken = authenticataeUser.Token, authenticataeUser.RefreshToken,Role=authenticataeUser.Role });
            }

            [Route("Register")]
            [HttpPost]


            public async Task<IActionResult> Register([FromBody] RegisterDTO registerDetail)
            {
                var applicationuserDetail = _mapper.Map<ApplicationUser>(registerDetail);
                applicationuserDetail.PasswordHash = registerDetail.Password;
                if (applicationuserDetail == null || !ModelState.IsValid) return BadRequest();
                if (!await _userService.IsUnique(registerDetail.UserName))
                    return Ok(new { Message = "Already Register Go to Login" });
                var registerUser = await _userService.RegisterUser(applicationuserDetail);
                if (!registerUser) return StatusCode(StatusCodes.Status500InternalServerError);
                return Ok(new { Message = "Register successfully!!!" });



            }


            [Route("RefreshToken")]
            [HttpPost]
            public async Task<IActionResult> RefreshToken(Tokens userToken)
            {
                Request.Headers.TryGetValue("IS-TOKEN-EXPIRED", out var headerValue);
                if (userToken == null || !ModelState.IsValid || headerValue.FirstOrDefault() == "")
                {
                    return BadRequest();
                }
                var claimUserDataFromToken = _jwtservice.ExpiredTokenClaim(userToken.AccessToken);
                if (claimUserDataFromToken == null)
                {
                    return Unauthorized(new { Message = "your token is valid sir use this token" });
                }
                var claimUserIdentity = (ClaimsIdentity)claimUserDataFromToken.Identity;
                var claimUser = claimUserIdentity.FindFirst(ClaimTypes.Name);
                if (claimUser == null)
                {
                    return Unauthorized();
                }


                var checkUserInDb = await _userManager.FindByIdAsync(claimUser.Value);
                if (checkUserInDb == null) return Unauthorized();
                var userGetRole = await _userManager.GetRolesAsync(checkUserInDb);
                checkUserInDb.Role = userGetRole.FirstOrDefault();
                if (checkUserInDb.RefreshToken != userToken.RefreshTokens)
                {
                    return Unauthorized(new { Message = "Go to login!!!!!!" });
                }
                var generateNewToken = _jwtservice.GetToken(checkUserInDb,false);
                if (!await _userService.UpdateRefreshToken(generateNewToken))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                Tokens usertoken = new Tokens()
                {
                    AccessToken = generateNewToken.Token,
                    RefreshTokens = generateNewToken.RefreshToken,
                };
                return Ok(usertoken);
            }

        }
    

    }
}


