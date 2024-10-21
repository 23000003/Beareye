using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Account;
using backend.Interfaces;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        
        private readonly UserManager<AppUser> userManager;
        private readonly ITokeNService tokenService;
        private readonly SignInManager<AppUser> signinManager;

        public AccountController(UserManager<AppUser> userManager, ITokeNService tokenService, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.signinManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto register)
        {
            try {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);

                var appUser = new AppUser 
                {
                    UserName = register.Username,
                    Email = register.Email
                };

                var createdUser = await userManager.CreateAsync(appUser, register.Password);

                if(createdUser.Succeeded)
                {
                    var roleResult = await userManager.AddToRoleAsync(appUser, "User");
                    
                    if(roleResult.Succeeded)
                    {
                        return Ok(
                            new NewUserDto {
                                UserName = appUser.UserName,
                                Email = appUser.Email,
                                Token = tokenService.CreateToken(appUser)
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            } 
            catch (Exception e) 
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username);

                if(user == null) 
                    return Unauthorized("Invalid Username!");

                var result = await signinManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

                if(!result.Succeeded)
                    return Unauthorized("Username not found and/or password incorrect");
                
                return Ok(
                    new NewUserDto
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        Token = tokenService.CreateToken(user)
                    }
                );

            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }
        }

    }
}