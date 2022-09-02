using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProgLang.Application.Services.Repositories;
using ProgLang.Persistence.Contexts;
using ProgLang.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Persistence
{
    public static class PersistenceServiceRegistrations
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("ProgLangConnectionString")));
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            
            return services;
        }
    }
}
