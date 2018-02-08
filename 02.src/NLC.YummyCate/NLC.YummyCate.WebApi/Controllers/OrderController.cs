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
        public OperationResult<Boolean> StaffOrder(string username, string meno)
        {
            OrderBLL orderBLL = new OrderBLL();
            return orderBLL.ConfirmOrder(username, meno);
        }

        [HttpGet]
        public OperationResult<Boolean> StaffCancelOrder(string username)
        {
            OrderBLL orderBLL = new OrderBLL();
            return orderBLL.CancelOrder(username);
        }

		[HttpGet]
		public OperationResult<Boolean> ProduceCleanerName()
		{
			OrderBLL orderBLL = new OrderBLL();
			return orderBLL.ProduceCleaner();
		}

        [HttpGet]
        public List<StaffInformationResult> GetAllStaffInfo()
        {
            OrderBLL orderBLL = new OrderBLL();
            return orderBLL.GetStaffInformation();
        }
	}
}
