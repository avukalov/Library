using Library.DAL.DTOs.Book;
using Library.DAL.Entities;
using Library.Models;
using Library.Models.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Common
{
    public interface IBookService
    {
        Task<ServiceResponse<BookDto>> CreateBookAsync(BookForCreationDto book);
        Task<ServiceResponse<BookDto>> UpadateBookAsync(Guid id, BookForUpdateDto book);
        Task<ServiceResponse<BookDto>> DeleteBookAsync(Guid id);

        Task<ServiceResponse<IEnumerable<BookDto>>> GetBooks(BookParameters bookParameter);
        Task<ServiceResponse<BookDto>> GetBookByIdAsync(Guid id);
        Task<ServiceResponse<BookWithAuthorDto>> GetBookWithAuthrsAsync(Guid id);
    }
}
