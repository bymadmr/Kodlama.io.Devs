using Core.Persistence.Repositories;
using ProgLang.Application.Services.Repositories;
using ProgLang.Domain.Entities;
using ProgLang.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Persistence.Repositories
{
    public class TechnologyRepository:EfRepositoryBase<Technology,BaseDbContext>,ITechnologyRepository
    {
        public TechnologyRepository(BaseDbContext context):base(context)
        {
        }
    }
}
