using Microsoft.EntityFrameworkCore;
using ReClaimBinApp_Infrastructure.Data;
using ReClaimBinApp_Infrastructure.Repository.Abstraction;
using System.Linq.Expressions;

namespace ReClaimBinApp_Infrastructure.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Create(T entity)
        {
            _appDbContext.Set<T>().Add(entity);
            _appDbContext.SaveChanges();

        }
        public IQueryable<T> FindAll(bool trackChanges)
        {
            if (!trackChanges)
            {
                return _appDbContext.Set<T>().AsNoTracking();
            }
            return _appDbContext.Set<T>();

        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = true)
        {
            return !trackChanges ?
                _appDbContext.Set<T>().Where(expression).AsNoTracking() :
                _appDbContext.Set<T>().Where(expression);
        }
        public void Update(T entity)
        {
            _appDbContext.Set<T>().Update(entity);
            _appDbContext.SaveChanges();
        }
        public void Delete(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
            _appDbContext.SaveChanges();
        }
    }
}

