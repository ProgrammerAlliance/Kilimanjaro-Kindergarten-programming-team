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

    public class MenuDAL : IEntityDAL<Menu>
    {
        public void AddEntity(Menu entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Menu entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Menu> GetEntities(Expression<Func<Menu, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Menu GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(Menu entity)
        {
            throw new NotImplementedException();
        }
    }
}
