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
    /// 公司表
    /// </summary>
    [Table("clzc_user")]
    public class User
    {
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Key]
        public string ID { get; set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// 公司名称
        /// </summary> 
        /// <value></value>
        public string name { get; set; }

        /// <summary>
        /// 角色列表
        /// </summary>
        /// <value></value>
        public string roleIds { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        /// <value></value>
        public string phone { get; set; }
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <value></value>
        [NotMapped]
        public List<Role> roles { get; set; }
    }
}