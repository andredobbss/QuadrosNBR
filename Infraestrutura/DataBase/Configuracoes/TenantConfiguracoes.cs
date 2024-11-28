using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuadrosNBR.Infraestrutura.DataBase.Identities;

namespace QuadrosNBR.Infraestrutura.DataBase.Configuracoes
{
    public class TenantConfiguracoes : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
          
            builder.HasKey(t => t.Id);

            // Configurar relação Tenant -> Projects
            builder
                .HasMany(t => t.Projects)
                .WithOne(p => p.Tenant)
                .HasForeignKey(p => p.TenantId);

            // Configurar relação Tenant -> Users
            builder
                .HasMany(t => t.Users)
                .WithOne(u => u.Tenant)
                .HasForeignKey(u => u.TenantId);

            // Configurações adicionais (índices, constraints)
            builder.HasIndex(t => t.RazaoSocial).IsUnique();
        }
    }
}
