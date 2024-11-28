using System.Linq.Expressions;

namespace QuadrosNBR.Aplicacao.Repositories.Base;

public interface IRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> GetAllAsync();
    Task<TEntity> GetById(Expression<Func<TEntity, bool>> predicate);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
