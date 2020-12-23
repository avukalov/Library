using Library.DAL.Entities;
using Library.Models;
using Library.Models.Utilities;
using System;
using System.Threading.Tasks;

namespace Library.Repository.Common
{
    public interface IBookRepository
    {
        Task<BookEntity> GetBookByIdAsync(Guid bookId);
        Task<PagedList<BookEntity>> GetBooks(BookParameters bookParameters);
        Task<BookEntity> GetBookWithAuthorsAsync(Guid bookId);

        void CreateBook(BookEntity book);
        void UpdateBook(BookEntity book);
        void DeleteBook(BookEntity book);
    }
}
