using NLC.YummyCate.IDAL;
using NLC.YummyCate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLC.YummyCate.DAL
{
    public class OrderDAL : IEntityDAL<Order>
    {
        public void AddEntity(Order entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Order entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetEntities(Expression<Func<Order, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Order GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
