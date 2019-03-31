using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cucr.CucrSaas.App.Entity.Sys {

    /// <summary>
    /// 系统用户
    /// </summary>
    [Table ("sys_user")]
    public class User {

        /// <summary>
        /// id
        /// </summary>
        /// <value></value>
        // [Key]
        // [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public string id { get; set; } = Guid.NewGuid ().ToString ();
        /// <summary>
        /// 公司Id
        /// </summary>
        /// <value></value>
        public string companyId { get; set; }
        /// <summary>
        /// 组织架构ID
        /// </summary>
        /// <value></value>
        public string jobPostId { get; set; }

        /// <summary>
        /// 岗位ID
        /// </summary>
        /// <value></value>
        public string postId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <value></value>
        public string name { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>
        /// <value></value>
        public string loginAccount { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        /// <value></value>
        public string loginPassword { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        /// <value></value>
        public int? sex { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        /// <value></value>
        public string phone { get; set; }

        /// <summary>
        /// 座机
        /// </summary>
        /// <value></value>
        public string telephone { get; set; }
        /// <summary>
        /// 邮箱地址
        /// </summary>
        /// <value></value>
        public string mail { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        /// <value></value>
        public DocumentType? documentType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        /// <value></value>
        public string documentNumber { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        /// <value></value>

        public DateTime? birth { get; set; }
        /// <summary>
        /// QQ账号
        /// </summary>
        /// <value></value>
        public string qqNumber { get; set; }

        /// <summary>
        /// 微信账号
        /// </summary>
        /// <value></value>
        public string weiXinNumber { get; set; }

        /// <summary>
        /// 婚姻状况
        /// </summary>
        /// <value></value>
        public HYStatus? hyStatus { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        /// <value></value>
        public string address { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        /// <value></value>
        public string autograph { get; set; }
        /// <summary>
        /// 公司
        /// </summary>
        /// <value></value>
        public string companyName { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        /// <value></value>
        public int jobNumber { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        /// <value></value>
        public string department { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        /// <value></value>
        public string position { get; set; }
        /// <summary>
        /// 入职日期
        /// </summary>
        /// <value></value>
        public DateTime? rzDate { get; set; }
        /// <summary>
        /// 转正日期
        /// </summary>
        /// <value></value>
        public DateTime? zzDate { get; set; }
        /// <summary>
        /// 离职日期
        /// </summary>
        /// <value></value>
        public Nullable<DateTime> lzDate { get; set; }

        /// <summary>
        /// 退休日期
        /// </summary>
        /// <value></value>
        public DateTime? txDate { get; set; }

        /// <summary>
        /// 在职状态
        /// </summary>
        /// <value></value>
        public InworkType? inworkType { get; set; }

        /// <summary>
        /// 参加工作日期
        /// </summary>
        /// <value></value>
        public DateTime? workDate { get; set; }
        /// <summary>
        /// 照片
        /// </summary>
        /// <value></value>
        public string photo { get; set; }

        /// <summary>
        /// 紧急联系人1
        /// </summary>
        /// <value></value>
        public string urgentPerson1 { get; set; }
        /// <summary>
        /// 紧急联系人2
        /// </summary>
        /// <value></value>
        public string urgentPerson2 { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        /// <value></value>
        public string headPortrait { get; set; }
        /// <summary>
        /// 技能信息
        /// </summary>
        /// <value></value>
        public string skill { get; set; }
        /// <summary>
        /// 总积分
        /// </summary>
        /// <value></value>
        public int totleScore { get; set; }
        /// <summary>
        /// 合同附件
        ///  </summary>
        /// <value></value>
        public string contract { get; set; }
        /// <summary>
        /// token加密
        /// </summary>
        /// <value></value>
        public string token { get; set; }
        /// <summary>
        /// 登录Ip
        /// </summary>
        /// <value></value>
        public string loginIP { get; set; }
        /// <summary>
        /// 登陆次数
        /// </summary>
        /// <value></value>
        public int loginNumber { get; set; }

        /// <summary>
        /// 是否超级用户
        /// </summary>
        /// <value></value>
        public bool? superUser { get; set; }
        /// <summary>
        /// 启用(0：不启用;1：启用
        /// </summary>
        /// <value></value>
        public bool? enable { get; set; }
        /// <summary>
        /// 录入人
        /// </summary>
        /// <value></value>
        public string inputPerson { get; set; }

        /// <summary>
        /// 录入时间
        /// </summary>
        /// <value></value>
        public DateTime? inputTime { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        /// <value></value>
        public int? orderBy { get; set; }

        /// <summary>
        /// 预留字段1
        /// </summary>
        /// <value></value>
        public string reservedSpace1 { get; set; }

        /// <summary>
        /// 预留字段2
        /// </summary>
        /// <value></value>
        public string reservedSpace2 { get; set; }
        /// <summary>
        /// 预留字段3
        /// </summary>
        /// <value></value>
        public string reservedSpace3 { get; set; }

        /// <summary>
        /// 设备id
        /// </summary>
        /// <value></value>
        public string mechineId { get; set; }
        /// <summary>
        /// 数据的创建时间
        /// </summary>
        /// <value></value>
        public DateTime createTime { get; set; } = DateTime.Now;
    }

    /// <summary>
    ///  证件类型(0:身份证；1：护照；2：军官证；3：其他；)
    /// </summary>
    public enum DocumentType {
        /// <summary>
        ///  身份证
        /// </summary>
        ID,

        /// <summary>
        ///  护照
        /// </summary>
        Passpost,
        /// <summary>
        ///  军官证
        /// </summary>
        Office,
        /// <summary>
        ///  其他
        /// </summary>
        Other
    }
    /// <summary>
    /// 婚姻状况(0：未婚;1：已婚;2：离异)
    /// </summary>
    public enum HYStatus {

        /// <summary>
        ///  未婚
        /// </summary>
        Unmarried,

        /// <summary>
        ///  已婚
        /// </summary>
        Married,

        /// <summary>
        ///  离异
        /// </summary>
        Divorced

    }

    /// <summary>
    /// 在职状态（0：试用期；1：已转正；2：离职；3：退休）
    /// </summary>
    public enum InworkType {

        /// <summary>
        ///  试用期
        /// </summary>
        OnTrial,
        /// <summary>
        ///  已转正
        /// </summary>
        InWork,
        /// <summary>
        ///  离职
        /// </summary>
        Quit,
        /// <summary>
        ///  退休
        /// </summary>
        Retire

    }

}