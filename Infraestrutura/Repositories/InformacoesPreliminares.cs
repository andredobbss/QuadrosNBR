using QuadrosNBR.Aplicacao.Repositories;
using QuadrosNBR.Dominio.Entities;
using QuadrosNBR.Infraestrutura.DataBase.Contextos;
using QuadrosNBR.Infraestrutura.Repositories.Base;

namespace QuadrosNBR.Infraestrutura.Repositories;

public class InformacoesPreliminares(AppDbContext _appDbContext) : Repository<InformacoesPreliminaresDominio>(_appDbContext), IInformacoesPreliminares
{

}
