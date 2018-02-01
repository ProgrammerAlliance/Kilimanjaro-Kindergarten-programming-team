using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.YummyCate.Model
{
    public class User : ModelBase
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 权限编号
        /// </summary>
        public int AuthorityNumber { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string AuthorityName { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        public string StaffName { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepatementName { get; set; }

        /// <summary>
        /// 部门编号
        /// </summary>
        public int StaffID { get; set; }


    }
}
