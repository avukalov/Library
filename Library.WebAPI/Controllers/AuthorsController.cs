using AutoMapper;
using Library.Common.Logging;
using Library.Models.DTOs.Author;
using Library.DAL.Entities;
using Library.Repository.Common;
using Library.Service.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.WebAPI.Filters.ActionFilters;

namespace Library.WebAPI.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly ILoggerManager _logger;

        public AuthorsController(IAuthorService authorService, ILoggerManager logger)
        {
            _authorService = authorService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var result = await _authorService.GetAuthorsAsync();

            if (!result.Success)
            {
                if (result.Message == "NotFound")
                {
                    _logger.LogError($"No Author found");
                    return NotFound();
                }

                return BadRequest();
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}", Name = nameof(GetAuthorById))]
        [ServiceFilter(typeof(AuthorEntityExistsAttribute))]
        public async Task<IActionResult> GetAuthorById(Guid id)
        {
            var authorFromHttp = HttpContext.Items["author"] as AuthorDto;
            Console.WriteLine(authorFromHttp);

            var result = await _authorService.GetAuthorByIdAsync(id);

            if (!result.Success)
            {
                if (result.Message == "NotFound")
                {
                    _logger.LogError($"Author with id: {id} not found");
                    return NotFound();
                }

                return BadRequest();
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}/books")]
        public async Task<IActionResult> GetAuthorWithBooks(Guid id)
        {
            var result = await _authorService.GetAuthorWithBooksAsync(id);

            if (!result.Success)
            {
                if (result.Message == "NotFound")
                {
                    _logger.LogError($"Author with id: {id} not found");
                    return NotFound();
                }

                return BadRequest();
            }

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorForCreationDto author)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            var result = await _authorService.CreateAuthorAsync(author);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return CreatedAtRoute(nameof(GetAuthorById), new { id = result.Data.Id }, result.Data);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(Guid id, [FromBody] AuthorForUpdateDto author)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            var result = await _authorService.UpdateAuthorAsync(id, author);

            if (!result.Success)
            {
                if (result.Message == "NotFound")
                {
                    _logger.LogError($"Author with id: {id} not found");
                    return NotFound();
                }

                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            var result = await _authorService.DeleteAuthorAsync(id);

            if (!result.Success)
            {
                if (result.Message == "NotFound")
                {
                    _logger.LogError($"Author with id: {id} not found");
                    return NotFound();
                }

                return BadRequest();
            }

            return NoContent();
        }
    }
}
