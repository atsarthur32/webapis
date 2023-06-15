using Fluxo.Caixa.Domain.Models;
using Fluxo.Caixa.Infra.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxo.Caixa.Infra.Services
{
    public interface IRelatorioDiarioService
    {

        Task<ConsultaRelatorioDiarioResponse> ConsultaRelatorioDiario(RelatorioDiario lancamento);
    }
}
