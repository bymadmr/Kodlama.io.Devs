using AutoMapper;
using MediatR;
using ProgLang.Application.Features.Technologies.Dtos;
using ProgLang.Application.Services.Repositories;
using ProgLang.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand:IRequest<DeletedTechnologyDto>
    {
        public int Id { get; set; }
        public class DeleteTechonolgCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            public DeleteTechonolgCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
            }
            public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
            {
                Technology mappedtechnology = _mapper.Map<Technology>(request);
                Technology deletedTechnology = await _technologyRepository.DeleteAsync(mappedtechnology);
                DeletedTechnologyDto mappedDeletedTechnologyDto = _mapper.Map<DeletedTechnologyDto>(deletedTechnology);
                return mappedDeletedTechnologyDto;
            }
        }
    }
}
