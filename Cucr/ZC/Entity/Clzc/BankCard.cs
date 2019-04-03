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
    /// 银行卡
    /// </summary>
    [Table("clzc_bankcard")]
    public class BankCard
    {

        /// <summary>
        /// 银行卡
        /// </summary>
        /// <value></value>
        public string id { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        /// <value></value>
        public string userId { get; set; }
        /// <summary>
        /// 银行卡号
        /// </summary>
        /// <value></value>
        public string no { get; set; }
        /// <summary>
        /// 银行卡银行
        /// </summary>
        /// <value></value>
        public string bank { get; set; }
        /// <summary>
        /// 卡号所属人
        /// </summary>
        /// <value></value>
        public string belongTo { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <value></value>
        public DateTime? createTime { get; set; }
        /// <summary>
        /// 设置为默认
        /// </summary>
        public bool? isDefault = false;

    }
}