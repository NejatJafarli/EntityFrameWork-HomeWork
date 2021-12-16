using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork_HomeWork.DataAccess.Abstractt
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> expression);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        void SaveChanges();
    }
}
