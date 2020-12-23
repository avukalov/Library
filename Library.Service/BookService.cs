using AutoMapper;
using Library.Common.Logging;
using Library.Models.DTOs.AuthorBook;
using Library.Models.DTOs.Book;
using Library.DAL.Entities;
using Library.Models;
using Library.Models.Utilities;
using Library.Repository.Common;
using Library.Service.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service
{
    public class BookService : IBookService
    {
        private readonly IAuthorService _authorService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public BookService(IAuthorService authorService, IUnitOfWork unitOfWork, IMapper mapper, ILoggerManager logger)
        {
            _authorService = authorService;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<BookDto>> CreateBookAsync(BookForCreationDto book)
        {
            ServiceResponse<BookDto> response = new ServiceResponse<BookDto>();

            try
            {
                var authorResult = await _authorService.GetAuthorByIdAsync(book.AuthorId);

                if (!authorResult.Success)
                {
                    response.Success = authorResult.Success;
                    response.Message = authorResult.Message;

                    return response;
                }

                var bookEntity = _mapper.Map<BookEntity>(book);
                _unitOfWork.Book.CreateBook(bookEntity);

                var authorBook = _mapper.Map<AuthorBookEntity>(new AddAuthorBookDto(book.AuthorId, bookEntity.BookId));
                _unitOfWork.AuthorBook.CreateAuthorBook(authorBook);

                await _unitOfWork.SaveAsync();
                _logger.LogInfo("Book is stored");

                response.Data = _mapper.Map<BookDto>(bookEntity);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<ServiceResponse<BookDto>> UpadateBookAsync(Guid id, BookForUpdateDto bookUpdate)
        {
            ServiceResponse<BookDto> response = new ServiceResponse<BookDto>();

            try
            {
                var book = await _unitOfWork.Book.GetBookByIdAsync(id);

                if (book == null)
                {
                    response.Success = false;
                    response.Message = "NotFound";

                    _logger.LogError($"Booke with id: {id} not found");
                }

                _mapper.Map(bookUpdate, book);

                _unitOfWork.Book.UpdateBook(book);
                await _unitOfWork.SaveAsync();

                _logger.LogInfo($"Author with id: {book.BookId} successfuly updated");

                response.Data = _mapper.Map<BookDto>(book);

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
        public async  Task<ServiceResponse<BookDto>> DeleteBookAsync(Guid id)
        {
            ServiceResponse<BookDto> response = new ServiceResponse<BookDto>();

            try
            {
                var book = await _unitOfWork.Book.GetBookByIdAsync(id);

                if (book == null)
                {
                    response.Success = false;
                    response.Message = "NotFound";

                    _logger.LogError($"Book with id: {id} not found");
                }

                _unitOfWork.Book.DeleteBook(book);
                await _unitOfWork.SaveAsync();

                _logger.LogInfo($"Author with id: {id} successfuly deleted");

                response.Data = _mapper.Map<BookDto>(book);

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<BookDto>> GetBookByIdAsync(Guid id)
        {
            ServiceResponse<BookDto> response = new ServiceResponse<BookDto>();

            try
            {
                var book = await _unitOfWork.Book.GetBookByIdAsync(id);

                if (book == null)
                {
                    response.Success = false;
                    response.Message = "NotFound";

                    _logger.LogError($"Book with id: {id} not found");
                }

                _logger.LogInfo($"Author with id: {id} found");

                response.Data = _mapper.Map<BookDto>(book);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<BookDto>>> GetBooks(BookParameters bookParameters)
        {
            ServiceResponse<IEnumerable<BookDto>> response = new ServiceResponse<IEnumerable<BookDto>>();

            try
            {
                var books = await _unitOfWork.Book.GetBooks(bookParameters);

                if (books == null)
                {
                    response.Success = false;
                    response.Message = "NotFound";

                    _logger.LogError($"Books not found");
                }

                response.Metadata = new
                {
                    books.TotalCount,
                    books.PageSize,
                    books.CurrentPage,
                    books.TotalPages,
                    books.HasNext,
                    books.HasPrevious
                };

                _logger.LogInfo($"All books retrived");

                response.Data = _mapper.Map<IEnumerable<BookDto>>(books);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<BookWithAuthorDto>> GetBookWithAuthrsAsync(Guid id)
        {
            ServiceResponse<BookWithAuthorDto> response = new ServiceResponse<BookWithAuthorDto>();

            try
            {
                var book = await _unitOfWork.Book.GetBookWithAuthorsAsync(id);

                if (book == null)
                {
                    response.Success = false;
                    response.Message = "NotFound";

                    _logger.LogError($"Book with id: {id} not found");
                }

                _logger.LogInfo($"Book with id: {id} found");

                response.Data = _mapper.Map<BookWithAuthorDto>(book);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

       
    }
}
