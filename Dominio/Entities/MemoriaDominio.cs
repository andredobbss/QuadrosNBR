using QuadrosNBR.Dominio.Entities.Base;

namespace QuadrosNBR.Dominio.Entities
{
    public class MemoriaDominio(string nomeDaLayer, decimal area, string descricao, int repeticao, string unidade, string pavimento, string uso, double coeficiente, bool areaCobertaAberta, bool proporcionalidade, bool acessoria, string observacao, bool terreno, double areaCobertaPadrao, double areaDiferenteDaCobertaPadrao, double areaEquivalenteDiferenteDaCobertaPadraoTotal, double areaEquivalenteDiferenteDaCobertaPadraoInitaria, double areaCobertaPadrao1, double areaDiferenteDaCobertaPadrao1, double areaEquivalenteDiferenteDaCobertaPadraoTotal1, double areaEquivalenteDiferenteDaCobertaPadraoUnitaria, double areaAcessoria, double areaDoTerreno, Guid projetoId, Guid clienteId) : BaseDominio(projetoId, clienteId)
    {
        public string NomeDaLayer { get; private set; } = nomeDaLayer;
        public decimal Area { get; private set; } = area;
        public string Descricao { get; private set; } = descricao;
        public int Repeticao { get; private set; } = repeticao;
        public string Unidade { get; private set; } = unidade;
        public string Pavimento { get; private set; } = pavimento;
        public string Uso { get; private set; } = uso;
        public double Coeficiente { get; private set; } = coeficiente;
        public bool AreaCobertaAberta { get; private set; } = areaCobertaAberta;
        public bool Proporcionalidade { get; private set; } = proporcionalidade;
        public bool Acessoria { get; private set; } = acessoria;
        public string Observacao { get; private set; } = observacao;
        public bool Terreno { get; private set; } = terreno;
        public double AreaCobertaPadrao { get; private set; } = areaCobertaPadrao;
        public double AreaDiferenteDaCobertaPadrao { get; private set; } = areaDiferenteDaCobertaPadrao;
        public double AreaEquivalenteDiferenteDaCobertaPadraoTotal { get; private set; } = areaEquivalenteDiferenteDaCobertaPadraoTotal;
        public double AreaEquivalenteDiferenteDaCobertaPadraoInitaria { get; private set; } = areaEquivalenteDiferenteDaCobertaPadraoInitaria;
        public double AreaCobertaPadrao1 { get; private set; } = areaCobertaPadrao1;
        public double AreaDiferenteDaCobertaPadrao1 { get; private set; } = areaDiferenteDaCobertaPadrao1;
        public double AreaEquivalenteDiferenteDaCobertaPadraoTotal1 { get; private set; } = areaEquivalenteDiferenteDaCobertaPadraoTotal1;
        public double AreaEquivalenteDiferenteDaCobertaPadraoUnitaria { get; private set; } = areaEquivalenteDiferenteDaCobertaPadraoUnitaria;
        public double AreaAcessoria { get; private set; } = areaAcessoria;
        public double AreaDoTerreno { get; private set; } = areaDoTerreno;
    }
}
