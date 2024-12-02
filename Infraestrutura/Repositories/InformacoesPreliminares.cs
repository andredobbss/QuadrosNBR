using QuadrosNBR.Aplicacao.Repositories;
using QuadrosNBR.Dominio.Entities;
using QuadrosNBR.Infraestrutura.DataBase.Context;
using QuadrosNBR.Infraestrutura.Repositories.Base;

namespace QuadrosNBR.Infraestrutura.Repositories;

public class InformacoesPreliminares : Repository<InformacoesPreliminaresDominio>, IInformacoesPreliminares
{
    public InformacoesPreliminares(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
