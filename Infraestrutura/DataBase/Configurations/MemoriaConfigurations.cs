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
    }
}
