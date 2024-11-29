using Microsoft.AspNetCore.Identity;
using QuadrosNBR.Aplicacao.Services.Authorization.ApplicationUserIdentityDTO;
using QuadrosNBR.Aplicacao.Services.Authorization.Repository;

namespace QuadrosNBR.Infraestrutura.Services.Authorization.Repository;

public class AuthorizationRepository : IAuthorizationRepository
{
    private readonly UserManager<IdentityUser> _userManager;

    public AuthorizationRepository(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityUser> Login(ApplicationUserDto applicationUserDto)
    {
        return await _userManager.FindByNameAsync(applicationUserDto.Email);
    }

    public async Task<IdentityResult> Register(ApplicationUserDto applicationUserDto)
    {
        var user = new IdentityUser
        {
            UserName = applicationUserDto.Email
        };

        return await _userManager.CreateAsync(user, applicationUserDto.Password);
    }

    public async Task<bool> CheckPasswords(IdentityUser user, ApplicationUserDto applicationUserDto)
    {
        return await _userManager.CheckPasswordAsync(user, applicationUserDto.Password);
    }

}
