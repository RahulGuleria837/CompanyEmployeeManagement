using AutoMapper;
using AutoMapper.Internal;
using Company_Employee_AuthenticationSystem.DTO;
using Company_Employee_AuthenticationSystem.Services.IServiceContract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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
        private readonly IMapper _mapper;

        public UserAuthentication(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUserService userService, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
            _mapper = mapper;
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
            return Ok(new { AccessToken = authenticataeUser.Token, authenticataeUser.RefreshToken });
        }

            [Route("Register")]
            [HttpPost]
            

            public async Task<IActionResult> Register([FromBody]RegisterDTO registerDetail)
            {
                var applicationuserDetail = _mapper.Map<ApplicationUser>(registerDetail);
                applicationuserDetail.PasswordHash = registerDetail.Password;
                if(applicationuserDetail == null || !ModelState.IsValid) return BadRequest();
                if(! await _userService.IsUnique(registerDetail.UserName))
                return Ok(new { Message = "Already Register Go to Login" });
                var registerUser = await _userService.RegisterUser(applicationuserDetail);
            if (!registerUser) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(new { Message = "Register successfully!!!" });
               


            }
        }
    }
}


