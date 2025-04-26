using API2.Data;
using API2.Dtos.Account;
using API2.Interface;
using API2.Models;
using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API2.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class AccountController:ControllerBase
    {
      
        private readonly UserManager<AppUser> _user;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> signIn;

        public AccountController(UserManager<AppUser> user,ITokenService token,SignInManager<AppUser> _signIn)
        {
            _user = user;
            _tokenService = token;
            signIn = _signIn;
        }
        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var appUser = new AppUser
                {
                    UserName = registerDto.UserName,
                    Email = registerDto.Email,
                };

                var createUser = await _user.CreateAsync(appUser, registerDto.Password);
                if (createUser.Succeeded)
                {
                    var roleResult = await _user.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok("user created succefully");
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createUser.Errors);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("/login")]
        public async Task<IActionResult> Login(loginDto login)
        {
            if(!ModelState.IsValid)
                { return BadRequest(ModelState); }
            var user = await _user.Users.FirstOrDefaultAsync(x=>x.UserName==login.UserName.ToLower());
            if (user == null) { return Unauthorized("Invalid Username"); }
            var result = await signIn.CheckPasswordSignInAsync(user,login.Password,false);
            if (!result.Succeeded)
            {
                return Unauthorized("Invalid Password");
            }
            return Ok(new NewUserDto
            {
                Token = _tokenService.createToken(user)
            });
        }
       
    }
}
