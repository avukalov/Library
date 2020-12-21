using AutoMapper;
using Library.Common.Logging;
using Library.DAL.DTOs.Book;
using Library.Repository.Common;
using Library.Service.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Library.WebAPI.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public BooksController(IBookService bookService, IAuthorService authorService, IUnitOfWork unitOfWork, IMapper mapper, ILoggerManager logger)
        {
            _bookService = bookService;
            _authorService = authorService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookForCreationDto book)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            
            var result = await _bookService.CreateBookAsync(book);
            

            if (!result.Success)
            {
                if (result.Message == "NotFound")
                {
                    return NotFound();
                }

                return BadRequest();
            }

            return CreatedAtRoute(nameof(GetBookById), new { id = result.Data.Id }, result.Data);

        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(Guid id, [FromBody] BookForUpdateDto book)
        {
            var result = await _bookService.UpadateBookAsync(id, book);

            if (!result.Success)
            {
                if (result.Message == "NotFound")
                {
                    return NotFound();
                }

                return BadRequest();
            }

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var result = await _bookService.DeleteBookAsync(id);

            if (!result.Success)
            {
                if (result.Message == "NotFound")
                {
                    return NotFound();
                }

                return BadRequest();
            }
            return NoContent();
        }
        
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var result = await _bookService.GetBooksAsync();

            if (!result.Success)
            {
                if (result.Message == "NotFound")
                {
                    return NotFound();
                }

                return BadRequest();
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}", Name = nameof(GetBookById))]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var result = await _bookService.GetBookByIdAsync(id);

            if (!result.Success)
            {
                if (result.Message == "NotFound")
                {
                    return NotFound();
                }

                return BadRequest();
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}/authors")]
        public async Task<IActionResult> GetBookWithAuthors(Guid id)
        {
            var result = await _bookService.GetBookWithAuthrsAsync(id);

            if (!result.Success)
            {
                if (result.Message == "NotFound")
                {
                    return NotFound();
                }

                return BadRequest();
            }

            return Ok(result.Data);
        }
    }
}
