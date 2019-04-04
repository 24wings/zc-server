using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Cucr.CucrSaas.App.Entity.OA;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cucr.CucrSaas.ZC.Entity.Clzc
{

    /// <summary>
    /// 项目经理申请
    /// </summary>

    [Table("clzc_project_manager_apply")]
    public class ProjectManageApply
    {
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Key]
        public string id { get; set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// 申请用户Id
        /// </summary>
        /// <value></value>
        public string userId { get; set; }

        /// <summary>
        /// 申请的公司
        /// </summary> 
        /// <value></value>

        public string companyId { get; set; }
        /// <summary>
        /// 登录账户
        /// </summary>
        /// <value></value>
        public string summary { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        /// <value></value>
        public string fileId { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        /// <value></value>
        public int inputTime { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        /// <value></value>
        public string phone { get; set; }
        /// <summary>
        /// 项目审核状态
        /// </summary>
        /// <value></value>
        public ProjectManageApplyStatus status { get; set; }
        /// <summary>
        /// 申请人
        /// </summary>
        /// <value></value>
        public string name { get; set; }
    }
    /// <summary>
    /// 项目经理申请状态
    /// </summary>
    public enum ProjectManageApplyStatus
    {
        /// <summary>
        /// 已提交
        /// </summary>
        Submit,
        /// <summary>
        /// 审核通过
        /// </summary>
        Approve,
        /// <summary>
        /// 已拒绝
        /// </summary>
        Reject
    }
}