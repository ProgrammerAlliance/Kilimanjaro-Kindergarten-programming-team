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
        public OperationResult<Boolean> UserLogin(string userName, string password)
        {
            IUserDAL userDAL = UserDALFactory.CreateUserDAL();
            List<User> _user = userDAL.FindByUserName(userName);
            OrderBLL orderBLL = new OrderBLL();
            if (_user == null || _user.Count <= 0)
            {
                return new OperationResult<bool>() { Result = false, Message = "用户名或密码错误" };
            }
            else if (_user.Count == 1)
            {
                if (password != _user[0].Pwd)
                {
                    return new OperationResult<bool>() { Result = false, Message = "用户名或密码错误" };
                }

                if (_user[0].TypeID == AuthorityEnum.NormalUser)
                {
                    return new OperationResult<bool>() { Result = true, Message = "登录成功", Authority = AuthorityEnum.NormalUser, OrderingState = orderBLL.IsOrder(userName),Meno=orderBLL.IsMeno(userName) };
                }
                else if (_user[0].TypeID == AuthorityEnum.Administor)
                {
                    return new OperationResult<bool>() { Result = true, Message = "登录成功", Authority = AuthorityEnum.Administor, OrderingState = orderBLL.IsOrder(userName), Count = orderBLL.CountOrderNumber() };
                }
                else
                {
                    throw new Exception("用户异常");
                }
            }
            else
            {
                return new OperationResult<bool>() { Result = false, Message = "用户名或密码错误" };
            }
        }


    }
}
