﻿using NLC.YummyCate.DALFactory;
using NLC.YummyCate.IDAL;
using NLC.YummyCate.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.YummyCate.BLL
{
    public class OrderBLL
    {
        /// <summary>
        /// 订餐
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public OperationResult<Boolean> ConfirmOrder(string username,string meno)
        {
            IOrderDAL orderDAL = OrderDALFactory.CreateOrderDAL();
            int _user = orderDAL.InsertUserOrder(username, meno);
            if (_user >= 1)
            {
                return new OperationResult<bool>() { Result = true, Message = "订餐成功", OrderingState = OrderingStateEnum.IsOrdering };
            }
            else
            {
                return new OperationResult<bool>() { Result = false, Message = "订餐失败", OrderingState = OrderingStateEnum.IsNullOfOrdering };
            }
        }

        /// <summary>
        /// 取消订餐
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public OperationResult<Boolean> CancelOrder(string userName)
        {
            IOrderDAL orderDAL = OrderDALFactory.CreateOrderDAL();
            int _user = orderDAL.DeleteUserOrder(userName);
            if (_user >= 1)
            { return new OperationResult<bool>() { Result = true, Message = "取消订餐成功", OrderingState = OrderingStateEnum.IsNullOfOrdering }; }
            else
            {
                return new OperationResult<bool>() { Result = false, Message = "取消订餐失败", OrderingState = OrderingStateEnum.IsNullOfOrdering };
            }
        }

        /// <summary>
        /// 产生打扫人员
        /// </summary>
        /// <returns></returns>
        public OperationResult<bool> ProduceCleaner()
        {
            int count = CountOrderNumber();
            //1.得到随机数
            List<int> random = ProduceRandom(count);
            if (random == null)
            {
                return new OperationResult<bool>() { Message = "今日无人订餐" };
            }
            IOrderDAL orderDAL = OrderDALFactory.CreateOrderDAL();
            List<StaffInformationResult> _user = orderDAL.FindByUserOrder();
            if (count <= 4)
            {
                return new OperationResult<bool>() { GetCleanerName1 = _user[random[0]].StaffName, GetCleanerName2 = "", Message = "产生打扫人员" };
            }
            else
            {
                return new OperationResult<bool>() { GetCleanerName1 = _user[random[0]].StaffName, GetCleanerName2 = _user[random[1]].StaffName, Message = "产生打扫人员" };
            }
        }

        /// <summary>
        /// 得到员工信息
        /// </summary>
        /// <returns></returns>
        public List<StaffInformationResult> GetStaffInformation()
        {
            IOrderDAL orderDAL = OrderDALFactory.CreateOrderDAL();
            List<StaffInformationResult> _user = orderDAL.FindByUserOrder();
            if (_user.Count < 0)
            {
                throw new Exception("程序异常");
            }
            else
            {
                return _user;
            }
        }

        /// <summary>
        /// 统计人数
        /// </summary>
        /// <returns></returns>
        public int CountOrderNumber()
        {
            IOrderDAL orderDAL = OrderDALFactory.CreateOrderDAL();
            int count = orderDAL.CountUserOrder();
            return count;
        }

        /// <summary>
        /// 产生随机数
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private List<int> ProduceRandom(int count)
        {
            int[] values = new int[2];
            List<int> str = new List<int>();
            Random random = new Random();
            if (count > 0 && count <= 4)
            {
                str.Add(random.Next(0, count));
                str.Add(random.Next(0, count));
                return str;
            }
            else if (count > 4)
            {
                for (int i = 0; i < 2; i++)
                {
                    values[i] = random.Next(0, count);
                }
                while (values[0] == values[1])
                {
                    values[1] = random.Next(0, count);
                }
                str.Add(values[0]);
                str.Add(values[1]);
                return str;
            }
            else
            {
                return str;
            }
        }
        /// <summary>
        /// 查询订餐的状态
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public OrderingStateEnum IsOrder(string username)
        {
            IOrderDAL orderDAL = OrderDALFactory.CreateOrderDAL();
            int indexcount = orderDAL.OrderingPeople(username).Count();
            if (indexcount > 0)
            {
                return OrderingStateEnum.IsOrdering;
            }
            else
            {
                return OrderingStateEnum.IsNullOfOrdering;
            }
        }
        public string IsMeno(string username)
        {
            IOrderDAL orderDAL = OrderDALFactory.CreateOrderDAL();
            List<StaffInformationResult> _user = orderDAL.IsAddMeno(username);
            int indexcount = _user.Count();
            if (indexcount > 0)
            {
                return _user[0].Meno;
            }
            else
            {
                return "";
            }
           
        }
    }
}
