using Fluxo.Caixa.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fluxo.Caixa.Infra.Context.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiLancamentoSqlDbContext _context;

        public UnitOfWork(ApiLancamentoSqlDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
