using Microsoft.EntityFrameworkCore;
using QuadrosNBR.Aplicacao.Repositories.Base;
using QuadrosNBR.Infraestrutura.DataBase.Context;
using System.Linq;
using System.Linq.Expressions;

namespace QuadrosNBR.Infraestrutura.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IQueryable<TEntity> GetAllAsync(Expression<Func<TEntity, bool>> predicateProjetoId)
        {
            return _appDbContext.Set<TEntity>().Where(predicateProjetoId);
        }

        public async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> predicateProjetoId, Expression<Func<TEntity, bool>> predicateId)
        {
            return await _appDbContext.Set<TEntity>().Where(predicateProjetoId).SingleOrDefaultAsync(predicateId);
        }

        public void Add(TEntity entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Added;
            _appDbContext.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
            _appDbContext.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Deleted;
            _appDbContext.Set<TEntity>().Remove(entity);
        }
    }
}
