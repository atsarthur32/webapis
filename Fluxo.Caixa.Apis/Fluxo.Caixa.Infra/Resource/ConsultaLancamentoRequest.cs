using System.ComponentModel.DataAnnotations;

namespace Fluxo.Caixa.Infra.Resource
{
    public class ConsultaLancamentoRequest
    {
        /// <summary>
        /// ID da Empresa ( 1 , 2 , 3 )
        /// </summary>
        [Required(ErrorMessage = "ID da Empresa é obrigatório")]
        [RegularExpression("^(1|2|3)$", ErrorMessage = "O valor do ID da Empresa deve ser 1 , 2  ou 3 .")]
        public int IdEmpresa { get; set; }

        /// <summary>
        /// Tipo de Pamento
        /// 1 = Debito
        /// 2 = Credito
        /// </summary>
        [RegularExpression("^(0|1|2)$", ErrorMessage = "O valor do IdTipoPagamento deve ser 1 débito ou 2 Crédito e 0 RETORNA TUDO")]
        public int? IdTipoPagamento { get; set; }

        /// <summary>
        /// Data de Consulta
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

    }
}
