using Microsoft.Extensions.Configuration;
using QuadrosNBR.Aplicacao.Services.Authentication.TokenDTO;
using QuadrosNBR.Aplicacao.Services.Authorization.ApplicationUserIdentityDTO;

namespace QuadrosNBR.Aplicacao.Services.Authentication.Repository;

public interface IAuthenticationRepository
{
    ApplicationUserTokenDto GenerateToken(ApplicationUserDto applicationUserDtoo, IConfiguration configuration);
}
