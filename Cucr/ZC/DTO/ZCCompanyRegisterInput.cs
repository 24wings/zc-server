using System;

namespace Cucr.CucrSaas.ZC.DTO
{

    /// <summary>
    /// 众筹注册输入
    /// </summary>
    public class ZCCompanyRegisterInput
    {
        /// <summary>
        /// 姓名
        /// </summary>
        /// <value></value>
        public string name { get; set; }
        /// <summary>
        /// 账户
        /// </summary>
        /// <value></value>
        public string account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        /// <value></value>
        public string pwd { get; set; }
        /// <summary>
        /// 注册资金
        /// </summary>
        /// <value></value>
        public decimal? capital { get; set; }
        /// <summary>
        /// 地区
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
        /// </summary>
        /// <value></value>
        public string legalPerson { get; set; }
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
        /// 注册日期
        /// </summary>
        /// /// <value></value>
        public DateTime? registerDate { get; set; }
        /// <summary>
        /// 身份证反面
        /// </summary>
        /// <value></value>
        public string cardNo { get; set; }
        /// <summary>
        /// 身份证正面照
        /// </summary>
        /// <value></value>
        public string cardFront { get; set; }
    }
}