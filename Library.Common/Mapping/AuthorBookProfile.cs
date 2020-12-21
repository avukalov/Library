using AutoMapper;
using Library.DAL.DTOs.AuthorBook;
using Library.DAL.Entities;

namespace Library.Common.Mapping
{
    public class AuthorBookProfile : Profile
    {
        public AuthorBookProfile()
        {
            CreateMap<AddAuthorBookDto, AuthorBookEntity>();
        }
    }
}
