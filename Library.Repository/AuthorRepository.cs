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
        public void UpdateAuthor(AuthorEntity author) => Update(author);

        public async Task<IEnumerable<AuthorEntity>> GetAuthorsAsync()
        {
            return await FindAll().OrderBy(a => a.LastName).ToListAsync();
        }
        public async Task<AuthorEntity> GetAuthorByIdAsync(Guid authorId)
        {
            return await Find(a => a.AuthorId.Equals(authorId)).FirstOrDefaultAsync();
        }
        public async Task<AuthorEntity> GetAuthorWithBooksAsync(Guid authorId)
        {
            return await Find(a => a.AuthorId.Equals(authorId))
                .Include(b => b.AuthorBooks)
                .ThenInclude(b => b.Book)
                .FirstOrDefaultAsync();
        }

    }
}
