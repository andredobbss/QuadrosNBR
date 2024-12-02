using QuadrosNBR.Dominio.Entities;
using QuadrosNBR.Dominio.Validations;

namespace Teste;


public class UnitTest1 : IClassFixture<MemoriaValidator>
{
  private readonly MemoriaValidator _validation = new();

    public UnitTest1(MemoriaValidator validation)
    {
        _validation = validation;
    }

    [Fact]
    public void DadoQue_O_Nome_Dalayer_E_Nulo_Entao_DeveRetornarFalso()
    {
        
        Guid pj = Guid.NewGuid();
        Guid tnt = Guid.NewGuid();

        var memoria = new MemoriaDominio(null, null, 14.3M, null, null, null, null, null, null, null, null, null, null, null, pj, tnt);

        var result = _validation.Validate(memoria);

        Assert.False(result.IsValid);
    }

    [Fact]
    public void DDadoQue_O_Nome_Dalayer_Nao_E_Nulo_Entao_DeveRetornarVerdadeiro()
    {
        Guid pj = Guid.NewGuid();
        Guid tnt = Guid.NewGuid();

        var memoria = new MemoriaDominio(null, "teste", 14.3M, null, null, null, null, null, null, null, null, null, null, null, pj, tnt);

        var result = _validation.Validate(memoria);

        Assert.True(result.IsValid);
    }
}