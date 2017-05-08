using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using System.Linq.Expressions;
namespace IBLL
{
 public   interface IBaseService<T> where T:class,new ()
    {
        IDBSession GetCurrentDbSession { get;  }

        IQueryable<T> LoadEntites(Expression<Func<T, bool>> whereLanbda);
        IBaseDal<T> CurrentDal { get; set; }
        IQueryable<T> LoadPageEntites<s>(int pageIndex, int pageSize, int toalCount, Expression<Func<T, bool>> whereLanbda, Expression<Func<T, s>> orderbylanbda, bool flag);
        bool DeleteEntity(T entity);
        bool EditEntity(T entity);
        T AddEntity(T entity);
    }
}
