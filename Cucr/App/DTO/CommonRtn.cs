using System.Collections.Generic;

namespace Cucr.CucrSaas.App.DTO
{

    /// <summary>
    /// 通用响应体
    /// </summary>
    public class CommonRtn
    {

        /// <summary>
        /// 消息
        /// </summary>
        /// <value></value>
        public string message { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        /// <value></value>
        public bool success { get; set; }
        /// <summary>
        /// 返回给前端的数据
        /// </summary>
        /// <value></value>
        public Dictionary<string, object> resData { get; set; }

        /// <summary>
        /// 便捷方法返回错误消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static CommonRtn Error(string message)
        {
            return new CommonRtn { success = false, message = message };
        }
        /// <summary>
        /// 便捷方法返回正确消息
        /// </summary>
        /// <param name="resData"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static CommonRtn Success(Dictionary<string, object> resData, string message = "")
        {
            return new CommonRtn { success = false, message = message, resData = resData };
        }

    }
}