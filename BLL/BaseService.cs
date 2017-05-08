using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using DAL;
using DALFactory;
using System.Linq.Expressions;
using IBLL;
namespace BLL
{
 public abstract  class BaseService<T> where T:class,new()
    {
 public IDBSession GetCurrentDbSession
        {
            get
            {
                return DbsetFactory.CreateDbSession();
            }
        }
        public BaseService()
        {
            SetCurrentDal();
        }
        public IBaseDal<T> CurrentDal { get; set; }
        public abstract void SetCurrentDal();   
     public   IQueryable<T> LoadEntites(Expression<Func<T, bool>> whereLanbda)
        {
            return CurrentDal.LoadEntites(whereLanbda);
        }
     public   IQueryable<T> LoadPageEntites<s>(int pageIndex, int pageSize, int toalCount, Expression<Func<T, bool>> whereLanbda, Expression<Func<T, s>> orderbylanbda, bool flag)
        {
            return CurrentDal.LoadPageEntites<s>(pageIndex,pageSize,toalCount,whereLanbda,orderbylanbda,flag);
        }
      public  bool DeleteEntity(T entity)
        {
            CurrentDal.DeleteEntity(entity);
            return this.GetCurrentDbSession.SavaChange();
        }
     public   bool EditEntity(T entity)
        {
             CurrentDal.EditEntity(entity); 
            return this.GetCurrentDbSession.SavaChange();
        }
      public  T AddEntity(T entity)
        {
            return CurrentDal.AddEntity(entity);
        }
    }
}
