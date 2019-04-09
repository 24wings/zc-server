using System;
using System.Linq;
using Wings.DataAccess;

namespace Wings.Base.Common.Attrivute {

    /// <summary>
    /// 视图特性
    /// </summary>
    public class ViewAttribute : Attribute {
        /// <summary>
        /// 视图类型
        /// </summary>
        /// <value></value>
        public ViewType viewType { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        /// <value></value>
        public string title { get; set; }

    }

    /// <summary>
    /// 视图类型
    /// </summary>
    public enum ViewType {
        /// <summary>
        /// 表格
        /// </summary>
        Table,
        /// <summary>
        /// 树形
        /// </summary>
        Tree
    }
}