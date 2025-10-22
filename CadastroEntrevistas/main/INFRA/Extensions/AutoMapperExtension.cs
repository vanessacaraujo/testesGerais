
using AutoMapper;
using CadastroEntrevista.APLICATION.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroEntrevista.INFRA.Extensions
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection ConfigurarAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });
            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
