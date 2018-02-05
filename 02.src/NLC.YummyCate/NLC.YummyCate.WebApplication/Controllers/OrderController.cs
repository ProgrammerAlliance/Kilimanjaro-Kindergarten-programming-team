using NLC.YummyCate.BLL;
using NLC.YummyCate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NLC.YummyCate.WebApplication.Controllers
{
    public class OrderController : ApiController
    {
        [HttpGet]
        // GET: api/Order
        public OperationResult<Boolean> StaffOrder(string username)
        {
         OrderBLL userBLL = new OrderBLL();
         return userBLL.ConfirmOrder(username);
        }
    }
}
