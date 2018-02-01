using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.YummyCate.Model
{
	public class Order:ModelBase
	{
		/// <summary>
		/// 点餐号
		/// </summary>
		public int OrderPointNumber { get; set; }

		/// <summary>
		/// 订餐的人数
		/// </summary>
		public int OrderNumber { get; set; }

		/// <summary>
		/// 订餐总金额
		/// </summary>
		public float TotalAmount { get; set; }

		/// <summary>
		/// 预算金额
		/// </summary>
		public float BudgetAmount { get; set; }

		/// <summary>
		/// 时间
		/// </summary>
		public DateTime Time { get; set; }

		/// <summary>
		/// 打扫人员
		/// </summary>
		public int CleanStaff { get; set; }

		/// <summary>
		/// 订餐状态
		/// </summary>
		public bool OrderState { get; set; }

	}
}
