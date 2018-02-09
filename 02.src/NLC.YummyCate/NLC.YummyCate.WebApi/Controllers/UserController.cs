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
            log._Log("username:" + username + "," + "password:" + password);
            UserBLL userBLL = new UserBLL();
            log._Log("返回结果:" + userBLL.UserLogin(username, password).ToString());
            return userBLL.UserLogin(username, password);
        }

        [HttpGet]
        public string Test()
        {
            return string.Format("username:");
        }
    }
}
