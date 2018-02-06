using NLC.YummyCate.DBUtility;
using NLC.YummyCate.IDAL;
using NLC.YummyCate.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLC.YummyCate.DAL
{
    public class OrderDAL : IOrderDAL
    {
        public int DeleteUserOrder(string userName)
        {
            string sql = "DELETE FROM OrderingInformation" + GetCurrentDate() + " WHERE  UserName = '" + userName + "'";
            DBHelper dBHelper = new DBHelper();
            return dBHelper.ExecuteNonQuery(sql);
        }
     
        /// <summary>
        /// 查询所有点餐人的信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public List<Order> FindByUserOrder(string userName)
        {
            string sql = "SELECT * FROM OrderingInformation" + GetCurrentDate(); 
            DBHelper dBHelper = new DBHelper();
            return dBHelper.ExecuteList<Order>(sql);
        }
        public int InsertUserOrder(string userName)//1代表订餐2未订餐
        {

            // List<Order> staffName = GetStaffName(userName);
            string date = GetCurrentDate();
            string name = GetStaffName(userName);
            //创建当天的订餐信息表
            if (!IsTableExist("OrderingInformation" + GetCurrentDate()))
            {
                string createsql = "CREATE TABLE OrderingInformation" + GetCurrentDate() + "(OrderID int identity(1,1),OrderingStateID int,UserName varchar(50),StaffName varchar(50), DateTime datetime default getdate(),DepartMentName varchar(50))";
                DBHelper dbHelper = new DBHelper();
                dbHelper.ExecuteNonQuery(createsql);
            }
            //1.查询员工的姓名
            //2.将员工信息订餐的信息插入到订餐表中
            //string sql = "INSERT OrderingInformation (OrderingStateID,UserName,StaffName,DateTime)VALUES(1,'userName','name','datetime')";
            string sql = "INSERT OrderingInformation" + GetCurrentDate() + "(OrderingStateID,UserName,StaffName)VALUES(1,'" + userName + "','" + name + "')";
            DBHelper dBHelper = new DBHelper();
            return dBHelper.ExecuteNonQuery(sql);
        }

		/// <summary>
		/// 打扫人员
		/// </summary>
		/// <param name="id1"></param>
		/// <param name="id2"></param>
		/// <returns></returns>
		public List<Order> FindCleaner(int id1, int id2)
		{
			string sql = "SELECT * FROM OrderingInformation" + GetCurrentDate() + " WHERE  (OrderID = '" + id1 + " ' OR OrderID '" + id2 + " ')";
			DBHelper dBHelper = new DBHelper();
			return dBHelper.ExecuteList<Order>(sql);
		}

		/// <summary>
		/// 查询员工的姓名
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		private string GetStaffName(string name)
        {
            string staffName = string.Empty;
            string sql = "SELECT StaffName FROM UserInformation WHERE IsDeleted = 0 AND UserName = '" + name + "'";
            DBHelper dBHelper = new DBHelper();
            staffName = dBHelper.ExecuteScalar(sql).ToString();
            return staffName;
        }
        private string GetCurrentTime()
        {
            string datetime = DateTime.Now.ToString();
            return datetime;
        }
        private string GetCurrentDate()
        {
            string day = DateTime.Today.ToString("yyyyMMdd");
            return day;
        }
        /// <summary>
        /// 判断表是否存在
        /// </summary>
        /// <param name="database"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        private bool IsTableExist(string tablename)
        {//"use " + database +
            DBHelper dBHelper = new DBHelper();
            string createDbStr = "select count(1) from sysobjects where name = '" + tablename + "'";
            //"select * from sys.tables where name ='表名 ’" select * from  sysobjects where id = object_id('" + tablename + "') and type = 'U'";
            //在指定的数据库中  查找 该表是否存在  
            int dt = Convert.ToInt32(dBHelper.ExecuteScalar(createDbStr));
            if (dt == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 统计人数,查询所有的订餐信息人数，返回所有订餐的人数
        /// </summary>
        /// <returns></returns>

        public int CountUserOrder()
        {
            string sql = "SELECT count(*) FROM OrderingInformation" + GetCurrentDate();
            DBHelper dBHelper = new DBHelper();
            int orderCount = Convert.ToInt32(dBHelper.ExecuteScalar(sql));
            return orderCount;
        }
    }
}
