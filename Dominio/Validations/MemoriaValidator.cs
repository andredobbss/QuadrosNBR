using FluentValidation;
using QuadrosNBR.Dominio.Entities;

namespace QuadrosNBR.Dominio.Validations;

public class MemoriaValidator : AbstractValidator<MemoriaDominio>
{
    public MemoriaValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.NomeDaLayer).NotNull().NotEmpty().WithMessage("Informar o nome da Layer/Comparimento");
        RuleFor(x => x.Area).NotNull().NotEmpty().WithMessage("Informar a Area do Comparimento");
        RuleFor(x => x.Repeticao).NotNull().NotEmpty().WithMessage("Informar a repetição");
        RuleFor(x => x.Unidade).NotNull().NotEmpty().WithMessage("Informar a unidade");
        RuleFor(x => x.Pavimento).NotNull().NotEmpty().WithMessage("Informar o pavimento referente à unidade");
        RuleFor(x => x.Uso).NotNull().NotEmpty().WithMessage("Informar o uso (Privativo ou Comum)");
        RuleFor(x => x.Coeficiente).NotNull().NotEmpty().WithMessage("Informar o coeficiente de proporcionalidade");

        RuleFor(x => x.ProjetoId).NotEmpty().NotNull().WithMessage("Informar o Id do projeto");
        RuleFor(x => x.TenantId).NotEmpty().NotNull().WithMessage("Informar o TenatId");
    }
}
