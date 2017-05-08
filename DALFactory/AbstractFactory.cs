using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Model;
using IDAL;
using System.Reflection;

namespace DALFactory
{
    //抽象工厂本质一样解决对象创建的问题.区别创建对象的方式上不一样,抽象工厂是反射创建的   
  public  class AbstractFactory
    {
        public static readonly string NameSpace = ConfigurationManager.AppSettings["NameSpace"];
        public static IBooksDal CreateBooksDal()
        {
            string fullClassName = NameSpace + ".BooksDal";
            return CreateInstance(fullClassName) as IBooksDal;
        }
        public static object CreateInstance(string fullClassName)
        {
            var assembly = Assembly.Load(NameSpace);
            return assembly.CreateInstance(fullClassName);
        }
    }
}
