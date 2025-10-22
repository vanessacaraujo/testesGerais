using System.Text.Json.Serialization;

namespace CadastroEntrevista.DOMAIN.Models.Requests
{
    public class EntrevistaRequest
    {
        [JsonPropertyName("cpf")]
        public string? Cpf { get; set; }

        [JsonPropertyName("data_admissao")]
        public DateTime dataAdmissao { get; set; }

        [JsonPropertyName("data_desligamento")]
        public DateTime dataDesligamento { get; set; }
    }
}
