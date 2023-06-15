using Fluxo.Caixa.Domain.Models;
using Fluxo.Caixa.Domain.Response;
using Fluxo.Caixa.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace Fluxo.Caixa.Infra.Context.Repository
{
    public class LancamentoRepository : BaseRepository, ILancamentoRepository
    {
        public LancamentoRepository(ApiLancamentoSqlDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Lancamentos lancamentos)
        {
            lancamentos.Create_at = DateTime.Now;
            lancamentos.DataLancamento = DateTime.Now;

            await _context.Lancamentos.AddAsync(lancamentos);
        }

        public async Task<List<LancamentosResponse>> ConsultarLancamentos(Lancamentos lancamentos)
        {
            var lancamemtoResponse = new List<LancamentosResponse>();

            var query = _context.Lancamentos
                 .Include(l => l.Empresa)
                 .Include(l => l.TipoPagamento)
                 .Where(_ => _.IdEmpresa == lancamentos.IdEmpresa && _.DataLancamento.Date == lancamentos.DataLancamento.Date);

            if (lancamentos.IdTipoPagamento > 0)
            {
                query = query.Where(_ => _.IdTipoPagamento == lancamentos.IdTipoPagamento);
            }

            var resultado = query.ToList();

            if (resultado.Any())
            {
                foreach (var item in resultado)
                {
                    lancamemtoResponse.Add(new LancamentosResponse
                    {
                        Descricao = item.Descricao,
                        Empresa = item.Empresa?.Nome,
                        IdLancamento = item.IdLancamento,
                        TipoPagamento = item.TipoPagamento?.Descricao,
                        Valor = item.Valor
                    });
                }

                return lancamemtoResponse;
            }


            return new List<LancamentosResponse>();
        }
    }
}
