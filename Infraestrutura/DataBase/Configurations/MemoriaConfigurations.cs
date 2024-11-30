using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuadrosNBR.Dominio.Entities;

namespace QuadrosNBR.Infraestrutura.DataBase.Configurations;

public class MemoriaConfigurations : IEntityTypeConfiguration<MemoriaDominio>
{
    public void Configure(EntityTypeBuilder<MemoriaDominio> builder)
    {
        builder.ToTable("Memoria");

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

        builder.Property(x => x.NomeDaLayer)
            .IsRequired()
            .HasColumnName("NomeDaLayer")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.Area)
            .IsRequired()
            .HasColumnName("Area")
            .HasColumnType("FLOAT");

        builder.Property(x => x.Descricao)
            .HasColumnName("Descricao")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.Repeticao)
            .HasColumnName("Repeticao")
            .HasColumnType("SMALLINT");

        builder.Property(x => x.Unidade)
            .HasColumnName("Unidade")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.Pavimento)
            .HasColumnName("Pavimento")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.Uso)
            .HasColumnName("Uso")
            .HasColumnType("VARCHAR")
            .HasMaxLength(9);

        builder.Property(x => x.Coeficiente)
            .HasColumnName("Coeficiente")
            .HasColumnType("FLOAT");

        builder.Property(x => x.AreaCobertaAberta)
            .HasColumnName("AreaCobertaAberta")
            .HasColumnType("BIT");
       
        builder.Property(x => x.Proporcionalidade)
            .HasColumnName("Proporcionalidade")
            .HasColumnType("BIT");

        builder.Property(x => x.Acessoria)
            .HasColumnName("Acessoria")
            .HasColumnType("BIT");

        builder.Property(x => x.Observacao)
            .HasColumnName("Observacao")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(200);

        builder.Property(x => x.Terreno)
            .HasColumnName("Terreno")
            .HasColumnType("BIT");

        builder.Property(x => x.AreaCobertaPadrao)
            .HasColumnName("AreaCobertaPadrao")
            .HasColumnType("FLOAT");

        builder.Property(x => x.AreaDiferenteDaCobertaPadrao)
            .HasColumnName("AreaDiferenteDaCobertaPadrao")
            .HasColumnType("FLOAT");

        builder.Property(x => x.AreaEquivalenteDiferenteDaCobertaPadraoTotal)
            .HasColumnName("AreaEquivalenteDiferenteDaCobertaPadraoTotal")
            .HasColumnType("FLOAT");

        builder.Property(x => x.AreaEquivalenteDiferenteDaCobertaPadraoUnitaria)
            .HasColumnName("AreaEquivalenteDiferenteDaCobertaPadraoUnitaria")
            .HasColumnType("FLOAT");

        builder.Property(x => x.AreaCobertaPadrao1)
            .HasColumnName("AreaCobertaPadrao1")
            .HasColumnType("FLOAT");

        builder.Property(x => x.AreaDiferenteDaCobertaPadrao1)
            .HasColumnName("AreaDiferenteDaCobertaPadrao1")
            .HasColumnType("FLOAT");

        builder.Property(x => x.AreaEquivalenteDiferenteDaCobertaPadraoTotal1)
            .HasColumnName("AreaEquivalenteDiferenteDaCobertaPadraoTotal1")
            .HasColumnType("FLOAT");

        builder.Property(x => x.AreaEquivalenteDiferenteDaCobertaPadraoUnitaria1)
            .HasColumnName("AreaEquivalenteDiferenteDaCobertaPadraoUnitaria1")
            .HasColumnType("FLOAT");

        builder.Property(x => x.AreaAcessoria)
            .HasColumnName("AreaAcessoria")
            .HasColumnType("FLOAT");

        builder.Property(x => x.AreaDoTerreno)
            .HasColumnName("AreaDoTerreno")
            .HasColumnType("FLOAT");

        // Indices
        builder.HasIndex(x => x.ProjetoId, "IX_Memoria_ProjetoId");
        builder.HasIndex(x => x.TenantId, "IX_Memoria_TenantId");

    }
}
