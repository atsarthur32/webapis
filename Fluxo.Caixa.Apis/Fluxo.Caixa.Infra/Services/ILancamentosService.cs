using Fluxo.Caixa.Domain.Models;
using Fluxo.Caixa.Infra.Resource;

namespace Fluxo.Caixa.Infra.Services
{
    public interface ILancamentosService
    {
        Task<CadastroLancamentoResponse> CadastrarLancamento(Lancamentos lancamento);

        Task<ConsultaLancamentoResponse> ConsultarLancamento(Lancamentos lancamento);
    }
}
