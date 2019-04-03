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
    /// 通用角色
    /// </summary>
    public static class CommonRole
    {

        ///<summary>
        /// 产品经理
        ///</summary>
        public static string ProductManage { get; } = "4c49cc64-9e33-46cc-ab0e-df4301a51ab9";

        ///<summary>
        /// 游客
        /// </summary>
        public static string Tourist { get; } = "d65ce4e0-9a5c-4348-917f-609d4f446b74";
    }

    /// <summary>
    /// 公司表
    /// </summary>
    [Table("clzc_role")]
    public class Role
    {
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Key]
        public string id { get; set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// 公司名称
        /// </summary> 
        /// <value></value>
        public string name { get; set; }
        /// <summary>
        /// 登录账户
        /// </summary>
        /// <value></value>
        public int? inputTime { get; set; }

    }
}