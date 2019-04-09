using System.Linq;
using Wings.DataAccess;

namespace Wings.Base.Common.DVO {
    /// <summary>
    /// DVO需要实现增删改查方法
    /// </summary>
    public class IDVO<T> {
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public static IQueryable query (WingsContext ctx) {
            return (from user in ctx.User select user);

        }

    }

}