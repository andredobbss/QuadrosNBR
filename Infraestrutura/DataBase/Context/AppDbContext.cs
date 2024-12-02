using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QuadrosNBR.Aplicacao.Extensions;
using QuadrosNBR.Dominio.Entities;
using QuadrosNBR.Infraestrutura.DataBase.Configurations;

namespace QuadrosNBR.Infraestrutura.DataBase.Context;

public class AppDbContext : DbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    Guid tenantId;
    public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
        tenantId = _httpContextAccessor.HttpContext.User.TenantId();
    }

    public AppDbContext() { }
 

    public AppDbContext(DbContextOptions options) : base(options) { }


    public DbSet<InformacoesPreliminaresDominio>? InformacoesPreliminares { get; set; }
    public DbSet<MemoriaDominio>?  Memorias { get; set; }
    public DbSet<PavimentoDominio>? Pavimentos { get; set; }
   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new InformacoesPreliminaresConfigurations());
        modelBuilder.ApplyConfiguration(new MemoriaConfigurations());
        modelBuilder.ApplyConfiguration(new PavimentoConfigurations());   

        modelBuilder.Entity<InformacoesPreliminaresDominio>().HasQueryFilter(x => x.TenantId == tenantId);
        modelBuilder.Entity<MemoriaDominio>().HasQueryFilter(x => x.TenantId == tenantId);
        modelBuilder.Entity<PavimentoDominio>().HasQueryFilter(x => x.TenantId == tenantId);

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer(@"Server=DESKTOP-SQ9UAB9\MSSQL_DEV;Database=QuadrosNbr;User ID=sa;Password=Dobbss149283; Trusted_Connection=False; TrustServerCertificate=True;");
    }
}
