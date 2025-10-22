using BrazilHolidays.Net;

namespace CadastroEntrevista.DOMAIN.Extensions
{
    public static class DateExtensios
    {
        public static DateTime AdicionaDiasUteis(this DateTime data, int dias)
        {
            //TODO:Validar a logica e se a lib funciona
            var feriados = Holiday.GetAllNext();
            var diasUteisContados = 0;
            var dataSomada = data;
            while (diasUteisContados != dias)
            {
                data = data.AddDays(1);
                if (data.DayOfWeek == DayOfWeek.Saturday ||
                    data.DayOfWeek == DayOfWeek.Sunday ||
                    feriados.Where(feriado => data == feriado.Date).ToList().Any())
                {
                    data.AddDays(1); //se nao for um dia util, eu adiciono um dia na data para ir para o prox dia
                }
                else
                {
                    diasUteisContados++; //se for um dia util, adiciono no contador para controlar o while
                }
            }

            return data;
        }
    }
}
