using AutoMapper;
using Library.DAL.DTOs.Author;
using Library.DAL.DTOs.Book;
using Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Common.Mapping
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookEntity, BookDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BookID));
            CreateMap<BookEntity, BookWithAuthorDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BookID));
            CreateMap<BookForCreationDto, BookEntity>();
        }
    }
}
