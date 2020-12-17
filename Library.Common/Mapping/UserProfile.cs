using AutoMapper;
using Library.DAL.Entities;
using Library.DAL.DTOs.User;

namespace Library.Common.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, UserDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserID));
            CreateMap<UserForCreationDto, UserEntity>();
        }
    }
}
