using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuadrosNBR.Aplicacao.Extensions;
using QuadrosNBR.Dominio.Identities;

namespace QuadrosNBR.Identity.Database.Context;

public class AppDbContextIdentity : IdentityDbContext<ApplicationUser>
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    Guid tenantId;
    public AppDbContextIdentity(DbContextOptions<AppDbContextIdentity> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
        tenantId = _httpContextAccessor.HttpContext.User.TenantId();
    }

    public AppDbContextIdentity() { }

    public AppDbContextIdentity(DbContextOptions options) : base(options) { }

    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<Project> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Tenant>()
            .HasMany(t => t.Projects)
            .WithOne(p => p.Tenant)
            .HasForeignKey(p => p.TenantId);


        modelBuilder.Entity<Tenant>()
            .HasMany(t => t.Users)
            .WithOne(u => u.Tenant)
            .HasForeignKey(u => u.TenantId);


        modelBuilder.Entity<Project>().HasQueryFilter(p => p.TenantId == tenantId);
        modelBuilder.Entity<ApplicationUser>().HasQueryFilter(u => u.TenantId == tenantId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer(@"Server=DESKTOP-SQ9UAB9\MSSQL_DEV;Database=QuadrosNbrIdentity;User ID=sa;Password=Dobbss149283;Trusted_Connection=False;TrustServerCertificate=True;");
    }
}
