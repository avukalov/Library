using AutoMapper;
using Library.DAL.DTOs.Book;
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
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public BooksController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            // vraca IEnumerable ---> provjeriti ICollection
            var books = await UnitOfWork.Book.GetBooksAsync();

            return Ok(books);
        }

        [HttpGet("{id}", Name = "BookById")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var book = await UnitOfWork.Book.GetBookByIdAsync(id);

            if (book == null)
            {
                return NotFound($"There is no book with id: {id}");
            }

            var bookResult = Mapper.Map<BookDto>(book);

            return Ok(bookResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookForCreationDto book)
        {
            if (book == null)
            {
                return BadRequest("Book object is null");
            }

            var author = await UnitOfWork.Author.GetAuthorByIdAsync(book.AuthorID);

            if (author == null)
            {
                return BadRequest($"Author with id: { book.AuthorID } not found");
            }

            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            var bookEntity = Mapper.Map<BookEntity>(book);

            UnitOfWork.Book.CreateBook(bookEntity);
            await UnitOfWork.SaveAsync();

            var createdBook = Mapper.Map<BookDto>(bookEntity);

            return CreatedAtRoute("BookById", new { id = createdBook.Id }, createdBook);

        }
    }
}
