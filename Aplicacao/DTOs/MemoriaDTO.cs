using QuadrosNBR.Aplicacao.DTOs.Base;

namespace QuadrosNBR.Aplicacao.DTOs;

public class MemoriaDTO : BaseDTO
{
    public string? Dependencia { get; set; } = null;
    public string NomeDaLayer { get; set; }
    public decimal Area { get; set; }
    public ushort? Ordenacao { get;  set; } = null;
    public ushort? Repeticao { get;  set; } = null;
    public string? Pavimento { get;  set; } = null;
    public string? Uso { get;  set; } = null;
    public decimal? Coeficiente { get;  set; } = null;
    public bool? DecideDivisaoProporcional { get;  set; } = null;
    public bool? DecideAreaPadrao { get;  set; } = null;
    public bool? DecideAreaAcessoria { get;  set; } = null;
    public bool? DecideAreaDoTerreno { get;  set; } = null;
    public string? Observacao { get;  set; } = null;
}
