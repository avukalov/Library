using AutoMapper;
using Library.DAL.DTOs;
using Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DAL.Mapper
{
    class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserEntity, UserDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserID));
            CreateMap<UserForCreationDto, UserEntity> ();
        }
    }
}
