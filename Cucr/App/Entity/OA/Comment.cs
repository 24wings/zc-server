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
    /// 评论表
    /// </summary>
    [Table ("oa_comment")]
    public class Comment {
        /// <summary>
        /// id
        /// </summary>
        /// <returns></returns>
        public string id = Guid.NewGuid ().ToString ();
        /// <summary>
        /// 对应主键
        /// </summary>
        /// <value></value>
        public string dyId { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        /// <value></value>
        public string personid { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        /// <value></value>
        public string content { get; set; }
        /// <summary>
        /// 评论时间
        /// </summary>
        /// <value></value>
        public DateTime? commentTime { get; set; }
    }
}