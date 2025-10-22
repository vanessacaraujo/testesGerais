using CadastroEntrevista.INFRA.HttpClients;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace CadastroEntrevista.INFRA.Extensions
{
    public static class RefitExtensions
    {
        public static IServiceCollection ConfigurarRefit(this IServiceCollection services)
        {
            var refitSettings = new RefitSettings();
            services
                .AddRefitClient<IRhApi>(refitSettings)
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:3000"));

            return services;
        }
    }
}
