using AutoMapper;
using Library.DAL.DTOs.User;
using Library.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
