using NLC.YummyCate.BLL;
using NLC.YummyCate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NLC.YummyCate.WebApi.Controllers
{
    public class OrderController : ApiController
    {
        // GET: api/Order
        [HttpGet]
        public OperationResult<Boolean> StaffOrder(string username)
        {
            // Log log = new Log("E:/log/Log.txt");
            // log.log("username:" + username + "," + "password:" + password);
            OrderBLL orderBLL = new OrderBLL();
            // log.log("返回结果:" + userBLL.UserLogin(username, password).ToString());
            return orderBLL.ConfirmOrder(username);
        }

        [HttpGet]
        public OperationResult<Boolean> StaffCancelOrder(string username)
        {
            // Log log = new Log("E:/log/Log.txt");
            // log.log("username:" + username + "," + "password:" + password);
            OrderBLL orderBLL = new OrderBLL();
            // log.log("返回结果:" + userBLL.UserLogin(username, password).ToString());
            return orderBLL.CancelOrder(username);
        }

        [HttpGet]
        public OperationResult<int> Count()
        {
            OrderBLL orderBLL = new OrderBLL();
            return orderBLL.CountOrderNumber();
        }
    }
}
