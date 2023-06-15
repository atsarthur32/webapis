using AutoMapper;
using Fluxo.Caixa.Domain.Models;
using Fluxo.Caixa.Infra.Resource;

namespace Fluxo.Caixa.Infra.Mapper
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<CadastroLancamentoRequest, Lancamentos>();
            CreateMap<ConsultaLancamentoRequest, Lancamentos>();
            CreateMap<ConsultaRelatorioDiarioRequest, RelatorioDiario>();

        }
    }

}
