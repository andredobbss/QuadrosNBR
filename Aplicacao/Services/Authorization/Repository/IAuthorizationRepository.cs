using Microsoft.AspNetCore.Identity;
using QuadrosNBR.Aplicacao.Services.Authorization.ApplicationUserIdentityDTO;
using QuadrosNBR.Dominio.Identities;

namespace QuadrosNBR.Aplicacao.Services.Authorization.Repository;

public interface IAuthorizationRepository
{
    Task<IdentityResult> Register(ApplicationUserDto userDTO);
    Task<ApplicationUser> Login(ApplicationUserDto userDTO);
    Task<bool> CheckPasswords(ApplicationUser applicationUser, ApplicationUserDto userDTO);
}
