using AutoMapper;
using Core.Persistence.Paging;
using ProgLang.Application.Features.Technologies.Commands.CreateTechnology;
using ProgLang.Application.Features.Technologies.Commands.DeleteTechnology;
using ProgLang.Application.Features.Technologies.Commands.UpdateTechnology;
using ProgLang.Application.Features.Technologies.Dtos;
using ProgLang.Application.Features.Technologies.Models;
using ProgLang.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Application.Features.Technologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Technology, TechnologyListDto>().ForMember(c => c.LanguageName, opt => opt.MapFrom(c => c.Language.Name)).ReverseMap();
            CreateMap<Technology, TechnologyGetByIdDto>().ForMember(c => c.LanguageName, opt => opt.MapFrom(c => c.Language.Name)).ReverseMap();
            CreateMap<Technology, CreatedTechnologyDto>().ReverseMap();
            CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();
            CreateMap<Technology, UpdatedTechnologyDto>().ReverseMap();
            CreateMap<Technology, UpdateTechnologyCommand>().ReverseMap();
            CreateMap<Technology, DeletedTechnologyDto>().ReverseMap();
            CreateMap<Technology, DeleteTechnologyCommand>().ReverseMap();
            CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();

        }
    }
}
