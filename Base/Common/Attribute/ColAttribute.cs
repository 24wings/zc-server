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
        public string label { get; set; }

        public ColType colType { get; set; }
    }

    public enum ColType {
        String,
        Number
    }
}