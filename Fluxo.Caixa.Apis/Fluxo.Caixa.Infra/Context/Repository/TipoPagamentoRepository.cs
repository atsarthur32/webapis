using Fluxo.Caixa.Domain.Models;
using Fluxo.Caixa.Domain.Response;
using Fluxo.Caixa.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxo.Caixa.Infra.Context.Repository
{
    public class TipoPagamentoRepository : BaseRepository, ITipoPagamentoRepository
    {
        public TipoPagamentoRepository(ApiLancamentoSqlDbContext context) : base(context)
        {
        }
        public List<TipoPagamento> ConsultarTodosTiposPagamento()
        {
            var tipoPagamento = new List<TipoPagamento>();

            var resultado = _context.TiposPagamento.ToList();

            if (resultado.Any())
            {
                foreach (var item in resultado)
                {
                    tipoPagamento.Add(new TipoPagamento
                    {
                        Descricao= item.Descricao,
                    });
                }

                return tipoPagamento;
            }

            return new List<TipoPagamento>();
        }
    }
}
