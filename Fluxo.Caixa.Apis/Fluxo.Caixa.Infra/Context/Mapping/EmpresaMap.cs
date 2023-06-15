using Fluxo.Caixa.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fluxo.Caixa.Infra.Context.Mapping
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        void IEntityTypeConfiguration<Empresa>.Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("TB_EMPRESA");

            builder.HasKey(k => k.IdEmpresa);
            builder.Property(x => x.IdEmpresa)
                .HasColumnName("id_empresa").IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
                  .HasColumnName("nome");

            builder.Property(p => p.CNPJ)
                  .HasColumnName("cnpj");

            builder.Property(p => p.GrupoEmpresarial)
                  .HasColumnName("grupo_empresarial");

            builder.Property(e => e.Create_at)
                .HasColumnType("datetime")
                .HasColumnName("create_at");

            builder.Property(e => e.Update_at)
                .HasColumnType("datetime")
                .HasColumnName("update_at");

            builder.HasMany(p => p.ListaLancamentos)
                     .WithOne(d => d.Empresa)
                     .HasForeignKey(d => d.IdEmpresa)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_TB_LANCAMENTO_TB_EMPRESA");
        }

    }
}
