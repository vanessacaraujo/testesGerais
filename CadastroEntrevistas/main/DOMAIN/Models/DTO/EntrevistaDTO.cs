using Amazon.DynamoDBv2.DataModel;

namespace CadastroEntrevista.DOMAIN.DTO
{
    [DynamoDBTable("Entrevistas")]
    public class EntrevistaDM
    {
        [DynamoDBHashKey("cod_idef_reclamante")] // Chave primária (partition key id Reclamante)
        public string CpfReclamante { get; set; }

        [DynamoDBRangeKey("txt_objt_idef_entrevista")] // Chave primária (sort key composicao id Colaborador + dataExpiracao) assim para fazer filtros via query sem precisar fazer scan na tabela
        public string IdEntrevista { get; set; }

        [DynamoDBProperty]
        public ColaboradorDM? Colaborador { get; set; }

        [DynamoDBProperty]
        public string? IdScript { get; set; }

        [DynamoDBProperty]
        public DateTime DataCriacao { get; set; }

        [DynamoDBProperty]
        public DateTime DataExpiracao { get; set; }
    }

    public class ColaboradorDM
    {
        [DynamoDBProperty]
        public string Cpf { get; set; }

        [DynamoDBProperty]
        public int Funcional { get; set; }

        [DynamoDBProperty]
        public string Nome { get; set; }

        [DynamoDBProperty]
        public string Email { get; set; }

        [DynamoDBProperty]
        public string Cargo { get; set; }

        [DynamoDBProperty]
        public bool VinculoAtivo { get; set; }
    }
}