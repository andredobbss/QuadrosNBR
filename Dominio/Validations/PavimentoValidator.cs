using FluentValidation;
using QuadrosNBR.Dominio.Entities;

namespace QuadrosNBR.Dominio.Validations;

public class PavimentoValidator : AbstractValidator<PavimentoDominio>
{
    public PavimentoValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Descricao).NotEmpty().NotNull().WithMessage("Informar a descrição do pavimento");
        RuleFor(x => x.Repeticao).NotEmpty().NotNull().WithMessage("Informar a repeitção do pavimento");

        RuleFor(x => x.ProjetoId).NotEmpty().NotNull().WithMessage("Informar o Id do projeto");
        RuleFor(x => x.TenantId).NotEmpty().NotNull().WithMessage("Informar o TenatId");
    }
}
