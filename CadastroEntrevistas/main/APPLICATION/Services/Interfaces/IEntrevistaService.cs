using CadastroEntrevista.DOMAIN.Entidades;

namespace CadastroEntrevista.APLICATION.Services.Interfaces
{
    public interface IEntrevistaService
    {
        public List<Entrevista?>? GerarListaDeEntrevistas(List<Colaborador> colaboradores, string cpfReclamante);
    }
}
