using CadastroEntrevista.DOMAIN.Entidades;

namespace CadastroEntrevista.APLICATION.Repositories
{
    public interface IRhRepository
    {
        Task<List<Colaborador>?> RetornarParesOuParceiros(
            string cpf,
            DateTime dataAdmissao,
            DateTime dataDesligamento);
    }
}
