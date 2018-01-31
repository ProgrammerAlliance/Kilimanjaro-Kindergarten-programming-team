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
        public void ConfirmOrder() 
        {

        }
        /// <summary>
        /// 取消订餐
        /// </summary>
        public void CancelOrder() 
        {

        }
        /// <summary>
        /// 产生打扫人员
        /// </summary>
        public void ProduceCleaner() 
        {
			Random rd = new Random();
			int i = rd.Next(1, 15);//15是order表的orderid,或者个数
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
    }
}
