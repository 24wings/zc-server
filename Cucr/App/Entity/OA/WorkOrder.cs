using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cucr.CucrSaas.App.Entity.OA
{

    /// <summary>
    /// 工单
    /// </summary>
    [Table("oa_workorder")]
    public class WorkOrder : BaseEntity
    {

        /// <summary>
        /// 公司Id
        /// </summary>
        /// <value></value>
        public string companyId { get; set; }
        /// <summary>
        /// 项目id
        /// </summary>
        /// <value></value>
        public string projectId { get; set; }
        /// <summary>
        /// 发布人id
        /// </summary>
        /// <value></value>
        public string userId { get; set; }
        /// <summary>
        /// 发布人姓名
        /// </summary>
        /// <value></value>
        public string name { get; set; }
        /// <summary>
        /// 发布标题
        /// </summary>
        /// <value></value>
        public string title { get; set; }
        /// <summary>
        /// 周期(天)
        /// </summary>
        /// <value></value>
        public decimal? cycle { get; set; }
        /// <summary>
        /// 已经使用工时
        /// </summary>
        /// <value></value>
        public decimal? useworkingHours { get; set; }
        /// <summary>
        /// 总工时
        /// </summary>
        /// <value></value>
        public decimal? workingHours { get; set; }
        /// <summary>
        /// 级别
        /// </summary>
        /// <value></value>
        public string level { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        /// <value></value>
        public string projectName { get; set; }
        /// <summary>
        /// 指派人Id
        /// </summary>
        /// <value></value>
        public string assignId { get; set; }
        /// <summary>
        /// 指派人姓名
        /// </summary>
        /// <value></value>
        public string assignName { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        /// <value></value>
        public string enclosure { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        /// <value></value>
        public int? beginTime { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        /// <value></value>
        public int? beoverdueTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        /// <value></value>
        public int? endTime { get; set; }
        /// <summary>
        /// 是否超时
        /// </summary>
        /// <value></value>
        public bool timeout { get; set; }
        /// <summary>
        /// 超时原因
        /// </summary>
        /// <value></value>
        public string timeoutReason { get; set; }
        /// <summary>
        /// 通知对象(用户ID集合)
        /// </summary>
        /// <value></value>
        public string noticePerson { get; set; }
        /// <summary>
        /// 通知对象
        /// </summary>
        /// <value></value>
        public string noticePersonName { get; set; }
        /// <summary>
        /// 工单描述
        /// </summary>
        /// <value></value>
        public string explain { get; set; }
        /// <summary>
        /// 工单状态
        /// </summary>
        /// <value></value>
        public WorkOrderStatus? wctype { get; set; }
        /// <summary>
        /// 取消原因
        /// </summary>
        /// <value></value>
        public string cancelReason { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        /// <value></value>
        public string images { get; set; }

    }

    /// <summary>
    /// 0：待开工  ；  1：进行中；2：已完成； -1：已取消
    /// </summary>
    public enum WorkOrderStatus
    {
        /// <summary>
        ///  待开工
        /// </summary>
        Wait,
        /// <summary>
        ///  进行中
        /// </summary>

        Process,
        /// <summary>
        /// 已完成
        /// </summary>

        Finish,
        /// <summary>
        ///  已取消
        /// </summary>
        Cancel
    }
}