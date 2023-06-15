using Fluxo.Caixa.Domain.Models;
using Fluxo.Caixa.Infra.Context.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fluxo.Caixa.Infra.Context
{
    public class ApiLancamentoSqlDbContext : DbContext
    {
        public ApiLancamentoSqlDbContext(DbContextOptions<ApiLancamentoSqlDbContext> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var hostBuilder = new HostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    config.AddJsonFile("appsettings.json");
                })
                .Build();

            var configuration = hostBuilder.Services.GetRequiredService<IConfiguration>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Empresa> Empresas { get; set; }
        
        public DbSet<TipoPagamento> TiposPagamento { get; set; }
        
        public DbSet<Lancamentos> Lancamentos { get; set; }
        
        public DbSet<RelatorioDiario> RelatoriosDiarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LancamentosMap());
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new TipoPagamentoMap());
            modelBuilder.ApplyConfiguration(new RelatorioDiarioMap());
        }
    }

}
