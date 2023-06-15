using Fluxo.Caixa.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxo.Caixa.Infra.Repository
{
    public interface ITipoPagamentoRepository
    {
        List<TipoPagamento> ConsultarTodosTiposPagamento();
    }
}
