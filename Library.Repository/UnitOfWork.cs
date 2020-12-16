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
        private LibraryDbContext DbContext;
        private IUserRepository _user;

        public UnitOfWork(LibraryDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(DbContext);
                }

                return _user;
            }
        }

        public async Task SaveAsync()
        {
            await this.DbContext.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
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