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
    public class UserBLL
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool UserLogin(string userName, string password)
        {
            IUserDAL userDAL = UserDALFactory.CreateUserDAL();
            List<User> _user = userDAL.FindByUserName(userName);
            if (_user == null || _user.Count == 0)
            {
                return false;
            }
            else if (_user.Count == 1)
            {
                if (password != _user[0].Password)  
                {
                    return false;
                }
            }
            return true;
        }

    }
}
