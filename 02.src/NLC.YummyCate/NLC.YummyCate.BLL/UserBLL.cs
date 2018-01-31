using NLC.YummyCate.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.YummyCate.BLL
{
    public class UserBLL : IUserBLL
    {
        public bool Login(string userInfo)
        {
            //1.解析UserInfo，得到用户名和密码
            //2.验证用户名的合法性，密码的正确性
            bool b = IsUserName(userInfo);
            bool a = CurrentPassword(userInfo);
            if (b)//用户不对，不登陆
            { return false; }
            else
            {
                if (!a)//密码不对
                { return false; }
            }
            return true;
        }

        /// <summary>
        /// 验证用户是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool IsUserName(string name)
        {
            //创建一个数据环境对象
            DataUsersDataContext dm = new DataUsersDataContext();

            //统计Users表中符合条件的对象的数目
             int num = dm.Users.Count(u => u.Name == name);

            //如果查询得到的数目大于0，说明该用户存在
            bool exist = num > 0;
            return false;
        }
        private bool CurrentPassword(string password)
        {

            return false;
        }

        /// <summary>
        /// 用户登陆
        /// </summary>
        public Users Login(string name, string password)
        {
            DataUsersDataContext dm = new DataUsersDataContext();
            try
            {
                //查询得到指定用户
                Users user = dm.Users.Single(u => u.Name == name);
                return user;
            }
            catch
            {
                return null;
            }
        }

        internal class DataUsersDataContext
        {
        }
    }
}
