using System.Text.Json.Serialization;

namespace CadastroEntrevista.DOMAIN.Models.Web
{
    public class ColaboradorWM
    {
        [JsonPropertyName("cpf")]
        public string? Cpf { get; set; }

        [JsonPropertyName("funcional")]
        public int Funcional { get; set; }

        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("cargo")]
        public string? Cargo { get; set; }

        [JsonPropertyName("vinculo_ativo")]
        public bool? VinculoAtivo { get; set; }

    }
}
