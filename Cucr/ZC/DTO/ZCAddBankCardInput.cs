using System;
namespace Cucr.CucrSaas.ZC.DTO
{
    /// <summary>
    /// 添加银行卡
    /// </summary>
    public class ZCAddBankCardInput
    {
        /// <summary>
        /// 银行卡号
        /// </summary>
        /// <value></value>
        public string no { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        /// <value></value>
        public string userId { get; set; }
        /// <summary>
        /// 银行卡号
        /// </summary>
        /// <value></value>
        public string bank { get; set; }

        /// <summary>
        /// 是否设为默认
        /// </summary>
        /// <value></value>
        public bool isDefault { get; set; }
        /// <summary>
        /// 所属人
        /// </summary>
        /// <value></value>
        public string belongTo { get; set; }
    }
}