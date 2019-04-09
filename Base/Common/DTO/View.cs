using System;
using System.Collections.Generic;
using Wings.Base.Common.Attrivute;

namespace Wings.Base.Common.DTO {
    /// <summary>
    /// 列
    /// </summary>
    public class Col {
        /// <summary>
        /// 标签
        /// </summary>
        /// <value></value>
        public string label { get; set; }
    }
    /// <summary>
    /// 表单元数据
    /// </summary>
    public class Item {
        /// <summary>
        /// 标签
        /// </summary>
        /// <value></value>
        public Label label { get; set; }
        /// <summary>
        /// 编辑类型
        /// </summary>
        /// <value></value>
        public string editorType { get; set; }

        /// <summary>
        /// 数据字段
        /// </summary>
        /// <value></value>
        public string dataField { get; set; }
    }
    /// <summary>
    /// 视图元数据
    /// </summary>
    public class View {
        /// <summary>
        /// 视图类型
        /// </summary>
        /// <value></value>
        public ViewType viewType { get; set; }

        /// <summary>
        /// 页面标题
        /// </summary>
        /// <value></value>
        public string title { get; set; }

        /// <summary>
        /// 列
        /// </summary>
        /// <value></value>
        public List<Col> cols { get; set; }
        /// <summary>
        /// 表单字段
        /// </summary>
        /// <value></value>
        public List<Item> items { get; set; }
    }
    /// <summary>
    /// 标签文本
    /// </summary>
    public class Label {
        /// <summary>
        /// 标签文本
        /// </summary>
        /// <value></value>
        public string text { get; set; }
        //    visible?: boolean, showColon?: boolean, location?: 'left' | 'right' | 'top', alignment?: 'center' | 'left' | 'right' };
    }
}