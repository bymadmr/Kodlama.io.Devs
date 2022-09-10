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

namespace ProgLang.Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommand:IRequest<CreatedTechnologyDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int LanguageId { get; set; }

        public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;
            public CreateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }
            public async Task<CreatedTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _technologyBusinessRules.TechnologyNameCanNotBeDublicatedWhenInserted(request.Name);

                Technology mappedtechnology = _mapper.Map<Technology>(request);
                Technology createdTechnology = await _technologyRepository.AddAsync(mappedtechnology);
                CreatedTechnologyDto mappedCreatedTechnologyDto = _mapper.Map<CreatedTechnologyDto>(createdTechnology);
                return mappedCreatedTechnologyDto;
            }
        }
    }
}
