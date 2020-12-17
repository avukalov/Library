using Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository.Common
{
    public interface IAuthorRepository
    {
        Task<AuthorEntity> GetAuthorByIdAsync(Guid authorId);
        Task<AuthorEntity> GetAuthorWithBooksAsync(Guid authorId);
        Task<IEnumerable<AuthorEntity>> GetAuthorsAsync();
        void CreateAuthor(AuthorEntity author);
        void UpdateAuthor(AuthorEntity author);
        void DeleteAuthor(AuthorEntity author);
    }
}
