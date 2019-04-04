using System;
namespace Cucr.CucrSaas.ZC.DTO {
    /// <summary>
    /// 添加银行卡
    /// </summary>
    public class ZCSaveUserInfoInput {
        /// <summary>
        /// 用户id
        /// </summary>
        /// <value></value>
        public string userId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <value></value>
        public string name { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        /// <value></value>
        public string nickname { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        /// <value></value>
        public string headImg { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        /// <value></value>
        public int? sex { get; set; }
        /// <summary>
        /// 地区
        /// </summary>
        /// <value></value>
        public string region { get; set; }

        public string address { get; set; }
        public string companyName { get; set; }
        public string idCard { get; set; }

        public string provinceId { get; set; }
        public string cityId { get; set; }
        public string areaId { get; set; }
        public string homePage { get; set; }
        public string profession { get; set; }
        public string autograph { get; set; }
        /// <summary>
        /// 银行卡
        /// </summary>
        /// <value></value>
        public NewBankCard bank { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public class NewBankCard {
        /// <summary>
        /// 银行卡号
        /// </summary>
        /// <value></value>
        public string no { get; set; }
        /// <summary>
        /// 银行
        /// </summary>
        /// <value></value>
        public string bank { get; set; }
        public bool? isDefault { get; set; }
        public string belongTo { get; set; }
    }
}