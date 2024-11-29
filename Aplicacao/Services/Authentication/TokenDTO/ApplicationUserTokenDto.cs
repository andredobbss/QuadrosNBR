namespace QuadrosNBR.Aplicacao.Services.Authentication.TokenDTO;

public class ApplicationUserTokenDto
{
    public bool Authenticated { get; set; }
    public DateTime Expiration { get; set; }
    public string Token { get; set; } = null!;
    public string Message { get; set; } = null!;
}


