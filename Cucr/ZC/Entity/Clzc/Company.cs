using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Cucr.CucrSaas.App.Entity.OA;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cucr.CucrSaas.ZC.Entity.Clzc {

    /// <summary>
    /// 公司表
    /// </summary>
    [Table ("clzc_company")]
    public class Company {
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Key]
        public string id { get; set; } = Guid.NewGuid ().ToString ();
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
        /// <summary>
        /// 注册资金
        /// </summary>
        /// <value></value>
        public decimal? capital { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        /// <value></value>
        public string area { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        /// <value></value>
        public string address { get; set; }
        /// <summary>
        /// 法人
        /// /// </summary>
        /// <value></value>
        public string legalPerson { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        /// <value></value>
        public string phone { get; set; }
        /// <summary>
        /// 座机
        /// </summary>
        /// <value></value>
        public string telephone { get; set; }
        /// <summary>
        /// 营业执照
        /// </summary>
        /// <value></value>
        public string license { get; set; }
        /// <summary>
        /// 经营范围
        /// </summary>
        /// <value></value>
        public string business { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        /// <value></value>
        public DateTime? registerDate { get; set; }
    }
}