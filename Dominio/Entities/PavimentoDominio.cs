using FluentValidation.Results;
using QuadrosNBR.Dominio.Entities.Base;
using QuadrosNBR.Dominio.Validations;

namespace QuadrosNBR.Dominio.Entities;

public class PavimentoDominio : BaseDominio
{
    private readonly PavimentoValidator _pavimentoValidator = new();
    public PavimentoDominio(
        string descricao, 
        ushort repeticao, 
        ushort ordenacao,
        Guid projetoId, 
        Guid tenantId) : base(projetoId, tenantId)
    {
        Descricao = descricao;
        Repeticao = repeticao;
        Ordenacao = ordenacao;
    }

    public string Descricao { get; private set; } = null!;
    public ushort Repeticao { get; private set; }
    public ushort Ordenacao { get; private set; }


    public ValidationResult PavimentoDominioResult()
    {
        return _pavimentoValidator.Validate(this);
    }
}
