using Microsoft.EntityFrameworkCore;
using QuadrosNBR.Aplicacao.Repositories.Base;
using QuadrosNBR.Infraestrutura.DataBase.Contextos;
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

        public IQueryable<TEntity> GetAllAsync()
        {
            return _appDbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetById(Expression<Func<TEntity, bool>> predicate)
        {
            return await _appDbContext.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(predicate);
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
