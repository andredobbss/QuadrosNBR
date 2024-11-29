using Microsoft.AspNetCore.Identity;

namespace QuadrosNBR.Infraestrutura.DataBase.Identities;

public class ApplicationUser : IdentityUser
{
    protected ApplicationUser()
    {
        
    }
    public Guid TenantId { get; set; } 
    public Tenant Tenant { get; set; } = null!;
}
