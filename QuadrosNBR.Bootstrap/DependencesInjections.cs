using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuadrosNBR.Aplicacao.IUnitOfWork;
using QuadrosNBR.Aplicacao.Mappings;
using QuadrosNBR.Aplicacao.Services.Authentication.Repository;
using QuadrosNBR.Aplicacao.Services.Authorization.Repository;
using QuadrosNBR.Dominio.Entities;
using QuadrosNBR.Dominio.Identities;
using QuadrosNBR.Dominio.Validations;
using QuadrosNBR.Identity.Database.Context;
using QuadrosNBR.Identity.Services.Authentication;
using QuadrosNBR.Identity.Services.Authorization;
using QuadrosNBR.Infraestrutura.DataBase.Context;
using QuadrosNBR.Infraestrutura.UnitOfWork;

namespace QuadrosNBR.Bootstrap;

public static class DependencesInjections
{
    public static void Dependens(IServiceCollection services,
                                string? connection,
                                string? connectionIdentity)
    {
        //configura DbContext-----------------------------------------------------------


        //services.AddDbContext<AppDbContext>(options =>
        // options.UseSqlServer(connection, b =>
        //       b.MigrationsAssembly("QuadrosNBR.Infraestrutura")));


        //configura IdentityDbContext----------------------------------------------------

        //services.AddDbContext<AppDbContextIdentity>(options =>
        //options.UseSqlServer(connectionIdentity, b =>
        //      b.MigrationsAssembly("QuadrosNBR.Identity")));


        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        options.SignIn.RequireConfirmedAccount = true)
               .AddEntityFrameworkStores<AppDbContextIdentity>();


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

        services.AddScoped<IValidator<InformacoesPreliminaresDominio>, InformacoesPreliminaresValidator>();
        services.AddScoped<IValidator<MemoriaDominio>, MemoriaValidator>();
        services.AddScoped<IValidator<PavimentoDominio>, PavimentoValidator>();



        services.AddScoped<DbContext, AppDbContext>();
        services.AddScoped<IdentityDbContext<ApplicationUser>, AppDbContextIdentity>();

        services.AddScoped<IAuthorizationRepository, AuthorizationRepository>();
        services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

    }
}
