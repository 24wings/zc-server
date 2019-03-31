using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cucr.CucrSaas.App.Entity.OA {

    /// <summary>
    /// 出勤记录
    /// </summary>
    [Table ("oa_incard")]
    public class Incard {
        /// <summary>
        /// id
        /// </summary>
        /// <returns></returns>
        public string id { get; set; } = Guid.NewGuid ().ToString ();
        /// <summary>
        /// 公司id
        /// </summary>
        /// <value></value>
        public string companyId { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        /// <value></value>
        public string userId { get; set; }
        /// <summary>
        /// 打卡类型
        /// </summary>
        /// <value></value>
        public IncardType? cardType { get; set; }
        /// <summary>
        /// 打卡时间
        /// </summary>
        /// <value></value>
        public DateTime? time { get; set; }
        /// <summary>
        /// 打卡时间类型,
        /// 0:一次,1:二次,2:三次,3:四次
        /// 
        /// </summary>
        /// <value></value>
        public InCardTimeType? cardTimeType { get; set; }
        /// <summary>
        /// 打卡结果
        /// </summary>
        /// <value></value>
        public IncardTimeResult? result { get; set; }
        /// <summary>
        /// 流失号
        /// </summary>
        /// <value></value>
        public string serialNumber { get; set; }
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
        /// 保留字段1
        /// </summary>
        /// <value></value>
        public string reservedSpace1 { get; set; }
        /// <summary>
        /// 保留字段2
        /// </summary>
        /// <value></value>
        public string reservedSpace2 { get; set; }
        /// <summary>
        /// 保留字段3
        /// </summary>
        /// <value></value>
        public string reservedSpace3 { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <value></value>

        public DateTime? createTime { get; set; } = DateTime.Now;
    }
    /// <summary>
    /// 打卡类型(0：上下班打卡；1：补打卡)
    /// </summary>
    public enum IncardType {

        /// <summary>
        /// 上下班打卡
        /// </summary>
        Normal,
        /// <summary>
        /// 补卡
        /// </summary>
        FixedCard
    }
    /// <summary>
    /// 打卡时段(0：第一次打卡；1：第二次打卡；2：第三次打卡；3：第四次打卡)
    /// </summary>
    public enum InCardTimeType {
        /// <summary>
        /// 第一次打卡；
        /// </summary>
        First,
        /// <summary>
        /// 第一次打卡；
        /// </summary>
        Second,
        /// <summary>
        /// 第三次打卡；
        /// </summary>
        Third,
        /// <summary>
        /// 第四次打卡；
        /// </summary>
        Fourth
    }
    /// <summary>
    /// 出勤结果
    /// </summary>
    public enum IncardTimeResult {
        // 打卡结果(0：正常；1：迟到；2：早退；)
        /// <summary>
        /// 正常
        /// </summary>
        Normal,
        /// <summary>
        /// 迟到
        /// </summary>
        Late,
        /// <summary>
        /// 早退
        /// </summary>
        Early

    }
}