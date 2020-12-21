using AutoMapper;
using Library.DAL.Entities;
using Library.DAL.DTOs.Author;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Library.Common.Mapping
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorEntity, AuthorDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AuthorId));
            CreateMap<AuthorForCreationDto, AuthorEntity>();
            CreateMap<AuthorForUpdateDto, AuthorEntity>();
            CreateMap<AuthorEntity, AuthorWithBooksDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.AuthorBooks.Select(ab => ab.Book)));
        }
    }
}
