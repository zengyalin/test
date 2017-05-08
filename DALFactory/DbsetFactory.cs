using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using System.Runtime.Remoting.Messaging;

namespace DALFactory
{
  public  class DbsetFactory
    {
        public static IDBSession CreateDbSession()
        {
            IDBSession dbSession = (IDBSession)CallContext.GetData("dbSession");
            if(dbSession==null)
            {
                dbSession = new DALFactory.DBSession();
                CallContext.SetData("dbSession",dbSession);
            }
            return dbSession;
        }
    }
}
