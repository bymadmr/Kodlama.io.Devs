﻿using AutoMapper;
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

namespace ProgLang.Application.Features.Languages.Commands.CreateLanguage
{
    public class CreateLanguageCommand:IRequest<CreatedLanguageDto>
    {
        public string Name { get; set; }
        public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, CreatedLanguageDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;
            public CreateLanguageCommandHandler(LanguageBusinessRules languageBusinessRules, IMapper mapper, ILanguageRepository languageRepository)
            {
                _languageBusinessRules = languageBusinessRules;
                _mapper = mapper;
                _languageRepository = languageRepository;
            }
            public async Task<CreatedLanguageDto> Handle(CreateLanguageCommand request,CancellationToken cancellationToken)
            {
                await _languageBusinessRules.LanguageNameCanNotBeDublicatedWhenInserted(request.Name);

                Language mappedLanguage = _mapper.Map<Language>(request);
                Language createdLanguage =await _languageRepository.AddAsync(mappedLanguage);
                CreatedLanguageDto mappedcreatedLanguageDto = _mapper.Map<CreatedLanguageDto>(createdLanguage);
                return mappedcreatedLanguageDto;
            }
        }
    }
}
