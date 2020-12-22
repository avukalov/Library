using Library.DAL;
using Library.DAL.Entities;
using Library.Models;
using Library.Models.Common.Utils;
using Library.Models.Utils;
using Library.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DynamicLinq;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Library.Repository
{
    public class BookRepository : GenericRepository<BookEntity>, IBookRepository
    {
        private readonly LibraryDbContext _dbContext;
        private readonly IQueryHelper<BookEntity> _queryHelper;

        public BookRepository(LibraryDbContext dbContext, IQueryHelper<BookEntity> queryHelper) : base(dbContext)
        {
            _dbContext = dbContext;
            _queryHelper = queryHelper;
        }

        public void CreateBook(BookEntity book) => Create(book);

        public void DeleteBook(BookEntity book) => Delete(book);

        public async Task<BookEntity> GetBookByIdAsync(Guid bookId)
        {
            return await Find(b => b.BookId.Equals(bookId)).FirstOrDefaultAsync();
        }

        public async Task<PagedList<BookEntity>> GetBooks(BookParameters bookParameters)
        {
            var books = FindAll();

            if (!String.IsNullOrEmpty(bookParameters.Category))
            {
                books = books.Where(b => b.Category.Contains(bookParameters.Category));
            }
            
            if (!String.IsNullOrEmpty(bookParameters.Language))
            {
                books = books.Where(b => b.Language.Equals(bookParameters.Language));
            }
            
            books = books.Where(b =>
                        b.Published.Year >= bookParameters.MinPublishedYear &&
                        b.Published.Year <= bookParameters.MaxPublishedYear)
                        .OrderBy(b => b.Title);

            var sortedBooks = _queryHelper.Sort.ApplySort(books, bookParameters.OrderBy);

            return await PagedList<BookEntity>.ToPagedList(sortedBooks, bookParameters.PageNumber, bookParameters.PageSize);
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
