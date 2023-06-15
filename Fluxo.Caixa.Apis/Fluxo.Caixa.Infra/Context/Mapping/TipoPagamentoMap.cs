using Fluxo.Caixa.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fluxo.Caixa.Infra.Context.Mapping
{
    public class TipoPagamentoMap : IEntityTypeConfiguration<TipoPagamento>
    {
        void IEntityTypeConfiguration<TipoPagamento>.Configure(EntityTypeBuilder<TipoPagamento> builder)
        {
            builder.ToTable("TB_TIPO_PAGAMENTO");

            builder.HasKey(k => k.IdTipoPagamento);
            builder.Property(x => x.IdTipoPagamento)
                .HasColumnName("id_tipo_pagamento").IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Descricao)
                  .HasColumnName("descricao");

            builder.Property(e => e.Create_at)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at");

            builder.Property(e => e.Update_at)
                    .HasColumnType("datetime")
                    .HasColumnName("update_at");

            builder.HasMany(p => p.ListaLancamentos)
                     .WithOne(d => d.TipoPagamento)
                     .HasForeignKey(d => d.IdTipoPagamento)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_TB_LANCAMENTO_TB_TIPO_PAGAMENTO");

        }
    }
}
