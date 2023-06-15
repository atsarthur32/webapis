using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxo.Caixa.Infra.Context.Repository
{
    public abstract class BaseRepository
    {
        protected readonly ApiLancamentoSqlDbContext _context;
        public BaseRepository(ApiLancamentoSqlDbContext context)
        {
            _context = context;
        }
    }
}
