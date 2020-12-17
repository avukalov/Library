using Library.DAL;
using Library.DAL.Entities;
using Library.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class BookRepository : GenericRepository<BookEntity>, IBookRepository
    {
        public BookRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }

        public void CreateBook(BookEntity book) => Create(book);

        public void DeleteBook(BookEntity book) => Delete(book);

        public async Task<BookEntity> GetBookByIdAsync(Guid bookId)
        {
            return await FindByCondition(b => b.BookID.Equals(bookId)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<BookEntity>> GetBooksAsync()
        {
            return await FindAll().ToListAsync();
        }

        public void UpdateBook(BookEntity book) => Update(book);
    }
}
