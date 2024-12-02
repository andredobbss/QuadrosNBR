using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using QuadrosNBR.Bootstrap;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


//configura contairner--------------------------------------------------------------------------------


string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
string? connectioIdentity = builder.Configuration.GetConnectionString("DefaultConnectionIdentity");

DependencesInjections.Dependens(builder.Services, connection, connectioIdentity);
//----------------------------------------------------------------------------------------------------


builder.Services.AddSwaggerGen(c =>
{

    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "QuadrosNBR.Api",
        Description = "Uma API Web ASP.NET Core para gerir itens dos QuadrosNBR",
        TermsOfService = new Uri(""),
        Contact = new OpenApiContact
        {
            Name = "Contato",
            Url = new Uri("")
        },
        License = new OpenApiLicense
        {
            Name = "Licença",
            Url = new Uri("")
        }
    });


    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Baearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Header de autorização JWT usando o esquema Bearer, \r\n\r\nInforme 'Bearer' [espaço] e o seu Token, \r\n\r\nExemplo: \'Bearer 123456abcdefg\'",
    });


    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
          new OpenApiSecurityScheme
          {
             Reference = new OpenApiReference
             {
                  Type = ReferenceType.SecurityScheme,
                  Id = "Bearer"
             }
          },
           new string[] {}
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme).
    AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidAudience = builder.Configuration["TokenConfiguration:Audience"],
        ValidIssuer = builder.Configuration["TokenConfiguration:Issuer"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<TenantMiddleware>();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapControllers();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
