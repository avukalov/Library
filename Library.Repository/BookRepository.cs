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
        private readonly LibraryDbContext _dbContext;

        public BookRepository(LibraryDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateBook(BookEntity book) => Create(book);

        public void DeleteBook(BookEntity book) => Delete(book);

        public async Task<BookEntity> GetBookByIdAsync(Guid bookId)
        {
            return await Find(b => b.BookId.Equals(bookId)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<BookEntity>> GetBooksAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<BookEntity> GetBookWithAuthorsAsync(Guid bookId)
        {
            return await Find(b => b.BookId.Equals(bookId))
                .Include(ab => ab.BookAuthors)
                .ThenInclude(a => a.Author)
                .FirstOrDefaultAsync();
        }

        public void UpdateBook(BookEntity book) => Update(book);
    }
}
