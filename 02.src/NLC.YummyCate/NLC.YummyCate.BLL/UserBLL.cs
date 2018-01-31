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
		/// 验证用户是否存在
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public bool Exist(string name)
		{
			//创建一个数据环境对象
			DataUsersDataContext dm = new DataUsersDataContext();

			//统计Users表中符合条件的对象的数目
			int num = dm.User.Count(u => u.Name == name);

			//如果查询得到的数目大于0，说明该用户存在
			bool exist = num > 0;
			return exist;
		}
	}

	/// <summary>
	/// 用户登陆
	/// </summary>
	public Users Login(string name, string password)
	{
		DataUsersDataContext dm = new DataUsersDataContext();
		try
		{
			//查询得到指定用户
			Users user = dm.Users.Single(u => u.Name == name);
			return user;
		}
		catch
		{
			return null;
		}
	}

	internal class DataUsersDataContext
	{
	}
}
