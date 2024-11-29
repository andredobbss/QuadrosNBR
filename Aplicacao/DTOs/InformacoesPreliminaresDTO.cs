using QuadrosNBR.Aplicacao.DTOs.Base;

namespace QuadrosNBR.Aplicacao.DTOs;

public class InformacoesPreliminaresDTO : BaseDTO
{
    public string NomeDoIncorporador { get; set; } = null!;
    public string CNPJdoIncorporador { get; set; } = null!;
    public string EnderecoDoIncorporador { get; set; } = null!;
    public string NomeDoResponsavelTecnico { get; set; } = null!;
    public string CREAdoResponsavelTecnico { get; set; } = null!;
    public string ARTdoResponsavelTecnico { get; set; } = null!;
    public string EnderecoDoResponsavelTecnico { get; set; } = null!;
    public string NomeDoImovel { get; set; } = null!;
    public string EnderecoDoImovel { get; set; } = null!;
    public string CidadeDoImovel { get; set; } = null!;
    public string UFdoImovel { get; set; } = null!;
    public string DesignacaoDoImovel { get; set; } = null!;
    public uint UnidadesAutonomasDoImovel { get; set; } 
    public string PadraoDeAcabamentoDoImovel { get; set; } = null!;
    public uint NumeroDePavimentosDoImovel { get; set; } 
    public uint NumeroDeVagasDeAutomovelAutonomas { get; set; } 
    public uint NumeroDeVagasDeAutomovelAcessorias { get; set; } 
    public uint NumeroDeVagasDeAutomovelComum { get;  set; } 
    public decimal AreaDoLote { get;  set; } 
    public DateTime DataDeAprovacaoDoProjeto { get;  set; } 
    public string NumeroDoAlvara { get;  set; } = null!;
}
