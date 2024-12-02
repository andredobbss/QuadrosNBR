using QuadrosNBR.Aplicacao.IUnitOfWork;
using QuadrosNBR.Aplicacao.Repositories;
using QuadrosNBR.Infraestrutura.DataBase.Context;
using QuadrosNBR.Infraestrutura.Repositories;

namespace QuadrosNBR.Infraestrutura.UnitOfWork;

public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
{
    private readonly InformacoesPreliminares? _informacoesPreliminares;
    private readonly Memoria? _memoria;
    private readonly Pavimento? _pavimento;

    private readonly AppDbContext _appDbContext = appDbContext;

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

    public IMemoria Imemoria
    {
        get
        {
            if (_memoria is null)
            {
                return new Memoria(_appDbContext);
            }
            else
            {
                return _memoria;
            }
        } 
    }

    public IPavimento Ipavimento
    {
        get
        {
            if( _pavimento is null)
            {  
                return new Pavimento(_appDbContext); 
            }
            else
            {
                return _pavimento;
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
