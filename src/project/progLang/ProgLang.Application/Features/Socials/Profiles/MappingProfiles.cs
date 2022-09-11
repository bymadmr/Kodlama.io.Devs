using AutoMapper;
using Core.Security.Entities;
using ProgLang.Application.Features.Socials.Commands.CreateUserSocial;
using ProgLang.Application.Features.Socials.Commands.DeleteUserSocial;
using ProgLang.Application.Features.Socials.Commands.UpdateUserSocial;
using ProgLang.Application.Features.Socials.Dtos;
using ProgLang.Application.Features.Socials.Queries.GetByUserIdUserSocial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Application.Features.Socials.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            
            CreateMap<UserSocial, CreatedUserSocialDto>().ReverseMap();
            CreateMap<UserSocial, DeletedUserSocialDto>().ReverseMap();
            CreateMap<UserSocial, UpdatedUserSocialDto>().ReverseMap();
            CreateMap<UserSocial, CreateUserSocialCommand>().ReverseMap();
            CreateMap<UserSocial, UpdateUserSocialCommand>().ReverseMap();
            CreateMap<UserSocial, DeleteUserSocialCommand>().ReverseMap();
            CreateMap<UserSocial, UserSocialGetByUserIdDto>().ReverseMap();
            CreateMap<UserSocial, GetByUserIdUserSocialQuery>().ReverseMap();
            


        }
    }
}
