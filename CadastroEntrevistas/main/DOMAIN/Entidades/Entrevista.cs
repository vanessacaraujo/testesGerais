namespace CadastroEntrevista.DOMAIN.Entidades
{
    public class Entrevista
    {
        public string? IdEntrevista { get; set; }

        public Colaborador? Colaborador { get; set; }

        public string? CpfReclamante { get; set; }   

        public string? IdScript { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataExpiracao { get; set; }
    }
}
