using AutoMapper;
using CadastroEntrevista.DOMAIN.DTO;
using CadastroEntrevista.DOMAIN.Entidades;
using CadastroEntrevista.DOMAIN.Models.Response;
using CadastroEntrevista.DOMAIN.Models.Web;

namespace CadastroEntrevista.APLICATION.Mapper
{
    public class MapperProfile :
        Profile
    {
        public MapperProfile()
        {
            CreateMap<ColaboradorWM, Colaborador>();

            CreateMap<Colaborador, ColaboradorDM>();

            CreateMap<Entrevista, EntrevistaResponse>();

            CreateMap<Entrevista, EntrevistaDM>();
        }
    }
}
