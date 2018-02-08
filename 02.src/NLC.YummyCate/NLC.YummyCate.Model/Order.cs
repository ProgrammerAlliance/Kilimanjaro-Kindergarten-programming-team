using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.YummyCate.Model
{
    public class Order
    {
        /// <summary>
        /// 点餐号
        /// </summary>
        public int OrderID { get; set; }

		/// <summary>
		/// 菜单号
		/// </summary>
		public int OrderMenuCount { get; set; } 

        /// <summary>
        /// 订餐的人数
        /// </summary>
        public int OrderPersonCount { get; set; }

        /// <summary>
        /// 订餐总金额
        /// </summary>
        public float OrderMoney { get; set; }

        /// <summary>
        /// 预算金额
        /// </summary>
        public float Budget { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// 打扫人员
        /// </summary>
        public int ClearPeople { get; set; }

        /// <summary>
        /// 订餐状态
        /// </summary>
        public bool OrderingStateName { get; set; }

		/// <summary>
		/// 订餐状态编号
		/// </summary>
		public OrderingStateEnum OrderingStateID { get; set; }

		/// <summary>
		/// 员工号
		/// </summary>
		public int StaffID { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
		public string StaffName { get; set; }
    }
}
