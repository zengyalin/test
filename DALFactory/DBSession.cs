using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL;
using IDAL;
using Model;
namespace DALFactory
{
  public  class DBSession:IDBSession
    {
       public DbContext  db
        {
            get { return DbContextFactory.CreateDbContext(); }
        }
        //创建类的实例，业务层可以直接调用
        private IBooksDal BooksP;
        public   IBooksDal BooksDal
        {
           get
            {
                if(BooksP==null)
                {
                    BooksP = AbstractFactory.CreateBooksDal();//如果要更换数据               
                }
                return BooksP;
            }
            set { BooksP = value; }
        }
        public bool SavaChange()
        {
            return db.SaveChanges()>0;
        }
    }
}
