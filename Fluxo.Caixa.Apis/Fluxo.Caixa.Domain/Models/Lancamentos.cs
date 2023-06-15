using Fluxo.Caixa.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;


namespace Fluxo.Caixa.Domain.Models
{
    public class Lancamentos
    {
        /// <summary>
        /// ID do Lançamento - Auto Incrementado no Banco
        /// </summary>
        [Key]
        public int IdLancamento { get; set; }

        /// <summary>
        /// ID da Empresa
        /// </summary>
        public int IdEmpresa { get; set; }
        /// <summary>
        /// Tipo de Pamento
        /// 1 = Debito
        /// 2 = Credito
        /// </summary>
        public int IdTipoPagamento { get; set; }
        /// <summary>
        /// Descrição do item Lançado
        /// </summary>
        public string? Descricao { get; set; }

        /// <summary>
        /// Valor do Item Lançado
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// Data de Consulta
        /// </summary>
        public DateTime DataLancamento { get; set; }

        /// <summary>
        /// Data de criação do Registro
        /// </summary>
        public DateTime Create_at { get; set; }

        ///// <summary>
        /// Todo Lançamento tem uma Empresa
        /// </summary>
        public Empresa? Empresa { get; set; }

        /// <summary>
        /// Toda Empresa tem um Tipo de Pagamento
        /// </summary>
        public TipoPagamento? TipoPagamento { get; set; }
    }
}
