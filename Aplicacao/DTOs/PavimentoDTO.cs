using QuadrosNBR.Aplicacao.DTOs.Base;

namespace QuadrosNBR.Aplicacao.DTOs;

public class PavimentoDTO : BaseDTO
{
    public string Descricao { get; set; } = null!;
    public ushort Repeticao { get; set; }
    public ushort Ordenacao { get; set; }
}
