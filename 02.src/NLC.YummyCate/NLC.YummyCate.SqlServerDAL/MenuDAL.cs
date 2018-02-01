using NLC.YummyCate.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLC.YummyCate.DAL
{
    public class MenuDAL : IDal
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
