using Fluxo.Caixa.Domain.Models;
using Fluxo.Caixa.Domain.Response;
using Fluxo.Caixa.Infra.Resource.Base;

namespace Fluxo.Caixa.Infra.Resource
{
    public class ConsultaLancamentoResponse : ResourceBase
    {
        public ConsultaLancamentoResponse()
        {
            ListaLancamentos = new List<LancamentosResponse>();
        }
        public List<LancamentosResponse>  ListaLancamentos { get; set; }
    }
}
