using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxo.Caixa.Infra.Resource.Base
{
    public class ResourceBase
    {
        /// <summary>
        /// Indicador de cliente consultado com sucesso.
        /// </summary>
        public bool Sucesso { get; set; }

        /// <summary>
        /// Mensagem de retorno do Serviço
        /// </summary>
        public string? Mensagem { get; set; }
    }
}
