using CadastroEntrevista.DOMAIN.Entidades;

namespace CadastroEntrevista.APLICATION.Repositories
{
    public interface IEntrevistaRepository
    {
        Task SalvarEntrevistaAsync(Entrevista entrevista);
    }
}
