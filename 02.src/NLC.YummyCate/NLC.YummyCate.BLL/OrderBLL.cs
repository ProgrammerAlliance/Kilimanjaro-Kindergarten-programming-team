using NLC.YummyCate.DALFactory;
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
            { return new OperationResult<bool>() { Result = true, Message = "取消订餐成功", OrderingState = OrderingStateEnum.IsNullOfOrdering }; }
            else
            {
                return new OperationResult<bool>() { Result = false, Message = "取消订餐失败", OrderingState = OrderingStateEnum.IsOrdering };
            }
        }

        /// <summary>
        /// 产生打扫人员
        /// </summary>
        public OperationResult<bool> ProduceCleaner()
        {
            //1.得到所有的打扫人数
            int orderCount = CountOrderNumber();
            //2.得到随机数
            List<int> random = ProduceRandom(orderCount);
            if(random.Count==1)
            { random[1] = random[0]; }
            //3.查找相关人员
            IOrderDAL orderDAL = OrderDALFactory.CreateOrderDAL();
            List<Order> _user = orderDAL.FindCleaner(random[0], random[1]);
            if (_user.Count == 1)
            {
            
                return new OperationResult<bool>() { GetCleanerName1 =_user[0].StaffName , Message = "产生打扫人员" };
            }
            if (_user.Count == 2)
            {
                string a = _user[0].StaffName;
                string b = _user[1].StaffName;
                return new OperationResult<bool>() { GetCleanerName1 =_user[0].StaffName, GetCleanerName2 =_user[1].StaffName , Message = "产生打扫人员" };
            }
            else
            {
                throw new Exception("用户异常");
            }
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
        private List<int> ProduceRandom(int count)
        {
            int[] values = new int[2];
            List<int> str = new List<int>();
            Random random = new Random();
            if (count > 1 && count <= 4)
            {
                str.Add(random.Next(0, count));
                str.Add(random.Next(0, count));
                return str;
            }
            else
            {
                for (int i = 0; i < 2; i++)
                    values[i] = random.Next(0, count);
                if (values[0] == values[1])
                {
                    values[1] = random.Next(0, count);
                }
                str.Add(values[0]);
                str.Add(values[1]);
                return str;
            }
        }
    }
}
