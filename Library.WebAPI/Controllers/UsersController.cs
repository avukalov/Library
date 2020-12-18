using AutoMapper;
using Library.DAL.DTOs.User;
using Library.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Library.WebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
        private readonly UserManager<UserEntity> _userManager;
        private IMapper _mapper;

        public UsersController(UserManager<UserEntity> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "UserById")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return NotFound();
            }

            var userResult = _mapper.Map<UserDto>(user);

            return Ok(userResult);
        }

        [HttpGet("username/{userName}", Name = "UserByUserName")]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return NotFound();
            }

            var userResult = _mapper.Map<UserDto>(user);

            return Ok(userResult);
        }

    }
}
