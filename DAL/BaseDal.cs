using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
using System.Linq.Expressions;
using System.Data.Entity;
namespace DAL
{
    public class BaseDal<T> where T : class, new()
    {
        DbContext db = DbContextFactory.CreateDbContext();
        #region     增加  
        public T AddEntity(T entity)
        {
            db.Set<T>().Add(entity);
           // db.SaveChanges();
            return entity;
        }
        #endregion 
        public bool DeleteEntity(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Deleted;
            return true;
        }

        public bool EditEntity(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Modified;
            return true;
        }

        public IQueryable<T> LoadEntites(Expression<Func<T, bool>> whereLanbda)
        {
            return db.Set<T>().Where<T>(whereLanbda);
        }

        public IQueryable<T> LoadPageEntites<s>(int pageIndex, int pageSize, int toalCount, Expression<Func<T, bool>> whereLanbda, Expression<Func<T, s>> orderbylanbda, bool flag)
        {
            var temp = db.Set<T>().Where(whereLanbda);
            toalCount = temp.Count();
            if (flag)
            {
                temp = temp.OrderBy<T, s>(orderbylanbda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            else
            {
                temp = temp.OrderByDescending<T, s>(orderbylanbda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            return temp;
        }
    }
}
