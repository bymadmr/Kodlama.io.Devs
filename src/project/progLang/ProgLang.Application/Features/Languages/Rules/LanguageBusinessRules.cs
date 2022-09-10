using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using ProgLang.Application.Services.Repositories;
using ProgLang.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Application.Features.Languages.Rules
{
    public class LanguageBusinessRules
    {
        private readonly ILanguageRepository _languageRepository;
        public LanguageBusinessRules(ILanguageRepository languageRepository)
        {
            _languageRepository=languageRepository;
        }
        public async Task LanguageNameCanNotBeDublicatedWhenInserted(string languageName)
        {
            IPaginate<Language> result = await _languageRepository.GetListAsync(l=>l.Name==languageName);
            if (result.Items.Any()) throw new BusinessException("Language name exists");
        }
        public void LanguageShouldExistWhenRequested(Language language)
        {
            if (language == null) throw new BusinessException("Requested language does not exists");
        }
    }
}
