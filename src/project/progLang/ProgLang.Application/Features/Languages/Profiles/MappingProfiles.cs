using AutoMapper;
using Core.Persistence.Paging;
using ProgLang.Application.Features.Languages.Commands.CreateLanguage;
using ProgLang.Application.Features.Languages.Dtos;
using ProgLang.Application.Features.Languages.Models;
using ProgLang.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Application.Features.Languages.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Language,CreatedLanguageDto>().ReverseMap();
            CreateMap<Language,CreateLanguageCommand>().ReverseMap();
            CreateMap<IPaginate<Language>,LanguageListModel>().ReverseMap();
            CreateMap<Language, LanguageListDto>().ReverseMap();
            CreateMap<Language,LanguageGetByIdDto>().ReverseMap();
        }
    }
}
