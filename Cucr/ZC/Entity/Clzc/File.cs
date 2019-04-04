using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Cucr.CucrSaas.App.Entity.OA;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cucr.CucrSaas.ZC.Entity.Clzc {
    /// <summary>
    /// 文件
    /// </summary>
    [Table ("sys_file")]
    public class File {
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        public string ID { get; set; } = Guid.NewGuid ().ToString ();
        /// <summary>
        /// 文件上传路径
        /// </summary>
        /// <value></value>
        public string PATH { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        /// <value></value>
        public int? FILETYPE { get; set; }
        /// <summary>
        /// 增加时间
        /// </summary>
        /// <value></value>
        public int? ADDTIME { get; set; }
        /// <summary>
        /// 编辑世界级
        /// </summary>
        /// <value></value>
        public int? EDITTIME { get; set; }
        /// <summary>
        /// 文件状态
        /// </summary>
        /// <value></value>
        public int FILESTATE { get; set; }
    }
}