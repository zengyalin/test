using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Linq.Expressions;
namespace IDAL
{
  public  interface IBaseDal<T> where T:class,new()
    {
        IQueryable<T> LoadEntites(Expression<Func<T, bool>> whereLanbda);
        IQueryable<T> LoadPageEntites<s>(int pageIndex, int pageSize, int toalCount, Expression<Func<T, bool>> whereLanbda, Expression<Func<T, s>> orderbylanbda, bool flag);
        bool DeleteEntity(T entity);
        bool EditEntity(T entity);
        T AddEntity(T entity);
    }
}
