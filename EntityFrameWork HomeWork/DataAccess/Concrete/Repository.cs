using EntityFrameWork_HomeWork.DataAccess.Abstractt;
using EntityFrameWork_HomeWork.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork_HomeWork.DataAccess.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected MyDbContext MyDb { get; set; }
        public Repository()
        {
            MyDb = new MyDbContext();
        }
        public void Delete(T entity)
        {
            MyDb.Set<T>().Remove(entity);
            SaveChanges();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> expression)
        {
            return MyDb.Set<T>().Where(expression);
        }

        public IQueryable<T> GetAll()
        {
            return MyDb.Set<T>();
        }

        public void Insert(T entity)
        {
            MyDb.Set<T>().Add(entity);
            SaveChanges();
        }

        public void SaveChanges()
        {
            MyDb.SaveChanges();
        }

        public void Update(T entity)
        {
            MyDb.Set<T>().Update(entity);
            SaveChanges();
        }
    }
}
