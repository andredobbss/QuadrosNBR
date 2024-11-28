using QuadrosNBR.Dominio.Entities.Base;

namespace QuadrosNBR.Dominio.Entities;

public class InformacoesPreliminaresDominio(string nomeDoIncorporador, 
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
    Guid tenantId) : BaseDominio(projetoId, tenantId)
{
    public string NomeDoIncorporador { get; private set; } = nomeDoIncorporador;
    public string CNPJdoIncorporador { get; private set; } = cNPJdoIncorporador;
    public string EnderecoDoIncorporador { get; private set; } = enderecoDoIncorporador;
    public string NomeDoResponsavelTecnico { get; private set; } = nomeDoResponsavelTecnico;
    public string CREAdoResponsavelTecnico { get; private set; } = cREAdoResponsavelTecnico;
    public string ARTdoResponsavelTecnico { get; private set; } = aRTdoResponsavelTecnico;
    public string EnderecoDoResponsavelTecnico { get; private set; } = enderecoDoResponsavelTecnico;
    public string NomeDoImovel { get; private set; } = nomeDoImovel;
    public string EnderecoDoImovel { get; private set; } = enderecoDoImovel;
    public string CidadeDoImovel { get; private set; } = cidadeDoImovel;
    public string UFdoImovel { get; private set; } = uFdoImovel;
    public string DesignacaoDoImovel { get; private set; } = designacaoDoImovel;
    public uint UnidadesAutonomasDoImovel { get; private set; } = unidadesAutonomasDoImovel;
    public string PadraoDeAcabamentoDoImovel { get; private set; } = padraoDeAcabamentoDoImovel;
    public uint NumeroDePavimentosDoImovel { get; private set; } = numeroDePavimentosDoImovel;
    public uint NumeroDeVagasDeAutomovelAutonomas { get; private set; } = numeroDeVagasDeAutomovelAutonomas;
    public uint NumeroDeVagasDeAutomovelAcessorias { get; private set; } = numeroDeVagasDeAutomovelAcessorias;
    public uint NumeroDeVagasDeAutomovelComum { get; private set; } = numeroDeVagasDeAutomovelComum;
    public decimal AreaDoLote { get; private set; } = areaDoLote;
    public DateTime DataDeAprovacaoDoProjeto { get; private set; } = dataDeAprovacaoDoProjeto;
    public string NumeroDoAlvara { get; private set; } = numeroDoAlvara;
}
