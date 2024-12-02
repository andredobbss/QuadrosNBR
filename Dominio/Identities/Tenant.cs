namespace QuadrosNBR.Dominio.Identities;

public class Tenant
{
    //protected Tenant()
    //{

    //}

    public Guid Id { get; set; } = Guid.NewGuid();
    public string? RazaoSocial { get; set; }
    public string? Endereco { get; set; }
    public string? CNPJ { get; set; }
    public ICollection<Project> Projects { get; set; }
    public ICollection<ApplicationUser> Users { get; set; }
}
