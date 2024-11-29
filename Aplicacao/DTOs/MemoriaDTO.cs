using QuadrosNBR.Aplicacao.DTOs.Base;

namespace QuadrosNBR.Aplicacao.DTOs;

public class MemoriaDTO : BaseDTO
{
    public string? NomeDaLayer { get; private set; }
    public decimal Area { get; private set; }
    public string? Descricao { get; private set; }
    public int Repeticao { get; private set; }
    public string? Unidade { get; private set; }
    public string? Pavimento { get; private set; }
    public string? Uso { get; private set; }
    public decimal Coeficiente { get; private set; }
    public bool AreaCobertaAberta { get; private set; }
    public bool Proporcionalidade { get; private set; }
    public bool Acessoria { get; private set; }
    public string? Observacao { get; private set; }
    public bool Terreno { get; private set; }
}
