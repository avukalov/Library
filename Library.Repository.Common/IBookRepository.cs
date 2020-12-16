using Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository.Common
{
    public interface IBookRepository
    {
        Task<BookEntity> GetBookByIdAsync(Guid bookId);
        Task<IEnumerable<BookEntity>> GetBooksAsync();

        void CreateBook(BookEntity book);
        void UpdateBook(BookEntity book);
        void DeleteBook(BookEntity book);
    }
}
