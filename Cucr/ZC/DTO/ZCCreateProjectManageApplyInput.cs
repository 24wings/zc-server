namespace Cucr.CucrSaas.ZC.DTO
{
    /// <summary>
    /// 创建项目经理申请
    /// </summary>
    public class ZCCreateProjectManageApplyInput
    {
        /// <summary>
        /// 申请用户Id
        /// </summary>
        /// <value></value>
        public string userId { get; set; }

        /// <summary>
        /// 申请的公司
        /// </summary> 
        /// <value></value>

        public string companyId { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        /// <value></value>
        public string summary { get; set; }
        /// <summary>
        /// 文件id
        /// </summary>
        /// <value></value>
        public string fileId { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        /// <value></value>
        public string phone { get; set; }
        /// <summary>
        /// 申请人
        /// </summary>
        /// <value></value>
        public string name { get; set; }

    }
}