using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuadrosNBR.Infraestrutura.DataBase.Identities;

namespace QuadrosNBR.Infraestrutura.DataBase.Configurations;

public class ApplicationUserConfigurations : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("ApplicationUser");

        builder.HasOne(x => x.Tenant);

        builder.Property(x => x.TenantId)
            .IsRequired()
            .HasColumnName("TenantId")
            .HasColumnType("uniqueidentifier");

        builder.Property(x => x.Tenant)
            .IsRequired()
            .HasColumnName("Tenant")
            .HasColumnType("uniqueidentifier");

    }
}
