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
        OrderBLL orderBLL = new OrderBLL();
        // GET: api/Order
        [HttpPost]
        public OperationResult<Boolean> StaffOrder([FromBody]UserInfo user)
        {
            return orderBLL.ConfirmOrder(user.UserName,user.Meno);
        }

        [HttpDelete]
        public OperationResult<Boolean> DeleteStaffCancelOrder(UserInfo user)
        {
            return orderBLL.CancelOrder(user.UserName);
        }

		[HttpGet]
		public OperationResult<Boolean> ProduceCleanerName()
		{
			return orderBLL.ProduceCleaner();
		}

        [HttpGet]
        public List<StaffInformationResult> GetAllStaffInfo()
        {
            return orderBLL.GetStaffInformation();
        }
	}
}
