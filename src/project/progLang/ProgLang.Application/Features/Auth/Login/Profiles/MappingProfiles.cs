using AutoMapper;
using Core.Security.JWT;
using ProgLang.Application.Features.Auth.Login.Dtos;
using ProgLang.Application.Features.Auth.Login.Queries.Login;
using ProgLang.Application.Features.Auth.Register.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Application.Features.Auth.Login.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<AccessToken, LoginAccessTokenDto>().ReverseMap();
        }
    }
}
