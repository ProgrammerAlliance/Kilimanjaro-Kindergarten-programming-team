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
        /// <summary>
        /// 查询用户订餐信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        List<Order> FindByUserOrder(string userName);
    }
}
