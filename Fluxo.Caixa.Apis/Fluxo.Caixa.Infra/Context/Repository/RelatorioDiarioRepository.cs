using Fluxo.Caixa.Domain.Models;
using Fluxo.Caixa.Domain.Response;
using Fluxo.Caixa.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace Fluxo.Caixa.Infra.Context.Repository
{
    public class RelatorioDiarioRepository : BaseRepository, IRelatorioDiarioRepository
    {
        public RelatorioDiarioRepository(ApiLancamentoSqlDbContext context) : base(context)
        {
        }
        public async Task AddAsync(RelatorioDiario relatorioDiario)
        {
            relatorioDiario.Create_at = DateTime.Now;
            relatorioDiario.Update_at = DateTime.Now;

            await _context.RelatoriosDiarios.AddAsync(relatorioDiario);
        }

        public async Task<List<RelatorioDiarioResponse>> ConsultaRelatorioDiario(RelatorioDiario relatorioDiario)
        {
            var relatorioDiarioResponse = new List<RelatorioDiarioResponse>();

            var query = _context.RelatoriosDiarios
                 .Include(l => l.Empresa)
                 .Include(l => l.TipoPagamento)
                 .Where(_ => _.IdEmpresa == relatorioDiario.IdEmpresa && _.DataFechamento.Date == relatorioDiario.DataFechamento.Date);

            if (relatorioDiario.IdTipoPagamento > 0)
            {
                query = query.Where(_ => _.IdTipoPagamento == relatorioDiario.IdTipoPagamento);
            }

            var resultado = query.ToList();

            if (resultado.Any())
            {
                foreach (var item in resultado)
                {
                    relatorioDiarioResponse.Add(new RelatorioDiarioResponse
                    {
                        NomeEmpresa = item.Empresa?.Nome,
                        TipoPagamento = item.TipoPagamento?.Descricao,
                        ValorTotal = item.ValorTotal,
                        DataFechamento = item.DataFechamento,

                    });
                }

                return relatorioDiarioResponse;
            }

            return new List<RelatorioDiarioResponse>();
        }
    }
}
