using System;
using System.Linq;
using Wings.DataAccess;

namespace Wings.Base.Common.Attrivute {
    /// <summary>
    /// 表单特性
    /// </summary>
    public class ItemAttribute : Attribute {
        /// <summary>
        /// 标签
        /// </summary>
        /// <value></value>
        public string label { get; set; }
        /// <summary>
        /// 编辑类型
        /// </summary>
        /// <value></value>
        public EditorType editorType { get; set; }
        /// <summary>
        /// 数据字段
        /// </summary>
        /// <value></value>
        public string dataField { get; set; }

    }
    /// <summary>
    /// 表单控件类型
    /// </summary>
    public enum EditorType {
        dxAutocomplete,
        dxCalendar,
        dxCheckBox,
        dxColorBox,
        dxDateBox,
        dxDropDownBox,
        dxLookup,
        dxNumberBox,
        dxRadioGroup,
        dxRangeSlider,
        dxSelectBox,
        dxSlider,
        dxSwitch,
        dxTagBox,
        dxTextArea,
        dxTextBox,

    }
}