using System;
using System.Linq;
using Wings.DataAccess;

namespace Wings.Base.Common.Attrivute {
    /// <summary>
    /// 列特性
    /// </summary>
    public class ColAttribute : Attribute {
        /// <summary>
        /// 标签
        /// </summary>
        /// <value></value>
        public string caption { get; set; }

        public ColDataType dataType { get; set; }
        /// <summary>
        /// 属性
        /// </summary>
        /// <value></value>
        public string dataField { get; set; }
    }
    /// <summary>
    /// 列的数据类型
    /// </summary>
    public enum ColDataType {
        String,
        Number
    }
}