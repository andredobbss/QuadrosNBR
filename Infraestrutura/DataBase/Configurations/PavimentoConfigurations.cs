using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuadrosNBR.Dominio.Entities;

namespace QuadrosNBR.Infraestrutura.DataBase.Configurations;

public class PavimentoConfigurations : IEntityTypeConfiguration<PavimentoDominio>
{
    public void Configure(EntityTypeBuilder<PavimentoDominio> builder)
    {
        builder.ToTable("Pavimento");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier");

        builder.Property(x => x.ProjetoId)
            .IsRequired()
            .HasColumnName("ProjetoId")
            .HasColumnType("uniqueidentifier");

        builder.Property(x => x.TenantId)
            .IsRequired()
            .HasColumnName("TenantId")
            .HasColumnType("uniqueidentifier");

        builder.Property(x => x.Descricao)
            .IsRequired()
            .HasColumnName("Descricao")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.Repeticao)
            .IsRequired()
            .HasColumnName("Repeticao")
            .HasColumnType("tinyint");

        builder.Property(x => x.Ordenacao)
            .IsRequired()
            .HasColumnName("Ordenacao")
            .HasColumnType("tinyint");
         

        // Indices
        builder.HasIndex(x => x.ProjetoId, "IX_Pavimento_ProjetoId");
        builder.HasIndex(x => x.TenantId, "IX_Pavimento_TenantId");
        builder.HasIndex(x => x.Ordenacao, "IX_Pavimento_Ordenacao");
        
    }
}
