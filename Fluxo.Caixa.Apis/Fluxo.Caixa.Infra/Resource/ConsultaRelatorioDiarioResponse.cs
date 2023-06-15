using Fluxo.Caixa.Domain.Response;
using Fluxo.Caixa.Infra.Resource.Base;

namespace Fluxo.Caixa.Infra.Resource
{
    public class ConsultaRelatorioDiarioResponse : ResourceBase
    {
        public ConsultaRelatorioDiarioResponse()
        {
            ListaRelatorioDiario = new List<RelatorioDiarioResponse>();
        }
        public List<RelatorioDiarioResponse> ListaRelatorioDiario { get; set; }
    }
}
