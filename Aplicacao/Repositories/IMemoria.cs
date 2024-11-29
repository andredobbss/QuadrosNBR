using QuadrosNBR.Aplicacao.Repositories.Base;
using QuadrosNBR.Dominio.Entities;

namespace QuadrosNBR.Aplicacao.Repositories;

public interface IMemoria : IRepository<MemoriaDominio>
{
    void AreaAutocad(MemoriaDominio memoriaDominio, string dwgFilePath);
}
