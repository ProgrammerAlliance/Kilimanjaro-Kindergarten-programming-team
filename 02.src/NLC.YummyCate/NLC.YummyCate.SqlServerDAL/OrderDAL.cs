﻿using NLC.YummyCate.DBUtility;
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
            string sql = "DELETE FROM OrderingInformation WHERE  UserName = '" + userName + "'";
            DBHelper dBHelper = new DBHelper();
            return dBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 查询所有点餐人的信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public List<StaffInformationResult> FindByUserOrder()
        {
            string sql = "SELECT StaffName,DateTime,Meno FROM OrderingInformation WHERE DateDiff(dd, DateTime, getdate()) = 0";
            DBHelper dBHelper = new DBHelper();
            return dBHelper.ExecuteList<StaffInformationResult>(sql);
        }
        public int InsertUserOrder(string userName, string meno)//1代表订餐2未订餐
        {
            string name = GetStaffName(userName);

            //1.查询员工的姓名
            //2.将员工信息订餐的信息插入到订餐表中
            //string sql = "INSERT OrderingInformation (OrderingStateID,UserName,StaffName,DateTime)VALUES(1,'userName','name','datetime')";
            string sql = "INSERT OrderingInformation (OrderingStateID,UserName,StaffName,DateTime,Meno)VALUES(1,'" + userName + "','" + name + "',getdate(),'" + meno + "')";
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
            string sql = "SELECT * FROM OrderingInformation WHERE  (OrderID = '" + id1 + " ' OR OrderID '" + id2 + " ')";
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

        /// <summary>
        /// 统计人数,查询所有的订餐信息人数，返回所有订餐的人数
        /// </summary>
        /// <returns></returns>
        public int CountUserOrder()
        {
            //select* from info where DateDiff(dd, datetime, getdate()) = 0
            string sql = "SELECT COUNT(*) FROM OrderingInformation WHERE DateDiff(dd, DateTime, getdate()) = 0";
            DBHelper dBHelper = new DBHelper();
            int orderCount = Convert.ToInt32(dBHelper.ExecuteScalar(sql));
            return orderCount;
        }
    }
}
