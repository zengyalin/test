using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using System.Data.Entity;
using Model;
namespace DAL
{
  public  class DbContextFactory
    {
        public static DbContext CreateDbContext()
        {
            DbContext dbCotext = (DbContext)CallContext.GetData("dbContext");
            if (dbCotext==null)
            {
                dbCotext = new MvcBookStoreEntities();
                CallContext.SetData("dbContext",dbCotext);
            }
            return dbCotext;
        }
     
    }
}
