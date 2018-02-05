﻿using NLC.YummyCate.DALFactory;
using NLC.YummyCate.IDAL;
using NLC.YummyCate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.YummyCate.BLL
{
    public class OrderBLL
    {
        /// <summary>
        /// 确认订餐
        /// </summary>
        public OperationResult<Boolean> ConfirmOrder(string userName)
        {
            IOrderDAL orderDAL = OrderDALFactory.CreateOrderDAL();
            int _user = orderDAL.InsertUserOrder(userName);
            //if (_user == null || _user.Count <= 0)
            //{
            //	return new OperationResult<bool>() { Result = false, Message = "订餐失败" };
            //}
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
        public OperationResult<Boolean> CancelOrder(string userName)
        {
            IOrderDAL orderDAL = OrderDALFactory.CreateOrderDAL();
            int _user = orderDAL.DeleteUserOrder(userName);
            if (_user >= 1)
            {
                return new OperationResult<bool>() { Result = true, Message = "取消订餐成功", OrderingState = OrderingStateEnum.IsNullOfOrdering };
            }
            else
            {
                return new OperationResult<bool>() { Result = false, Message = "取消订餐失败", OrderingState = OrderingStateEnum.IsOrdering };
            }
        }
        /// <summary>
        /// 产生打扫人员
        /// </summary>
        public void ProduceCleaner(string userName)
        {
            //1.得到所有的打扫人数
            int orderCount = CountOrderNumber();
            //2.得到随机数  
            IOrderDAL orderDAL = OrderDALFactory.CreateOrderDAL();
            List<Order> _user = orderDAL.FindByUserOrder(userName);
        }

        /// <summary>
        /// 统计总的金额
        /// </summary>
        public float GetExpense()
        {
            return 2332;
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
        /// 产生随机打扫人员
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private void ProduceRandom(int count)
        {
            //int number = new Random().Next(0, 100);
            int[] values = new int[2];
            Random random = new Random();
            for (int i = 0; i < 2; i++)
                values[i] = random.Next(0, count);
            string randomName1 = values[0].ToString();
            string randomName2 = values[1].ToString();
            while (randomName1 == randomName2)
                values[1] = random.Next(0, count);
            Console.WriteLine(randomName1);
            Console.WriteLine(randomName2);
            Console.ReadKey();
        }
    }
}
