using NLC.YummyCate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.YummyCate.IDAL
{
    public interface IUserDAL
    {
        /// <summary>
        /// 根据用户名查询
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        List<User> FindByUserName(String userName);
    }
}
