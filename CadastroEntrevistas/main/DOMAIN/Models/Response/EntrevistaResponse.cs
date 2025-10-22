using System.Text.Json.Serialization;

namespace CadastroEntrevista.DOMAIN.Models.Response
{
    public class EntrevistaResponse
    {
        [JsonPropertyName("id_entrevista")]
        public int idEntrevista { get; set; }

        [JsonPropertyName("colaborador")]
        public ColaboradorResponse? Colaborador { get; set; }

        [JsonPropertyName("id_script")]
        public string? IdScript { get; set; }

        [JsonPropertyName("data_criacao")]
        public DateTime? DataCriacao { get; set; }

        [JsonPropertyName("data_expiracao")]
        public DateTime? DataExpiracao { get; set; }

    }

    public class ColaboradorResponse
    {

    }
}
