namespace Cucr.CucrSaas.App.DTO {

    /// <summary>
    /// 获取用户token
    /// </summary>
    public class UserInfoInput {
        /// <summary>
        /// 验证token
        /// </summary>
        /// <value></value>
        public string token { get; set; }
        /// <summary>
        /// 设备id
        /// </summary>
        /// <value></value>
        public string mechineId { get; set; }

    }

}