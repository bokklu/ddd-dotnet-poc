using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using POC.DDD.Application.DTOs.Input;
using POC.DDD.Application.Services;
using POC.DDD.Application.Services.Abstractions;
using POC.DDD.Application.Validators;

namespace POC.DDD.Application.Extensions
{
    public static class RegistryExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IBusinessService, BusinessService>();
            services.AddScoped<IValidator<BusinessRequest>, BusinessRequestValidator>();

            return services;
        }
    }
}
