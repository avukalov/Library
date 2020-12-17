using AutoMapper;
using Library.DAL.Entities;
using Library.DAL.DTOs.Author;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Common.Mapping
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorEntity, AuthorDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AuthorID));
            CreateMap<AuthorForCreationDto, AuthorEntity>();
        }
    }
}
