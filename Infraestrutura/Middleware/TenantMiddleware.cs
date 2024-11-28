using Microsoft.AspNetCore.Http;

namespace QuadrosNBR.Infraestrutura.Middleware;

public class TenantMiddleware
{
    private readonly RequestDelegate _next;

    public TenantMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Obtém o ID do Tenant do cabeçalho (ou qualquer outra fonte)
        var tenantId = context.User.Claims.FirstOrDefault(c => c.Type == "TenantId")?.Value;

        if (tenantId != null && Guid.TryParse(tenantId, out var parsedTenantId))
        {
            context.Items["TenantId"] = parsedTenantId; // Armazena no contexto
        }

        await _next(context);
    }
}

