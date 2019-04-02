using System;
namespace Cucr.CucrSaas.Common.DTO
{
    /// <summary>
    /// 文件上传
    /// </summary>
    public class UploadFileInput
    {
        /// <summary>
        /// base64格式
        /// </summary>
        /// <value></value>
        public string base64 { get; set; }
        /// <summary>
        /// 文件扩展名
        /// </summary>
        /// <value></value>
        public string ext { get; set; } = "png";
    }
}