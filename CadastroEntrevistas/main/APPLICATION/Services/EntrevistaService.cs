using CadastroEntrevista.APLICATION.Factories;
using CadastroEntrevista.APLICATION.Repositories;
using CadastroEntrevista.APLICATION.Services.Interfaces;
using CadastroEntrevista.DOMAIN.Entidades;
using Microsoft.Extensions.Logging;

namespace CadastroEntrevista.APLICATION.Services
{
    public class EntrevistaService : IEntrevistaService
    {
        private readonly IEntrevistaFactory _factory;
        private readonly IEntrevistaRepository _repository;
        private readonly ILogger<EntrevistaService> _logger;

        public EntrevistaService(IEntrevistaFactory factory, 
            IEntrevistaRepository repository,
            ILogger<EntrevistaService> logger)
        {
            _factory = factory;
            _repository = repository;
            _logger = logger;
        }

        public List<Entrevista?> GerarListaDeEntrevistas(List<Colaborador> colaboradores, string cpfReclamante)
        {
            try
            {
                var entrevistas = colaboradores
                    .Select(c => _factory.CriarEntrevista(c, cpfReclamante))
                    .ToList();

                foreach (var entrevista in entrevistas)
                {
                    if (entrevista != null) 
                        _repository.SalvarEntrevistaAsync(entrevista);
                }

                return entrevistas;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Erro: Classe - {classe} Metodo - {metodo}",
                    nameof(EntrevistaService), nameof(GerarListaDeEntrevistas));

                return new List<Entrevista?>();
            }
        }
    }
}
