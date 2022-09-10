using AutoMapper;
using MediatR;
using ProgLang.Application.Features.Technologies.Dtos;
using ProgLang.Application.Features.Technologies.Rules;
using ProgLang.Application.Services.Repositories;
using ProgLang.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Application.Features.Technologies.Queries.GetByIdTechnology
{
    public class GetByIdTechnologyQuery:IRequest<TechnologyGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdTechnologyQueryHandler:IRequestHandler<GetByIdTechnologyQuery, TechnologyGetByIdDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;
            public GetByIdTechnologyQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }
            public async Task<TechnologyGetByIdDto> Handle(GetByIdTechnologyQuery request, CancellationToken cancellationToken)
            {
                Technology? technology = await _technologyRepository.GetAsync(x => x.Id == request.Id);
                _technologyBusinessRules.TechnologyShouldExistWhenRequested(technology);
                TechnologyGetByIdDto mappedtechnologyGetByIdDto =_mapper.Map<TechnologyGetByIdDto>(technology);
                return mappedtechnologyGetByIdDto;
            }
        }
    }
}
