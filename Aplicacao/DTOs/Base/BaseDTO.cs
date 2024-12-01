namespace QuadrosNBR.Aplicacao.DTOs.Base;

public abstract class BaseDTO
{
    public Guid Id { get; set; }
    public Guid ProjetoId { get; set; }
    public Guid TenantId { get; set; }
}
