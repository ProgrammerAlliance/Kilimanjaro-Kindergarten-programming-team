using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLC.YummyCate.DBUtility;
using System.Data.SqlClient;
using NLC.YummyCate.IDAL;
using System.Linq.Expressions;

namespace NLC.YummyCate.DAL
{
    public class UserDAL : IDal
    {
        void IDal.AddEntity<T>(T entity)
        {
            throw new NotImplementedException();
        }

        void IDal.DeleteEntity<T>(T entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IDal.GetEntities<T>(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        T IDal.GetEntity<T>(int id)
        {
            throw new NotImplementedException();
        }

        bool IDal.UpdateEntity<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
