namespace Cucr.CucrSaas.ZC.DTO
{
    /// <summary>
    /// 私人注册
    /// </summary>
    public class ZCPersonSignupInput
    {
        /// <summary>
        /// 名字
        /// </summary>
        /// <value></value>
        public string name { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        /// <value></value>
        public string headImg { get; set; }
        /// <summary>
        /// 地区
        /// </summary>
        /// <value></value>
        public string region { get; set; }
        /// <summary>
        /// 身份证正面照
        /// </summary>
        /// <value></value>
        public string cardFront { get; set; }
        /// <summary>
        /// 身份证反面照文件
        /// </summary>
        /// <value></value>
        public string cardCon { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        /// <value></value>
        public int? sex { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        /// <value></value>
        public string password { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        /// <value></value>
        public string idCard { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        /// <value></value>
        public string nickname { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        /// <value></value>
        public string phone { get; set; }
    }
}