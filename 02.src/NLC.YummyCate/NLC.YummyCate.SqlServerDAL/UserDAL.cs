using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLC.YummyCate.DBUtility;
using System.Data.SqlClient;
using NLC.YummyCate.IDAL;
using System.Linq.Expressions;
using NLC.YummyCate.Model;

namespace NLC.YummyCate.DAL
{
    public class UserDAL : IUserDAL
    {
        public List<User> FindByUserName(string userName)
        {
            string sql = "SELECT UserName,Pwd,TypeID FROM UserInformation WHERE IsDeleted = 0 AND UserName = '" + userName + "'";
            DBHelper dBHelper = new DBHelper();
            return dBHelper.ExecuteList<User>(sql);
        }
    }
}
