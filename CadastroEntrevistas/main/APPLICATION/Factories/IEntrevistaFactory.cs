using CadastroEntrevista.DOMAIN.Entidades;

namespace CadastroEntrevista.APLICATION.Factories
{
    public interface IEntrevistaFactory
    {
        Entrevista? CriarEntrevista(Colaborador colaborador, string cpfReclamante);
    }
}
