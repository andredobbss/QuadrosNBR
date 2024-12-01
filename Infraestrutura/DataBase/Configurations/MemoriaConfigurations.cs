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

        builder.Property(x => x.Dependencia)
            .HasColumnName("Dependencia")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.NomeDaLayer)
            .IsRequired()
            .HasColumnName("NomeDaLayer")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.Area)
            .IsRequired()
            .HasColumnName("Area")
            .HasColumnType("FLOAT");

        builder.Property(x => x.Ordenacao)
            .HasColumnName("Ordenacao")
            .HasColumnType("tinyint");

        builder.Property(x => x.Repeticao)
            .HasColumnName("Repeticao")
            .HasColumnType("tinyint");

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

        builder.Property(x => x.DecideDivisaoProporcional)
            .HasColumnName("DecideDivisaoProporcional")
            .HasColumnType("BIT")
            .HasDefaultValue(false);
       
        builder.Property(x => x.DecideAreaPadrao)
            .HasColumnName("DecideAreaPadrao")
            .HasColumnType("BIT")
            .HasDefaultValue(false);

        builder.Property(x => x.DecideAreaAcessoria)
            .HasColumnName("DecideAreaAcessoria")
            .HasColumnType("BIT")
            .HasDefaultValue(false);

        builder.Property(x => x.DecideAreaDoTerreno)
            .HasColumnName("DecideAreaDoTerreno")
            .HasColumnType("BIT")
            .HasDefaultValue(false);

        builder.Property(x => x.Observacao)
            .HasColumnName("Observacao")
            .HasColumnType("TEXT");

        builder.Property(x => x.AreaRealCobertaPadraoTotal)
            .HasColumnName("AreaRealCobertaPadraoTotal")
            .HasColumnType("FLOAT")
            .HasDefaultValue(0);

        builder.Property(x => x.AreaRealDiferenteDaCobertaPadraoTotal)
            .HasColumnName("AreaRealDiferenteDaCobertaPadraoTotal")
            .HasColumnType("FLOAT")
            .HasDefaultValue(0);

        builder.Property(x => x.AreaEquivalenteDiferenteDaCobertaPadraoTotal)
            .HasColumnName("AreaEquivalenteDiferenteDaCobertaPadraoTotal")
            .HasColumnType("FLOAT")
            .HasDefaultValue(0);

        builder.Property(x => x.AreaEquivalenteDiferenteDaCobertaPadraoUnitaria)
            .HasColumnName("AreaEquivalenteDiferenteDaCobertaPadraoUnitaria")
            .HasColumnType("FLOAT")
            .HasDefaultValue(0);

        builder.Property(x => x.AreaDoTerreno)
            .HasColumnName("AreaDoTerreno")
            .HasColumnType("FLOAT")
            .HasDefaultValue(0);

        // Indices
        builder.HasIndex(x => x.ProjetoId, "IX_Memoria_ProjetoId");
        builder.HasIndex(x => x.TenantId, "IX_Memoria_TenantId");
        builder.HasIndex(x => x.Ordenacao, "IX_Memoria_Ordenacao");
        builder.HasIndex(x => x.Uso, "IX_Memoria_Uso");
        builder.HasIndex(x => x.DecideDivisaoProporcional, "IX_Memoria_DecideDivisaoProporcional");
        builder.HasIndex(x => x.DecideAreaAcessoria, "IX_Memoria_DecideAreaAcessoria");
        builder.HasIndex(x => x.DecideAreaDoTerreno, "IX_Memoria_DecideAreaDoTerreno");

    }
}
