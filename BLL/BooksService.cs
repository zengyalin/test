using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
using IBLL;
namespace BLL
{
    public class BooksService : BaseService<Books>, IBaseService<Books>
    {
        
           public override void SetCurrentDal()
        {
            CurrentDal = this.GetCurrentDbSession.BooksDal;
        }

  
    }
}
