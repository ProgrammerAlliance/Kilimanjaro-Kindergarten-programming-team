using NLC.YummyCate.BLL;
using NLC.YummyCate.Common;
using NLC.YummyCate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NLC.YummyCate.WebApi.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public OperationResult<Boolean> UserLogin(string username, string password)
        {
            Log log = new Log("E:/log/Log.txt");
            log.log("username:" + username + "," + "password:" + password);
            UserBLL userBLL = new UserBLL();
            log.log("返回结果:" + userBLL.UserLogin(username, password).ToString());
            return userBLL.UserLogin(username, password);
        }

        public OperationResult<Boolean> Login(string username, string password)
        {
            UserBLL userBLL = new UserBLL();
            return userBLL.UserLogin(username, password);
        }

        [HttpGet]
        public bool Test()
        {
            return true;
        }
    }
}
