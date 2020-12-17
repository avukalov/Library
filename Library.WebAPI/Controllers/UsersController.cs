using AutoMapper;
using Library.DAL.DTOs.User;
using Library.DAL.Entities;
using Library.Repository.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
        private IUnitOfWork UnitOfWork;
        private IMapper Mapper;

        public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        [HttpGet("{id}", Name = "UserById")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await UnitOfWork.User.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userResult = Mapper.Map<UserDto>(user);

            return Ok(userResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserForCreationDto user)
        {
            if (user == null)
            {
                return BadRequest("User object is null");
            }

            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            var userEntity = Mapper.Map<UserEntity>(user);


            UnitOfWork.User.CreateUser(userEntity);
            await UnitOfWork.SaveAsync();

            var createdUser = Mapper.Map<UserDto>(userEntity);

            return CreatedAtRoute("UserById", new { id = createdUser.Id }, createdUser);

        }

    }
}
