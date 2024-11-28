using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuadrosNBR.Dominio.Entities;
using QuadrosNBR.Infraestrutura.DataBase.Configuracoes;
using QuadrosNBR.Infraestrutura.DataBase.Identities;

namespace QuadrosNBR.Infraestrutura.DataBase.Contextos;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    private readonly Guid _currentTenantId;

    private readonly IHttpContextAccessor _httpContextAccessor;
    public AppDbContext(DbContextOptions<AppDbContext> options, Guid currentTenantId, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _currentTenantId = currentTenantId;
        _httpContextAccessor = httpContextAccessor;
    }


    public DbSet<Tenant>? Tenants { get; set; }
    public DbSet<Project>? Projects { get; set; }
    public DbSet<InformacoesPreliminaresDominio>? InformacoesPreliminares { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new InformacoesPreliminaresConfiguracoes());
        modelBuilder.ApplyConfiguration(new TenantConfiguracoes());

        var values = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "TenantId");
       
        // Adiciona filtros globais para Tenant nas entidades relevantes
        modelBuilder.Entity<Project>().HasQueryFilter(p => p.TenantId == _currentTenantId);
        modelBuilder.Entity<ApplicationUser>().HasQueryFilter(u => u.TenantId == _currentTenantId);
        modelBuilder.Entity<InformacoesPreliminaresDominio>().HasQueryFilter(u => u.TenantId == _currentTenantId);

    }
}
