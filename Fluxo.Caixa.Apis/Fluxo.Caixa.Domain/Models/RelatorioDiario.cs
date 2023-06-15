using Fluxo.Caixa.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxo.Caixa.Domain.Models
{
    public class RelatorioDiario : BaseLancamentos
    {
        [Key]
        public int IdRelatorioDiario { get; set; }
        public int IdEmpresa { get; set; }
        public int IdTipoPagamento { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataFechamento { get; set; }

        public Empresa? Empresa { get; set; }
        public TipoPagamento? TipoPagamento { get; set; }
    }
}
