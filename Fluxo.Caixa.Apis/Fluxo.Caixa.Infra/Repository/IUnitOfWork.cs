using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxo.Caixa.Infra.Repository
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
