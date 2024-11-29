using FluentValidation.Results;
using QuadrosNBR.Dominio.Entities.Base;
using QuadrosNBR.Dominio.Validations;

namespace QuadrosNBR.Dominio.Entities;

public class InformacoesPreliminaresDominio : BaseDominio
{
    private readonly InformacoesPreliminaresValidator _informacoesPreliminaresValidator = new();
    public InformacoesPreliminaresDominio(
        string nomeDoIncorporador, 
        string cNPJdoIncorporador, 
        string enderecoDoIncorporador, 
        string nomeDoResponsavelTecnico, 
        string cREAdoResponsavelTecnico, 
        string aRTdoResponsavelTecnico, 
        string enderecoDoResponsavelTecnico, 
        string nomeDoImovel, 
        string enderecoDoImovel, 
        string cidadeDoImovel, 
        string uFdoImovel, 
        string designacaoDoImovel, 
        uint unidadesAutonomasDoImovel, 
        string padraoDeAcabamentoDoImovel, 
        uint numeroDePavimentosDoImovel, 
        uint numeroDeVagasDeAutomovelAutonomas, 
        uint numeroDeVagasDeAutomovelAcessorias, 
        uint numeroDeVagasDeAutomovelComum, 
        decimal areaDoLote, 
        DateTime dataDeAprovacaoDoProjeto, 
        string numeroDoAlvara, 
        Guid projetoId, 
        Guid tenantId) : base(projetoId, tenantId)
    {
        NomeDoIncorporador = nomeDoIncorporador;
        CNPJdoIncorporador = cNPJdoIncorporador;
        EnderecoDoIncorporador = enderecoDoIncorporador;
        NomeDoResponsavelTecnico = nomeDoResponsavelTecnico;
        CREAdoResponsavelTecnico = cREAdoResponsavelTecnico;
        ARTdoResponsavelTecnico = aRTdoResponsavelTecnico;
        EnderecoDoResponsavelTecnico = enderecoDoResponsavelTecnico;
        NomeDoImovel = nomeDoImovel;
        EnderecoDoImovel = enderecoDoImovel;
        CidadeDoImovel = cidadeDoImovel;
        UFdoImovel = uFdoImovel;
        DesignacaoDoImovel = designacaoDoImovel;
        UnidadesAutonomasDoImovel = unidadesAutonomasDoImovel;
        PadraoDeAcabamentoDoImovel = padraoDeAcabamentoDoImovel;
        NumeroDePavimentosDoImovel = numeroDePavimentosDoImovel;
        NumeroDeVagasDeAutomovelAutonomas = numeroDeVagasDeAutomovelAutonomas;
        NumeroDeVagasDeAutomovelAcessorias = numeroDeVagasDeAutomovelAcessorias;
        NumeroDeVagasDeAutomovelComum = numeroDeVagasDeAutomovelComum;
        AreaDoLote = areaDoLote;
        DataDeAprovacaoDoProjeto = dataDeAprovacaoDoProjeto;
        NumeroDoAlvara = numeroDoAlvara;
    }

    public string NomeDoIncorporador { get; private set; } 
    public string CNPJdoIncorporador { get; private set; } 
    public string EnderecoDoIncorporador { get; private set; } 
    public string NomeDoResponsavelTecnico { get; private set; } 
    public string CREAdoResponsavelTecnico { get; private set; } 
    public string ARTdoResponsavelTecnico { get; private set; } 
    public string EnderecoDoResponsavelTecnico { get; private set; } 
    public string NomeDoImovel { get; private set; } 
    public string EnderecoDoImovel { get; private set; } 
    public string CidadeDoImovel { get; private set; } 
    public string UFdoImovel { get; private set; } 
    public string DesignacaoDoImovel { get; private set; } 
    public uint UnidadesAutonomasDoImovel { get; private set; } 
    public string PadraoDeAcabamentoDoImovel { get; private set; }
    public uint NumeroDePavimentosDoImovel { get; private set; } 
    public uint NumeroDeVagasDeAutomovelAutonomas { get; private set; } 
    public uint NumeroDeVagasDeAutomovelAcessorias { get; private set; } 
    public uint NumeroDeVagasDeAutomovelComum { get; private set; } 
    public decimal AreaDoLote { get; private set; } 
    public DateTime DataDeAprovacaoDoProjeto { get; private set; } 
    public string NumeroDoAlvara { get; private set; }

    public ValidationResult AddresDomainResult()
    {
        return _informacoesPreliminaresValidator.Validate(this);
    }
}
