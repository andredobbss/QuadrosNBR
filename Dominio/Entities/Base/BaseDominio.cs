namespace QuadrosNBR.Dominio.Entities.Base;

public abstract class BaseDominio
{
    protected BaseDominio()
    {
        
    }

    public BaseDominio(Guid projetoId, Guid tenantId)
    {
        Id = Guid.NewGuid();
        ProjetoId = projetoId;
        TenantId = tenantId;
    }

    public Guid Id { get; private set; } 
    public Guid ProjetoId { get; private set; }
    public Guid TenantId { get; private set; }
}
