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
    /// 用户表
    /// </summary>
    [Table ("clzc_user")]
    public class User {
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Key]
        public string ID { get; set; } = Guid.NewGuid ().ToString ();
        /// <summary>
        /// 账户
        /// </summary>
        /// <value></value>
        public string account { get; set; }
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
        /// 昵称
        /// </summary>
        /// <value></value>
        public string nickname { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        /// <value></value>
        public string headimg { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        /// <value></value>
        public int? sex { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        /// <value></value>
        public decimal? balance { get; set; }
        /// <summary>
        /// 省份id
        /// </summary>
        /// <value></value>
        public string provinceid { get; set; }
        /// <summary>
        /// 城市id
        /// </summary>
        /// <value></value>
        public string cityid { get; set; }
        /// <summary>
        /// 区域id
        /// </summary>
        /// <value></value>
        public string areaid { get; set; }
        /// <summary>
        /// 省份+城市中文
        /// </summary>
        /// <value></value>
        public string region { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        /// <value></value>
        public int? state { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        /// <value></value>
        public DateTime? createTime { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        /// <value></value>
        public string password { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        /// <value></value>
        public string address { get; set; }
        /// <summary>
        /// 上次登录时间
        /// </summary>
        /// <value></value>
        public DateTime? lastlogintime { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        /// <value></value>
        public string idcard { get; set; }
        /// <summary>
        /// 自动签名
        /// </summary>
        /// <value></value>
        public string autograph { get; set; }
        /// <summary>
        /// 职业
        /// </summary>
        /// <value></value>
        public string profession { get; set; }
        /// <summary>
        /// 个人首页
        /// </summary>
        /// <value></value>
        public string homepage { get; set; }
        /// <summary>
        /// 1注册账号，2生成账号
        /// </summary>
        /// <value></value>
        public string type { get; set; }
        /// <summary>
        /// 身份证正面
        /// </summary>
        /// <value></value>
        public string cardFront { get; set; }
        /// <summary>
        /// 身份证反面
        /// </summary>
        /// <value></value>
        public string cardCon { get; set; }
        /// <summary>
        /// 所属公司
        /// </summary>
        /// <value></value>
        public string companyId { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        /// <value></value>
        public string companyname { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        /// <value></value>
        public int? role { get; set; }
        /// <summary>
        /// 是否认真阅读协议1是0否
        /// </summary>
        /// <value></value>
        public int? isReadProtocol { get; set; }
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <value></value>
        [NotMapped]
        public List<Role> roles { get; set; }
    }
}