using Microsoft.AspNetCore.Identity;

namespace QuadrosNBR.Dominio.Identities;

public class ApplicationUser : IdentityUser
{
    //protected ApplicationUser()
    //{

    //}

    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; } = null!;
}