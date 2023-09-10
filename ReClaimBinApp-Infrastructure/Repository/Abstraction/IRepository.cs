using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
