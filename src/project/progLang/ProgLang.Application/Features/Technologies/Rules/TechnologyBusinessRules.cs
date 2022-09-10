using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using ProgLang.Application.Services.Repositories;
using ProgLang.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly ITechnologyRepository _technologyRepository;
        public TechnologyBusinessRules(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }
        public void TechnologyShouldExistWhenRequested(Technology technology)
        {
            if (technology == null) throw new BusinessException("Requested technology does not exists");
        }
        public async Task TechnologyNameCanNotBeDublicatedWhenInserted(string technologyName)
        {
            IPaginate<Technology> result = await _technologyRepository.GetListAsync(t => t.Name == technologyName);
            if (result.Items.Any()) throw new BusinessException("Technology name exists");
        }
    }
}
