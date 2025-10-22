using CadastroEntrevista.DOMAIN.Models.Web;
using Refit;

namespace CadastroEntrevista.INFRA.HttpClients
{
    public interface IRhApi
    {
        [Get("/api/paresparceiros")]
        Task<List<ColaboradorWM>> RetornarParesOuParceiros(
            [Query("cpf")] string cpf,
            [Query("inicio")] string inicio,
            [Query("fim")] string fim);
    }
}
