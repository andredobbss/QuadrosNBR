using System.Security.Claims;

namespace QuadrosNBR.Aplicacao.Extensions;

public static class ClaimsPrincipalExtension
{
    public static Guid TenantId(this ClaimsPrincipal claims)
    {
        try
        {
            var value = claims?.FindFirst("TenantId")?.Value;
            return Guid.Parse(value);
        }
        catch
        {
            return Guid.Empty;
        }
    }
}
