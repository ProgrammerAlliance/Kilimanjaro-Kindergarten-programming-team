using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.YummyCate.IBLL
{
    public interface IUserBLL
    {
        bool Login(string userInfo);
    }
}
