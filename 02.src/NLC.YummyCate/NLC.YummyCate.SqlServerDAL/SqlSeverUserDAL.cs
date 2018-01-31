using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLC.YummyCate.DBUtility;
using System.Data.SqlClient;

namespace NLC.YummyCate.SqlServerDAL
{
  public  class SqlSeverUserDal
    {
        string connStr = "Data";
        SqlConnection conn = new SqlConnection();
        string selectsql = "select * from StaffInformation";
        SqlCommand cmd = new SqlCommand(selectsql, conn);



    }
}
