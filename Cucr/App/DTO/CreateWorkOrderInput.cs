namespace Cucr.CucrSaas.App.Controllers {
    /// <summary>
    /// 创建工单输入
    /// </summary>
    public class CreateWorkOrderInput {
        /// <summary>
        /// 标题
        /// </summary>
        /// <value></value>
        public string title { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        /// <value></value>
        public int endTime { get; set; }

        /// <summary>
        /// 指派负责人Id
        /// </summary>
        /// <value></value>
        public string assignId { get; set; }
        /// <summary>
        /// 工单通知人
        /// </summary>
        /// <value></value>
        public string noticePerson { get; }

        /// <summary>
        /// 附件id字符串 ,以","连接
        /// </summary>
        /// <value></value>
        public string enclosure { get; set; }
        /// <summary>
        /// 图片文件列表
        /// </summary>
        /// <value></value>
        public string images { get; set; }

        //  cycle, useworkingHours, workingHours, level, projectName, assignId, assignName, enclosure, beginTime, beoverdueTime, endTime, timeout, timeoutReason, noticePerson, noticePersonName, explain, wctype, cancelReason, inputPerson, inputTime, orderBy, reservedSpace1, reservedSpace2, reservedSpace3
    }
}