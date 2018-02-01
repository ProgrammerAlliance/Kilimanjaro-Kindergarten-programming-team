using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLC.YummyCate.DBUtility;
using System.Data.SqlClient;

namespace NLC.YummyCate.DAL
{
    public class UserDAL
    {
        string connStr = "Data";
        SqlConnection conn = new SqlConnection();
        string selectsql = "select * from StaffInformation";
        SqlCommand cmd = new SqlCommand(selectsql, conn);



    }
}
