using Fluxo.Caixa.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxo.Caixa.Domain.Models
{
    public class TipoPagamento : BaseLancamentos
    {
        [Key]
        public int IdTipoPagamento { get; set; }
        public string? Descricao { get; set; }

        public virtual ICollection<Lancamentos> ListaLancamentos { get; set; } = new List<Lancamentos>();

        public virtual ICollection<RelatorioDiario> ListaRelatorioDiarios { get; set; } = new List<RelatorioDiario>();
    }
}
