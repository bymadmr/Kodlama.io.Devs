using Core.Persistence.Repositories;
using Core.Security.Entities;
using ProgLang.Application.Services.Repositories;
using ProgLang.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Persistence.Repositories
{
    public class SocialRepository : EfRepositoryBase<Social, BaseDbContext>, ISocialRepository
    {
        public SocialRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
