using NLC.YummyCate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.YummyCate.IDAL
{
   public interface  IOrderDAL
    {
        /// <summary>
        /// 插入用户订餐信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
       int InsertUserOrder(String userName);
        /// <summary>
        /// 取消用户订餐信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        int DeleteUserOrder(String userName);
        int CountUserOrder();
        /// <summary>
        /// 查询用户订餐信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        List<StaffInformationResult> FindByUserOrder();

		/// <summary>
		/// 随机产生打扫人员
		/// </summary>
		/// <param name="num1"></param>
		/// <param name="num2"></param>
		/// <returns></returns>
		List<Order> FindCleaner(int num1, int num2);
		
		
	}
}
