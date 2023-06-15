using Fluxo.Caixa.Domain.Models;
using Fluxo.Caixa.Domain.Response;

namespace Fluxo.Caixa.Infra.Repository
{
    public interface IRelatorioDiarioRepository
    {
        Task AddAsync(RelatorioDiario relatorioDiario);

        Task<List<RelatorioDiarioResponse>> ConsultaRelatorioDiario(RelatorioDiario relatorioDiario);
    }
}
