using QuadrosNBR.Aplicacao.IUnitOfWork;
using QuadrosNBR.Aplicacao.Repositories;
using QuadrosNBR.Infraestrutura.DataBase.Contextos;
using QuadrosNBR.Infraestrutura.Repositories;

namespace QuadrosNBR.Infraestrutura.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly InformacoesPreliminares _informacoesPreliminares;

    private readonly AppDbContext _appDbContext;

    public UnitOfWork(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IInformacoesPreliminares IInformacoesPreliminares
    {
        get
        {
            if (_informacoesPreliminares is null)
            {
                return new InformacoesPreliminares(_appDbContext);
            }
            else
            {
                return _informacoesPreliminares;
            }
        }
    }

    public async Task Commit()
    {
        await _appDbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _appDbContext.Dispose();
    }
}
