using CadastroEntrevista.INFRA.Handlers;
using CadastroEntrevista.INFRA.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroEntrevista.INFRA.Extensions
{
    public static class OauthExtensions
    {
        public static IServiceCollection ConfigurarToken(this IServiceCollection services)
        {
            services.AddHttpClient<TokenIntrospectionService>();

            services.AddAuthentication("TokenFake")
                .AddScheme<AuthenticationSchemeOptions, TokenFakeAuthHandler>("TokenFake", null);

            return services;
        }

    }
}
