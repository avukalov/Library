using Library.Models.DTOs.Author;
using Library.DAL.Entities;
using Library.Models.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Common
{
    public interface IAuthorService
    {
        Task<ServiceResponse<AuthorDto>> CreateAuthorAsync(AuthorForCreationDto author);
        Task<ServiceResponse<IEnumerable<AuthorDto>>> GetAuthorsAsync();
        Task<ServiceResponse<AuthorDto>> GetAuthorByIdAsync(Guid id);
        Task<ServiceResponse<AuthorWithBooksDto>> GetAuthorWithBooksAsync(Guid id);
        Task<ServiceResponse<AuthorDto>> UpdateAuthorAsync(Guid id, AuthorForUpdateDto author);
        Task<ServiceResponse<AuthorDto>> DeleteAuthorAsync(Guid id);

    }
}
