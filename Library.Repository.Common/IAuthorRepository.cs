using Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository.Common
{
    public interface IAuthorRepository
    {
        void CreateAuthor(AuthorEntity author);
        void UpdateAuthor(AuthorEntity author);
        void DeleteAuthor(AuthorEntity author);
        Task<IEnumerable<AuthorEntity>> GetAuthorsAsync();
        Task<AuthorEntity> GetAuthorByIdAsync(Guid authorId);
        Task<AuthorEntity> GetAuthorWithBooksAsync(Guid authorId);
    }
}
