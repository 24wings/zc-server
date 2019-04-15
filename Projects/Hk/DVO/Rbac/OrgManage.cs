using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wings.Base.Common.Attrivute;
namespace Wings.Projects.Hk.DVO.Rbac {
    /// <summary>
    /// 组织管理
    /// </summary>
    [DataSource (url = "/api/Hk/DVO")]
    [TreeListView (title = "组织管理", parentIdExpr = "parentId", keyExpr = "orgId")]
    [Table ("Org")]
    public class OrgManage {
        /// <summary>
        /// 组织id
        /// </summary>
        /// <value></value>
        [Key]
        public int orgId { get; set; }
        /// <summary>
        /// 组织名称
        /// </summary>
        /// <value></value>
        [Col (caption = "组织名称")]
        [Item (label = "组织名称")]
        public string orgName { get; set; }
        /// <summary>
        /// 组织id
        /// </summary>
        /// <value></value>

        public int? parentId { get; set; }

        [NotMapped]
        public OrgManage parent { get; set; }

    }
}