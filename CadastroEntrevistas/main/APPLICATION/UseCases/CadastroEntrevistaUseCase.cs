using CadastroEntrevista.APLICATION.Repositories;
using CadastroEntrevista.APLICATION.Services.Interfaces;
using CadastroEntrevista.APLICATION.UseCases.Interfaces;
using CadastroEntrevista.DOMAIN.Entidades;
using Microsoft.Extensions.Logging;

namespace CadastroEntrevista.APLICATION.UseCases
{
    public class CadastroEntrevistaUseCase :
        ICadastroEntrevistaUseCase
    {
        private readonly IRhRepository _rhRepository;
        private readonly IEntrevistaService _entrevistaService;
        private readonly ILogger<CadastroEntrevistaUseCase> _logger;

        public CadastroEntrevistaUseCase(
            IRhRepository rhRepository,
            IEntrevistaService entrevistaService,
            ILogger<CadastroEntrevistaUseCase> logger)
        {
            _rhRepository = rhRepository;
            _entrevistaService = entrevistaService;
            _logger = logger;
        }

        public async Task<List<Entrevista>> ExecuteAsync(string cpf,
            DateTime dataAdmissao,
            DateTime dataDesligamento)
        {
            try
            {
                var colaboradorees = await _rhRepository
                    .RetornarParesOuParceiros(cpf, dataAdmissao, dataDesligamento);

                if (colaboradorees != null && colaboradorees.Any())
                    return _entrevistaService.GerarListaDeEntrevistas(colaboradorees, cpf)!;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro: Classe - {classe} Metodo - {metodo}", 
                    nameof(CadastroEntrevistaUseCase), nameof(ExecuteAsync));
            }
            return new List<Entrevista>();
        }
    }
}
