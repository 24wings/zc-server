using System.ComponentModel.DataAnnotations;
using System.Linq;
using Wings.Base.Common.Attrivute;
using Wings.Base.Common.DVO;
using Wings.DataAccess;

namespace Wings.Base.RBAC.DVO {
    /// <summary>
    /// 数据查询
    /// </summary>
    [View (viewType = ViewType.Table, title = "用户管理页面")]
    public class UserDVO : IDVO<UserDVO> {

        [Key]
        public int id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        /// <value></value>
        [Col (label = "姓名")]
        [Item (label = "用户名", editorType = EditorType.dxTextBox)]
        public string name { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        /// <value></value>
        [Item (label = "登录名")]
        [Col (label = "登录名")]
        public string userName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        /// <value></value>
        [Item (label = "密码")]
        [Col (label = "密码")]
        public string password { get; set; }

        public static IQueryable<UserDVO> query (WingsContext ctx) {
            return (from user in ctx.User select new UserDVO { id = user.userId });
        }
    }
}