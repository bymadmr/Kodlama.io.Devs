using AutoMapper;
using MediatR;
using ProgLang.Application.Features.Languages.Dtos;
using ProgLang.Application.Features.Languages.Rules;
using ProgLang.Application.Services.Repositories;
using ProgLang.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Application.Features.Languages.Queries.GetByIdLanguage
{
    public class GetByIdLanguageQuery:IRequest<LanguageGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdLanguageQueryHanler:IRequestHandler<GetByIdLanguageQuery,LanguageGetByIdDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;
            public GetByIdLanguageQueryHanler(IMapper mapper, ILanguageRepository languageRepository, LanguageBusinessRules languageBusinessRules)
            {
                _mapper = mapper;
                _languageRepository = languageRepository;
                _languageBusinessRules = languageBusinessRules;
            }
            public async Task<LanguageGetByIdDto> Handle(GetByIdLanguageQuery request,CancellationToken cancellationToken)
            {
                Language? language = await _languageRepository.GetAsync(x => x.Id == request.Id);
                _languageBusinessRules.LanguageShouldExistWhenRequested(language);

                LanguageGetByIdDto result = _mapper.Map<LanguageGetByIdDto>(language);
                return result;
            }
        }
    }
}
