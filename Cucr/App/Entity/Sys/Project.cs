using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Cucr.CucrSaas.App.Entity.OA;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cucr.CucrSaas.App.Entity.Sys {

    /// <summary>
    /// 项目表
    /// </summary>
    [Table ("sys_project")]
    public class Project : BaseEntity {
        /// <summary>
        /// 公司
        /// </summary>
        /// <value></value>
        public string companyId { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        /// <value></value>
        public string projectName { get; set; }
    }
}