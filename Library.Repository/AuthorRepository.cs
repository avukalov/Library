using Library.DAL;
using Library.DAL.Entities;
using Library.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class AuthorRepository : GenericRepository<AuthorEntity>, IAuthorRepository
    {
        public AuthorRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }

        public void CreateAuthor(AuthorEntity author) => Create(author);

        public void DeleteAuthor(AuthorEntity author) => Delete(author);

        public async Task<AuthorEntity> GetAuthorByIdAsync(Guid authorId)
        {
            return await FindByCondition(a => a.AuthorID.Equals(authorId)).FirstOrDefaultAsync();
        }

        public async Task<AuthorEntity> GetAuthorWithBooksAsync(Guid authorId)
        {
            return await FindByCondition(a => a.AuthorID.Equals(authorId)).Include(b => b.Books).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AuthorEntity>> GetAuthorsAsync()
        {
            return await FindAll().OrderBy(a => a.LastName).ToListAsync();
        }

        public void UpdateAuthor(AuthorEntity author) => Update(author);
    }
}
