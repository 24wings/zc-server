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
    [Table("clzc_company")]
    public class Company
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
        public string account { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        /// <value></value>
        public string password { get; set; }
        // capital, area, address, legalPerson, phone, telephone, license, business, registerDate
    }
}