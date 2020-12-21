using AutoMapper;
using Library.DAL.DTOs.User;
using Library.DAL.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Library.WebAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IMapper _mapper;

        public AccountController(UserManager<UserEntity> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegistrationDto user)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            var userEntity = _mapper.Map<UserEntity>(user);

            var result = await _userManager.CreateAsync(userEntity, user.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return new BadRequestObjectResult(ModelState);
            }

            await _userManager.AddToRoleAsync(userEntity, "User");

            var userResult = _mapper.Map<UserDto>(userEntity);

            return CreatedAtRoute("UserById", new { controller = "users", id = userResult.Id }, userResult);
        }
    
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto user)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            var userResult = await _userManager.FindByEmailAsync(user.Email);

            if (userResult != null && await _userManager.CheckPasswordAsync(userResult, user.Password))
            {
                var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userResult.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, userResult.UserName));

                await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, new ClaimsPrincipal(identity));

                return Ok(identity);
            }
            else
            {
                ModelState.AddModelError("", "Invalid Username or Password");
                return new BadRequestObjectResult(ModelState);
            }
        }
    }
}
