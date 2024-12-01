using System.Linq.Expressions;

namespace QuadrosNBR.Aplicacao.Repositories.Base;

public interface IRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> GetAllAsync(Expression<Func<TEntity, bool>> predicateProjetoId);
    Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> predicateProjetoId, Expression<Func<TEntity, bool>> predicateId);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
