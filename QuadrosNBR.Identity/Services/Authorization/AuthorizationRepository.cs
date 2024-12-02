using Microsoft.AspNetCore.Identity;
using QuadrosNBR.Aplicacao.Services.Authorization.ApplicationUserIdentityDTO;
using QuadrosNBR.Aplicacao.Services.Authorization.Repository;
using QuadrosNBR.Dominio.Identities;

namespace QuadrosNBR.Identity.Services.Authorization;

public class AuthorizationRepository : IAuthorizationRepository
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthorizationRepository(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ApplicationUser> Login(ApplicationUserDto applicationUserDto)
    {
        return await _userManager.FindByNameAsync(applicationUserDto.Email);
    }

    public async Task<IdentityResult> Register(ApplicationUserDto applicationUserDto)
    {
        var user = new ApplicationUser
        {
            UserName = applicationUserDto.Email
        };

        return await _userManager.CreateAsync(user, applicationUserDto.Password);
    }

    public async Task<bool> CheckPasswords(ApplicationUser user, ApplicationUserDto applicationUserDto)
    {
        return await _userManager.CheckPasswordAsync(user, applicationUserDto.Password);
    }
}
