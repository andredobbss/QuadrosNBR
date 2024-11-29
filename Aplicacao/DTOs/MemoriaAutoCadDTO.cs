using QuadrosNBR.Aplicacao.DTOs.Base;

namespace QuadrosNBR.Aplicacao.DTOs;

public class MemoriaAutoCadDTO : BaseDTO
{
    public string NomeDaLayer { get; private set; } = null!;
    public decimal Area { get; private set; }
}
