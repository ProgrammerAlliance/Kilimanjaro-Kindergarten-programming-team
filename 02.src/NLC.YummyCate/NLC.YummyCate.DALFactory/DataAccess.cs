using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Configuration;
using NLC.YummyCate.IDAL;
using NLC.YummyCate.DAL;

namespace NLC.YummyCate.DALFactory
{
    /// <summary>
    /// 抽象工厂模式创建DAL。
    /// web.config 需要加入配置：(利用工厂模式+反射机制+缓存机制,实现动态创建不同的数据层对象接口)  
    /// DataCache类在导出代码的文件夹里
    /// 可以把所有DAL类的创建放在这个DataAccess类里
    /// <appSettings>  
    /// <add key="DAL" value="LiTianPing.SQLServerDAL" /> (这里的命名空间根据实际情况更改为自己项目的命名空间)
    /// </appSettings> 
    /// </summary>
    public abstract class DataAccess
    {
        public abstract IDAL CreateDAL();
    }

    public class UserCreateDAL : DataAccess
    {
        public override IDAL CreateDAL()
        {
            return new UserDAL();
        }
    }
}
