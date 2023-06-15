using Fluxo.Caixa.Domain.Models;
using Fluxo.Caixa.Infra.Resource.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxo.Caixa.Infra.Resource
{
    public class CadastroLancamentoRequest 
    {

        /// <summary>
        /// ID da Empresa 
        /// </summary>
        [Required(ErrorMessage = "ID da Empresa é obrigatório")]
        [RegularExpression("^(1|2|3)$", ErrorMessage = "O valor do ID da Empresa deve ser 1 , 2  ou 3 .")]
        public int IdEmpresa { get; set; }

        /// <summary>
        /// Tipo de Pamento
        /// 1 = Debito
        /// 2 = Credito
        /// </summary>
        [Required(ErrorMessage = "IdTipoPagamento é obrigatório")]
        [RegularExpression("^(1|2)$", ErrorMessage = "O valor do IdTipoPagamento deve ser 1 débito ou 2 Crédito")]
        public int IdTipoPagamento { get; set; }

        /// <summary>
        /// Descrição do intem Lançado
        /// </summary>
        [Required(ErrorMessage = "Descricao é obrigatório")]
        public string? Descricao { get; set; }

        /// <summary>
        /// Valor do Item Lançado
        /// </summary>
        [Required(ErrorMessage = "Valor é obrigatório e deve ser passado com ponto e nao com virgula")]
        public decimal Valor { get; set; }

    }
}
