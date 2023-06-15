using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxo.Caixa.Infra.Resource
{
    public class ErroResponse
    {
        /// <summary>
        /// Status do processamento da requisição
        /// </summary>
        public bool Sucesso => false;

        /// <summary>
        /// Mensagens de erros apresentadas
        /// </summary>
        public List<string> Mensagens { get; private set; }

        public ErroResponse(string? mensagem = null, List<string>? mensagens = null)
        {
            this.Mensagens = new List<string>();

#pragma warning disable CS8604 // Possível argumento de referência nula.
            if (!string.IsNullOrWhiteSpace(mensagem))
            {
                this.Mensagens.Add(mensagem);
            }
            else if (mensagens.Any())
            {
                this.Mensagens.Add(mensagem);
            }
#pragma warning restore CS8604 // Possível argumento de referência nula.
        }
    }
}
