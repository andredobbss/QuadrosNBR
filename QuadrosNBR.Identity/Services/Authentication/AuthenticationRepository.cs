using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuadrosNBR.Aplicacao.Services.Authentication.Repository;
using QuadrosNBR.Aplicacao.Services.Authentication.TokenDTO;
using QuadrosNBR.Aplicacao.Services.Authorization.ApplicationUserIdentityDTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuadrosNBR.Identity.Services.Authentication;

public class AuthenticationRepository : IAuthenticationRepository
{
    public ApplicationUserTokenDto GenerateToken(ApplicationUserDto applicationUserDto, IConfiguration configuration)
    {

        // define delaraçoes do usuário
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.UniqueName, applicationUserDto.Email),
            new Claim("TenantId", applicationUserDto.TenantId.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        // gera uma chave com base no algoritmo simétrico
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

        // gera a assinatura digital do token usando o algoritmo Hmac e a chave privada
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // tempo de expiração do Token
        var expire = configuration["TokenConfiguration:ExpireHours"];
        var expiration = DateTime.UtcNow.AddHours(double.Parse(expire));

        // classe que representa o JWT e gera o Token
        JwtSecurityToken token = new JwtSecurityToken(
                                                      audience: configuration["TokenConfiguration:Audience"],
                                                      issuer: configuration["TokenConfiguration:Issuer"],
                                                      claims: claims,
                                                      expires: expiration,
                                                      signingCredentials: credentials);

        return new ApplicationUserTokenDto()
        {
            Authenticated = true,
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration,
            Message = "Transação efetuada com sucesso!"
        };
    }
}
