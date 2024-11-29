using FluentValidation;
using QuadrosNBR.Dominio.Entities;

namespace QuadrosNBR.Dominio.Validations;

public class InformacoesPreliminaresValidator : AbstractValidator<InformacoesPreliminaresDominio>
{
    public InformacoesPreliminaresValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.NomeDoIncorporador).NotEmpty().NotNull().WithMessage("Informar o nome do incorporador");
        RuleFor(x => x.CNPJdoIncorporador).NotEmpty().NotNull().IsValidCNPJ().WithMessage("Informar o CNPJ válido");
        RuleFor(x => x.EnderecoDoIncorporador).NotEmpty().NotNull().WithMessage("Informar o endereço do incorporador");
        RuleFor(x => x.NomeDoResponsavelTecnico).NotEmpty().NotNull().WithMessage("Informar o nome do responsável técnico");
        RuleFor(x => x.CREAdoResponsavelTecnico).NotEmpty().NotNull().WithMessage("Informar o número do CREA do responsável técnico");
        RuleFor(x => x.ARTdoResponsavelTecnico).NotEmpty().NotNull().WithMessage("Informar o número da ART");
        RuleFor(x => x.EnderecoDoResponsavelTecnico).NotEmpty().NotNull().WithMessage("Informar o endereço do responsável técnico");
        RuleFor(x => x.NomeDoImovel).NotEmpty().NotNull().WithMessage("Informar o nome do imóvel");
        RuleFor(x => x.EnderecoDoImovel).NotEmpty().NotNull().WithMessage("Informar o endereço do imóvel");
        RuleFor(x => x.CidadeDoImovel).NotEmpty().NotNull().WithMessage("Informar a cidade do imóvel");
        RuleFor(x => x.UFdoImovel).NotEmpty().NotNull().WithMessage("Informar a unidade federativa do imóvel");
        RuleFor(x => x.DesignacaoDoImovel).NotEmpty().NotNull().WithMessage("Informar a designação do imóvel");
        RuleFor(x => x.UnidadesAutonomasDoImovel).NotEmpty().NotNull().WithMessage("Informar as unidades autônomas do imóvel");
        RuleFor(x => x.PadraoDeAcabamentoDoImovel).NotEmpty().NotNull().WithMessage("Informar o padrão do imóvel");
        RuleFor(x => x.NumeroDePavimentosDoImovel).NotEmpty().NotNull().WithMessage("Informar o padrão de acabamento do imóvel");
        RuleFor(x => x.AreaDoLote).NotEmpty().NotNull().WithMessage("Informar a área do lote");
        RuleFor(x => x.DataDeAprovacaoDoProjeto).NotEmpty().NotNull().WithMessage("Informar a data de aprovação do projeto legal");
        RuleFor(x => x.NumeroDoAlvara).NotEmpty().NotNull().WithMessage("Informar o número do alvará");

        RuleFor(x => x.ProjetoId).NotEmpty().NotNull().WithMessage("Informar o Id do projeto");
        RuleFor(x => x.TenantId).NotEmpty().NotNull().WithMessage("Informar o TenatId");
    }
}
