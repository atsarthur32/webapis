using Fluxo.Caixa.Domain.Models;
using Fluxo.Caixa.Domain.Response;

namespace Fluxo.Caixa.Infra.Repository
{
    public interface ILancamentoRepository
    {
        Task AddAsync(Lancamentos lancamentos);
        Task<List<LancamentosResponse>> ConsultarLancamentos(Lancamentos model);
    }
}
