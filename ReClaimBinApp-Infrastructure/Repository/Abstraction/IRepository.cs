using System.Linq.Expressions;

namespace ReClaimBinApp_Infrastructure.Repository.Abstraction
{
    public interface IRepository<T> where T : class
    {
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        IQueryable<T> FindAll(bool trackChanges);
        void Create(T entity);
    }
}