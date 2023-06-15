using Fluxo.Caixa.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Fluxo.Caixa.Infra.Context.Mapping
{
    public class LancamentosMap : IEntityTypeConfiguration<Lancamentos>
    {
        void IEntityTypeConfiguration<Lancamentos>.Configure(EntityTypeBuilder<Lancamentos> builder)
        {
            builder.ToTable("TB_LANCAMENTO");

            builder.HasKey(k => k.IdLancamento);
            builder.Property(x => x.IdLancamento)
                .HasColumnName("id_lancamento").IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.IdEmpresa)
                  .HasColumnName("id_empresa");

            builder.Property(p => p.IdTipoPagamento)
                  .HasColumnName("id_tipo_pagamento");

            builder.Property(p => p.Descricao)
                  .HasColumnName("descricao");

            builder.Property(e => e.Valor)
                  .HasColumnType("decimal(18, 2)")
                  .HasColumnName("valor");

            builder.Property(e => e.DataLancamento)
                    .HasColumnType("datetime")
                    .HasColumnName("update_at");

            builder.Property(e => e.Create_at)
                .HasColumnType("datetime")
                .HasColumnName("create_at");

            builder.HasOne(d => d.Empresa)
                  .WithMany(p => p.ListaLancamentos)
                  .HasForeignKey(d => d.IdEmpresa)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_TB_LANCAMENTO_TB_EMPRESA");

            builder.HasOne(d => d.TipoPagamento)
                  .WithMany(p => p.ListaLancamentos)
                  .HasForeignKey(d => d.IdTipoPagamento)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_TB_LANCAMENTO_TB_TIPO_PAGAMENTO");
        }
    }
}
