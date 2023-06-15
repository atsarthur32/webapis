using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxo.Caixa.Domain.Response
{
    public class LancamentosResponse
    {
        public int IdLancamento { get; set; }

        /// <summary>
        /// Nome da empresa consultada
        /// </summary>
        public string? Empresa { get; set; }
        /// <summary>
        /// Tipo de Pamento
        /// Debito
        /// Credito
        /// </summary>
        public string?  TipoPagamento { get; set; }
        /// <summary>
        /// Descrição do item Lançado
        /// </summary>
        public string? Descricao { get; set; }

        /// <summary>
        /// Valor do Item Lançado
        /// </summary>
        public decimal Valor { get; set; }
    }
}
