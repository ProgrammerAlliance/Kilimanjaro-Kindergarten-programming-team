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
    public abstract class DataAccess
    {
        public abstract IDal CreateDAL();
    }

    public class UserCreateDAL : DataAccess
    {
        public override IDal CreateDAL()
        {
            return new UserDAL();
        }
    }

    public class MenuCreateDAL : DataAccess
    {
        public override IDal CreateDAL()
        {
            return new MenuDAL();
        }
    }

    public class OrderCreateDAL : DataAccess
    {
        public override IDal CreateDAL()
        {
            return new OrderDAL();
        }
    }
}
