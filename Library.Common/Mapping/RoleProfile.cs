using AutoMapper;
using Library.Models.DTOs.Role;
using Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Common.Mapping
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleForCreationDto, RoleEntity>();
            CreateMap<RoleEntity, RoleDto>();
        }
    }
}
