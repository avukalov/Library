using Library.DAL;
using Library.DAL.Entities;
using Library.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Repository
{
    public class AuthorBookRepository : GenericRepository<AuthorBookEntity>, IAuthorBookRepository
    {
        public AuthorBookRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }

        public void CreateAuthorBook(AuthorBookEntity authorBook) => Create(authorBook);
    }
}
