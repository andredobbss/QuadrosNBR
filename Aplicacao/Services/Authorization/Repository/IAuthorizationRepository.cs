using Microsoft.AspNetCore.Identity;
using QuadrosNBR.Aplicacao.Services.Authorization.ApplicationUserIdentityDTO;

namespace QuadrosNBR.Aplicacao.Services.Authorization.Repository;

public interface IAuthorizationRepository
{
    Task<IdentityResult> Register(ApplicationUserDto userDTO);
    Task<IdentityUser> Login(ApplicationUserDto userDTO);
    Task<bool> CheckPasswords(IdentityUser applicationUser, ApplicationUserDto userDTO);
}
