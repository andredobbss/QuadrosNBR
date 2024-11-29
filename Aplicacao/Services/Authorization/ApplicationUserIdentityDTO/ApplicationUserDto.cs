namespace QuadrosNBR.Aplicacao.Services.Authorization.ApplicationUserIdentityDTO;

public class ApplicationUserDto
{
    public Guid TenantId { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string ConfirmPassword { get; set; } = null!;
}
