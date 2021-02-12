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
        Task<bool> CreateAuthorAsync(AuthorEntity author);
        Task<AuthorEntity> UpdateAuthorAsync(AuthorEntity author);
        Task<bool> DeleteAuthorAsync(Guid id);
    }
}
