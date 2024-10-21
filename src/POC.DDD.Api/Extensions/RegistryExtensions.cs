using POC.DDD.Application.Extensions;
using POC.DDD.Infra.Extensions;

namespace POC.DDD.Api.Extensions
{
    public static class RegistryExtensions
    {
        public static WebApplicationBuilder AddApi(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            return builder;
        }

        public static WebApplicationBuilder AddDomain(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddApplication()
                .AddInfra();

            return builder;
        }
    }
}
