using AutoMapper;
using Library.Models.DTOs.Role;
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
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<RoleEntity> _roleManager;
        private readonly IMapper _mapper;

        public RolesController(RoleManager<RoleEntity> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;

        }

        [HttpGet("{name}", Name = "RoleByName")]
        public async Task<IActionResult> GetRoleByName(string name)
        {
            var role = await _roleManager.FindByNameAsync(name);

            if (role == null)
            {
                return NotFound();
            }

            var roleResult = _mapper.Map<RoleDto>(role);

            return Ok(roleResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RoleForCreationDto role)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            var roleEntity = _mapper.Map<RoleEntity>(role);

            var result = await _roleManager.CreateAsync(roleEntity);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return new BadRequestObjectResult(ModelState);
            }

            var createdRole = _mapper.Map<RoleDto>(roleEntity);

            return CreatedAtRoute("RoleByName", new { name = createdRole.Name }, createdRole);
        }
    }
}
