using Amazon.DynamoDBv2.DataModel;
using AutoMapper;
using CadastroEntrevista.APLICATION.Repositories;
using CadastroEntrevista.DOMAIN.DTO;
using CadastroEntrevista.DOMAIN.Entidades;
using Microsoft.Extensions.Logging;

namespace CadastroEntrevista.INFRA.Repositories
{
    public class EntrevistaRepository : IEntrevistaRepository
    {
        private readonly IDynamoDBContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<EntrevistaRepository> _logger;


        public EntrevistaRepository(IDynamoDBContext context,
            IMapper mapper, ILogger<EntrevistaRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task SalvarEntrevistaAsync(Entrevista entrevista)
        {
            try
            {
                var entrevistaDm = _mapper.Map<EntrevistaDM>(entrevista);
                await _context.SaveAsync(entrevistaDm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro: Classe {classe} - Metodo {metodo}",
                    nameof(EntrevistaRepository),
                    nameof(SalvarEntrevistaAsync));

            }
        }

        public async Task<EntrevistaDM> ObterEntrevistaPorIdAsync(string idEntrevista)
        {
            return await _context.LoadAsync<EntrevistaDM>(idEntrevista);
        }

        public async Task<IEnumerable<EntrevistaDM>> ListarTodasAsync()
        {
            var conditions = new List<ScanCondition>();
            return await _context.ScanAsync<EntrevistaDM>(conditions).GetRemainingAsync();
        }

        public async Task DeletarEntrevistaAsync(string id)
        {
            await _context.DeleteAsync<EntrevistaDM>(id);
        }

    }
}
