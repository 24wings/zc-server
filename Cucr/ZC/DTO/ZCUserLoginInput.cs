namespace Cucr.CucrSaas.ZC.DTO {

    /// <summary>
    /// 众筹用户登录
    /// </summary>
    public class ZCUserLoginInput {
        /// <summary>
        /// 密码
        /// </summary>
        /// <value></value>
        public string pwd { get; set; }
        /// <summary>
        /// 操作
        /// </summary>
        /// <value></value>
        public string option { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        /// <value></value>
        public string phone { get; set; }
    }
}