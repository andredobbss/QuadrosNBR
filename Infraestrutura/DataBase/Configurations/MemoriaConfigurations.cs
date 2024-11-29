using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuadrosNBR.Dominio.Entities;

namespace QuadrosNBR.Infraestrutura.DataBase.Configurations
{
    public class MemoriaConfigurations : IEntityTypeConfiguration<MemoriaDominio>
    {
        public void Configure(EntityTypeBuilder<MemoriaDominio> builder)
        {
            
        }
    }
}
