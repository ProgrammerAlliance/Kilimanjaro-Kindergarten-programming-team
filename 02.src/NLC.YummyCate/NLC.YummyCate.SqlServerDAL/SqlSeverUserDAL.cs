using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLC.YummyCate.DBUtility;
using System.Data.SqlClient;

namespace NLC.YummyCate.SqlServerDAL
{
    public class SqlSeverUserDal
    {
        string selectsql = "select * from StaffInformation where UserName=";
        /// <summary>
        /// 执行User数据库
        /// </summary>
        public bool ProduceDataOperation()
        {
            DBHelper db = new DBHelper();
            int i= db.ExecuteNonQuery(selectsql);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
