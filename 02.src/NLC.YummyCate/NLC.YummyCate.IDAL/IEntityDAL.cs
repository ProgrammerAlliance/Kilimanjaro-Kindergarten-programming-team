using NLC.YummyCate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLC.YummyCate.IDAL
{
    public interface IEntityDAL<T> where T : ModelBase
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void AddEntity(T entity);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteEntity(T entity);

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateEntity(T entity);

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        IEnumerable<T> GetEntities(Expression<Func<T, bool>> expression);

        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetEntity(int id);
    }
}
