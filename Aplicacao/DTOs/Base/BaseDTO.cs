namespace QuadrosNBR.Aplicacao.DTOs.Base;

public abstract class BaseDTO
{
    public Guid Id { get; private set; }
    public Guid ProjetoId { get; private set; }
    public Guid TenantId { get; private set; }
}
