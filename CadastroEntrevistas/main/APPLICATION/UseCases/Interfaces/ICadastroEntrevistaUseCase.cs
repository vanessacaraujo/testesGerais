using CadastroEntrevista.DOMAIN.Entidades;

namespace CadastroEntrevista.APLICATION.UseCases.Interfaces
{
    public interface ICadastroEntrevistaUseCase
    {
        public Task<List<Entrevista>> ExecuteAsync(string cpf,
            DateTime dataAdmissao,
            DateTime dataDesligamento);
    }
}
