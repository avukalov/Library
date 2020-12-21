using Library.DAL;
using Library.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private LibraryDbContext _dbContext;
        private IUserRepository _user;
        private IAuthorRepository _author;
        private IBookRepository _book;
        private IAuthorBookRepository _authorBook;

        public UnitOfWork(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_dbContext);
                }

                return _user;
            }
        }
        public IAuthorRepository Author
        {
            get
            {
                if (_author == null)
                {
                    _author = new AuthorRepository(_dbContext);
                }

                return _author;
            }
        }
        public IBookRepository Book
        {
            get
            {
                if (_book == null)
                {
                    _book = new BookRepository(_dbContext);
                }

                return _book;
            }
        }
        public IAuthorBookRepository AuthorBook
        {
            get
            {
                if (_authorBook == null)
                {
                    _authorBook = new AuthorBookRepository(_dbContext);
                }

                return _authorBook;
            }
        }

        public async Task SaveAsync()
        {
            await this._dbContext.SaveChangesAsync();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}