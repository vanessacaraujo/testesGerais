using AutoMapper;
using CadastroEntrevista.APLICATION.Repositories;
using CadastroEntrevista.DOMAIN.Entidades;
using CadastroEntrevista.INFRA.HttpClients;
using Microsoft.Extensions.Logging;

namespace CadastroEntrevista.INFRA.Repositories
{
    public class RhRepository :
        IRhRepository
    {
        public readonly IRhApi _rhApi;
        private readonly ILogger<RhRepository> _logger;
        public readonly IMapper _mapper;

        public RhRepository(IRhApi rhApi,
            IMapper mapper,
            ILogger<RhRepository> logger)
        {
            _rhApi = rhApi;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<List<Colaborador>?> RetornarParesOuParceiros(string cpf,
            DateTime dataAdmissao, DateTime dataDesligamento)
        {
            try
            {
                var teste = await _rhApi.RetornarParesOuParceiros(cpf,
                    dataAdmissao.ToString("yyyy-MM-dd"),
                    dataDesligamento.ToString("yyyy-MM-dd"));

                return _mapper.Map<List<Colaborador>>(teste);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro: Classe {classe} - Metodo {metodo}", 
                    nameof(RhRepository), 
                    nameof(RetornarParesOuParceiros));

                return null;
            }
        }
    }
}
