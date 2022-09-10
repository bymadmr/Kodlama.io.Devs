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

namespace ProgLang.Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommand:IRequest<UpdatedTechnologyDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int LanguageId { get; set; }
        public class UpdateTechonolgCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdatedTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;
            public UpdateTechonolgCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }
            public async Task<UpdatedTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _technologyBusinessRules.TechnologyNameCanNotBeDublicatedWhenInserted(request.Name);

                Technology mappedtechnology = _mapper.Map<Technology>(request);
                Technology updatedTechnology = await _technologyRepository.UpdateAsync(mappedtechnology);
                UpdatedTechnologyDto mappedUpdatedTechnologyDto = _mapper.Map<UpdatedTechnologyDto>(updatedTechnology);
                return mappedUpdatedTechnologyDto;
            }
        }
    }
}
