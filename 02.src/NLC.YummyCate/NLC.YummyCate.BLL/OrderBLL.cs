using NLC.YummyCate.DALFactory;
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
            List<Order> _user =orderDAL.InsertUserOrder(userName);
            if (_user == null || _user.Count <= 0)
            {
                return new OperationResult<bool>() { Result = false, Message = "订餐失败" };
            }
            if (_user.Count == 1)
            {
                if (_user[0].OrderingStateID==1)//
                {
                    return new OperationResult<bool>() { Result = true, Message = "订餐成功",};
                }
                else
                {
                    return new OperationResult<bool>() { Result = false, Message = "订餐失败" };
                }
            }
            else
            {
                return new OperationResult<bool>() { Result = false, Message = "订餐失败" };
            }
        }
        /// <summary>
        /// 取消订餐
        /// </summary>
        public OperationResult<Boolean> CancelOrder(string userName) 
        {
            IOrderDAL orderDAL = OrderDALFactory.CreateOrderDAL();
            List<Order> _user = orderDAL.DeleteUserOrder(userName);
            if (_user.Count == 1)
            { return new OperationResult<bool>() { Result = true, Message = "取消订餐成功" }; }
            else
            {
                return new OperationResult<bool>() { Result = false, Message = "取消订餐失败" };
            }
        }
        /// <summary>
        /// 产生打扫人员
        /// </summary>
        public void ProduceCleaner()
        {//得到所有的打扫人数
            IOrderDAL orderDAL = OrderDALFactory.CreateOrderDAL();
            List<Order> _user = orderDAL.FindByUserOrder();
         
			
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
            return 21;
        }
        //private string[] ProduceRandom(int count)
        //{
        //    int[] a = new int[2];
        //    Random rd = new Random();
        //    for(int i=0;i<2;i++)
        //    {
        //        a[i] = rd.Next(0,count);
        //    }
        //    string[]
     
        //}
    }
}
