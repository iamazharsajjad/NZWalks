using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenReposity tokenReposity;

        public AuthController(UserManager<IdentityUser> userManager, ITokenReposity tokenReposity)
        {
            this.userManager = userManager;
            this.tokenReposity = tokenReposity;
        }

        //Post /api/Auth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto requestDto)
        {
            var idetityUser = new IdentityUser
            {
                UserName = requestDto.Username,
                Email = requestDto.Username
            };

            var identityResult = await userManager.CreateAsync(idetityUser, requestDto.Password);
            if (identityResult.Succeeded)
            {
                if (requestDto.Roles != null && requestDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(idetityUser, requestDto.Roles);
                }
                if (identityResult.Succeeded)
                {
                    return Ok("User Registered Successfully! Please Login");
                }
            }

            return BadRequest("Something went wrong");
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByNameAsync(loginRequestDto.Username);
            if (user != null)
            {
                var checkPasswordResult  = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);
                if (checkPasswordResult)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    if (roles != null)
                    {
                        var jwtToken  = tokenReposity.CreateJWTToken(user, roles.ToList());
                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken
                        };
                        return Ok(response);
                    }
                
                }
            }
            return BadRequest("Invalid Username ");
        }

    
    }
}
