namespace QuadrosNBR.Dominio.Identities;

public class Project
{
    //protected Project()
    //{

    //}

    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; }
}
