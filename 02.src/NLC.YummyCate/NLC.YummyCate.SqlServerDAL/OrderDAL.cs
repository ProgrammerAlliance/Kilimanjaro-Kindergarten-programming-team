using NLC.YummyCate.DBUtility;
using NLC.YummyCate.IDAL;
using NLC.YummyCate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLC.YummyCate.DAL
{
    public class OrderDAL : IOrderDAL
    {
        public List<Order> DeleteUserOrder(string userName)
        {
            string sql = "Update Orderinginformation SET OrderingStateID=2 WHERE  UserName = '" + userName + "'";
            DBHelper dBHelper = new DBHelper();
            return dBHelper.ExecuteList<Order>(sql);
        }
        /// <summary>
        /// 查询所有的订餐信息人数，返回所有订餐的人数
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public List<Order> FindByUserOrder(string userName)
        {
            string sql = "SELECT * FROM Orderinginformation";
            DBHelper dBHelper = new DBHelper();
            return dBHelper.ExecuteList<Order>(sql);
        }

        public List<Order> InsertUserOrder(string userName)//1代表订餐2未订餐
        {
            string sql = "Insert Orderinginformation (OrderingStateID,UserName)  values(1,'userName')";
            DBHelper dBHelper = new DBHelper();
            return dBHelper.ExecuteList<Order>(sql);
        }
    }
}
