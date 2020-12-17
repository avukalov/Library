using AutoMapper;
using Library.DAL.DTOs.Author;
using Library.DAL.Entities;
using Library.Repository.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebAPI.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public AuthorsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }


        [HttpGet("{id}", Name = "AuthorById")]
        public async Task<IActionResult> GetAuthorById(Guid id)
        {
            var author = await UnitOfWork.Author.GetAuthorByIdAsync(id);

            if(author == null)
            {
                return NotFound();
            }

            var authorResult = Mapper.Map<AuthorDto>(author);

            return Ok(authorResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorForCreationDto author)
        {
            if (author == null)
            {
                return BadRequest("Author object is null");
            }

            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            var authorEntity = Mapper.Map<AuthorEntity>(author);

            UnitOfWork.Author.CreateAuthor(authorEntity);
            await UnitOfWork.SaveAsync();

            var createdAuthor = Mapper.Map<AuthorDto>(authorEntity);

            return CreatedAtRoute("AuthorById", new { id = createdAuthor.Id }, createdAuthor);

        }
    }
}
