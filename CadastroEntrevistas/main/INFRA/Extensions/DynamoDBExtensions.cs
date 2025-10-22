
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroEntrevista.INFRA.Extensions
{
    public static class DynamoDBExtensions
    {
        public static IServiceCollection ConexaoDynamoDB(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDefaultAWSOptions(configuration.GetAWSOptions());
            return services;
        }

    }

}