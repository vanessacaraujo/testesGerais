namespace CadastroEntrevista.DOMAIN.Entidades
{
    public class Colaborador
    {
        public string? Cpf { get; set; }

        public int Funcional { get; set; }

        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? Cargo { get; set; }

        public bool VinculoAtivo { get; set; }
    }
}
