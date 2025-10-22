using CadastroEntrevista.DOMAIN.Entidades;
using CadastroEntrevista.DOMAIN.Extensions;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace CadastroEntrevista.APLICATION.Factories
{
    public class EntrevistaFactory
        : IEntrevistaFactory
    {
        public Entrevista? CriarEntrevista(Colaborador colaborador,
            string cpfReclamante)
        {
            if (colaborador.VinculoAtivo)
            {
                var entrevista = new Entrevista
                {
                    IdEntrevista = $"CPF:{colaborador.Cpf}#DATAEXCLUSAO:{DateTime.Today.Date.ToString("dd-MM-yyyy")}",
                    CpfReclamante = cpfReclamante,
                    Colaborador = colaborador,
                    DataCriacao = DateTime.Today.Date,
                    DataExpiracao = DateTime.Today.Date.AdicionaDiasUteis(5),
                    IdScript = $"script_{Regex.Replace(colaborador.Cargo!, @"\s+", string.Empty)}"
                };
                return entrevista;
            }
            else
            {
                return null;
            }
        }
    }
}
