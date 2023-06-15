using Fluxo.Caixa.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxo.Caixa.Domain.Models
{
    public class Empresa : BaseLancamentos
    {
        [Key]
        public int IdEmpresa { get; set; }
        public string? Nome { get; set; }
        public int CNPJ { get; set; }
        public string? GrupoEmpresarial { get; set; }

        public virtual ICollection<Lancamentos> ListaLancamentos { get; set; } = new List<Lancamentos>();

        public virtual ICollection<RelatorioDiario> ListaRelatorioDiarios { get; set; } = new List<RelatorioDiario>();

    }
}
