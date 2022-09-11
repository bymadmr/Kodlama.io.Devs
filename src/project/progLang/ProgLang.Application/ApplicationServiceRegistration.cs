using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProgLang.Application.Features.Auth.Login.Rules;
using ProgLang.Application.Features.Auth.Register.Rules;
using ProgLang.Application.Features.Languages.Rules;
using ProgLang.Application.Features.Socials.Rules;
using ProgLang.Application.Features.Technologies.Rules;
using System.Reflection;

namespace ProgLang.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<LanguageBusinessRules>();
            services.AddScoped<TechnologyBusinessRules>();
            services.AddScoped<LoginBusinessRules>();
            services.AddScoped<RegisterBusinessRules>();
            services.AddScoped<UserSocialBusinessRules>();
            

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;
        }
    }
}
