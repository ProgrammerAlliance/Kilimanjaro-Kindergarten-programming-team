using NLC.YummyCate.DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.YummyCate.SqlServerDAL
{
  public  class SqlSeverOrderDAL
    {
        string selectsql = "Insert into  OrderingInformation (UserName OrderState ) values()where Datatime=DateTime.ToString(yyyy--MM--dd)";
        /// <summary>
        /// 执行Order数据库,增加信息
        /// </summary>
        public bool ProduceDataOperation()
        {
            DBHelper db = new DBHelper();
            int i = db.ExecuteNonQuery(selectsql);
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
