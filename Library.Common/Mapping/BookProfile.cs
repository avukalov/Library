using AutoMapper;
using Library.Models.DTOs.Author;
using Library.Models.DTOs.Book;
using Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Common.Mapping
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookEntity, BookDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BookId));
            CreateMap<BookEntity, BookWithAuthorDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BookId))
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.BookAuthors.Select(ba => ba.Author)));
            CreateMap<BookForCreationDto, BookEntity>();
            CreateMap<BookForUpdateDto, BookEntity>();
        }
    }
}
