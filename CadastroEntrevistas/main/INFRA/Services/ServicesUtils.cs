using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using CadastroEntrevista.APLICATION.Factories;
using CadastroEntrevista.APLICATION.Repositories;
using CadastroEntrevista.APLICATION.Services;
using CadastroEntrevista.APLICATION.Services.Interfaces;
using CadastroEntrevista.APLICATION.UseCases;
using CadastroEntrevista.APLICATION.UseCases.Interfaces;
using CadastroEntrevista.INFRA.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroEntrevista.INFRA.Services
{
    public static class ServicesUtils
    {

        public static IServiceCollection RegistrarServicos(this IServiceCollection services)
        {
            #region Registro de Usecases

            services.AddTransient<ICadastroEntrevistaUseCase, CadastroEntrevistaUseCase>();

            #endregion

            #region ReIRhRepositorygistro de Repositórios

            services.AddTransient<IRhRepository, RhRepository>();
            services.AddTransient<IEntrevistaRepository, EntrevistaRepository>();

            #endregion

            #region Registros Gerais

            services.AddTransient<IEntrevistaFactory, EntrevistaFactory>();
            services.AddSingleton<IEntrevistaService, EntrevistaService>();
            services.AddAWSService<IAmazonDynamoDB>();
            services.AddSingleton<IDynamoDBContext, DynamoDBContext>();

            #endregion


            return services;
        }
    }
}
