using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuadrosNBR.Aplicacao.IUnitOfWork;
using QuadrosNBR.Infraestrutura.DataBase.Contextos;
using QuadrosNBR.Infraestrutura.DataBase.Identities;
using QuadrosNBR.Infraestrutura.UnitOfWork;

namespace QuadrosNBR.Bootstrap;

public static class DependencesInjections
{
    public static void Dependens(IServiceCollection services,
                                string? connection)
    {
        //configura DbContext-----------------------------------------------------------

        //services.AddScoped<AppDbContext>(provider =>
        //{
        //    var httpContext = provider.GetRequiredService<IHttpContextAccessor>().HttpContext;
        //    var tenantId = (Guid?)httpContext?.Items["TenantId"] ?? throw new Exception("Tenant not found!");

        //    var options = provider.GetRequiredService<DbContextOptions<AppDbContext>>();
        //    return new AppDbContext(options, tenantId);
        //});


        services.AddDbContext<AppDbContext>(options =>
         options.UseSqlServer(connection, b =>
               b.MigrationsAssembly("QuadrosNBR.Infraestrutura")));

        //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        //configura IdentityDbContext----------------------------------------------------

        //services.AddDbContext<AppDbContextIdentity>(options =>
        // options.UseSqlServer(connectionIdentity, b =>
        //       b.MigrationsAssembly("QuadrosNBR.Infraestrutura")));
        //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));




        //services.AddDbContext<AppDbContext>((provider, options) =>
        //{
        //    var httpContext = provider.GetRequiredService<IHttpContextAccessor>().HttpContext;
        //    var tenantId = (Guid?)httpContext?.Items["TenantId"] ?? throw new Exception("Tenant not found!");

        //    options.UseSqlServer(connection, b =>
        //       b.MigrationsAssembly("QuadrosNBR.Infraestrutura"));

        //    return new AppDbContext(options, tenantId);
        //});




        services.AddIdentityCore<ApplicationUser>(options =>
        options.SignIn.RequireConfirmedAccount = true)
               .AddEntityFrameworkStores<AppDbContext>();


        services.Configure<IdentityOptions>(options =>
        {
            // Default Password settings.
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;
            options.User.RequireUniqueEmail = true;
        });

        services.Configure<PasswordHasherOptions>(option =>
        {
            option.IterationCount = 12000;
        });
        //--------------------------------------------------------------------------------


        //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

    }
}
