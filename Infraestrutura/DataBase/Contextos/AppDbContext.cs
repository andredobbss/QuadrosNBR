using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuadrosNBR.Dominio.Entities;
using QuadrosNBR.Infraestrutura.DataBase.Configuracoes;
using QuadrosNBR.Infraestrutura.DataBase.Identities;
using QuadrosNBR.Infraestrutura.Extensions;

namespace QuadrosNBR.Infraestrutura.DataBase.Contextos;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }


    public DbSet<Tenant>? Tenants { get; set; }
    public DbSet<Project>? Projects { get; set; }
    public DbSet<InformacoesPreliminaresDominio>? InformacoesPreliminares { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new InformacoesPreliminaresConfiguracoes());
        modelBuilder.ApplyConfiguration(new TenantConfiguracoes());

        //Guid tenantId = Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "TenantId").ToString());

        Guid tenantId = _httpContextAccessor.HttpContext.User.TenantId();

        // Adiciona filtros globais para Tenant nas entidades relevantes
        modelBuilder.Entity<Project>().HasQueryFilter(x => x.TenantId == tenantId);
        modelBuilder.Entity<ApplicationUser>().HasQueryFilter(x => x.TenantId == tenantId);
        modelBuilder.Entity<InformacoesPreliminaresDominio>().HasQueryFilter(x => x.TenantId == tenantId);

    }
}
