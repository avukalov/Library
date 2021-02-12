using Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository.Common
{
    public interface ISqlRepository
    {
        Task<List<AuthorEntity>> GetAuthorsAsync();
        Task<AuthorEntity> GetAuthorByIdAsync(Guid id);
        Task CreateAuthor(AuthorEntity author);
        Task<AuthorEntity> UpdateAuthor(AuthorEntity author);
        Task<bool> DeleteAuthor(Guid id);
    }
}
