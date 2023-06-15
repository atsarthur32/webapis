using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxo.Caixa.Domain.Response
{
    public class RelatorioDiarioResponse
    {
        public string? NomeEmpresa { get; set; }
        public string? TipoPagamento { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataFechamento { get; set; }
    }
}
