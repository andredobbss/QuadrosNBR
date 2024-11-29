using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuadrosNBR.Aplicacao.IUnitOfWork;
using QuadrosNBR.Aplicacao.Mappings;
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


        services.AddDbContext<AppDbContext>(options =>
         options.UseSqlServer(connection, b =>
               b.MigrationsAssembly("QuadrosNBR.Infraestrutura")));


        //configura IdentityDbContext----------------------------------------------------

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



        //configura Automapper-------------------------------------------------------------

        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });
        IMapper mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);
        //--------------------------------------------------------------------------------




        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

    }
}
