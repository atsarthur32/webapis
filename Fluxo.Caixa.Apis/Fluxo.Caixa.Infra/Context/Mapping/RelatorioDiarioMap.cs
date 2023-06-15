using Fluxo.Caixa.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxo.Caixa.Infra.Context.Mapping
{
    public class RelatorioDiarioMap : IEntityTypeConfiguration<RelatorioDiario>
    {
        void IEntityTypeConfiguration<RelatorioDiario>.Configure(EntityTypeBuilder<RelatorioDiario> builder)
        {

            builder.ToTable("TB_RELATORIO_DIARIO");

            builder.HasKey(k => k.IdRelatorioDiario);
            builder.Property(x => x.IdRelatorioDiario)
                .HasColumnName("id_relatorio_diario").IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DataFechamento)
                .HasColumnType("datetime")
                .HasColumnName("data_fechamento");
           
            builder.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
         
            builder.Property(e => e.IdTipoPagamento).HasColumnName("id_tipo_pagamento");

            builder.Property(e => e.ValorTotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("valor_total");

            builder.Property(e => e.Create_at)
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            builder.Property(e => e.Update_at)
                .HasColumnType("datetime")
                .HasColumnName("update_at");

            builder.HasOne(d => d.Empresa).WithMany(p => p.ListaRelatorioDiarios)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_RELATORIO_DIARIO_TB_EMPRESA");

            builder.HasOne(d => d.TipoPagamento).WithMany(p => p.ListaRelatorioDiarios)
                .HasForeignKey(d => d.IdTipoPagamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_RELATORIO_DIARIO_TB_TIPO_PAGAMENTO");

        }
    }
}
