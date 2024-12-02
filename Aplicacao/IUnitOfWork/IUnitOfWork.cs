using QuadrosNBR.Aplicacao.Repositories;

namespace QuadrosNBR.Aplicacao.IUnitOfWork
{
    public interface IUnitOfWork
    {
        IInformacoesPreliminares IInformacoesPreliminares { get; }
        IMemoria Imemoria { get; }
        IPavimento Ipavimento { get; }
        Task Commit();
        void Dispose();
    }
}
