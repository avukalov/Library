using AutoMapper;
using Library.DAL.Entities;
using Library.Models.DTOs.User;

namespace Library.Common.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserForRegistrationDto, UserEntity>();
            CreateMap<UserEntity, UserDto>();
        }
    }
}
