using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wings.Base.Common.Entity;

namespace Wings.Base.RBAC.Entity {
    /// <summary>
    /// 用户管理
    /// </summary>
    [Table ("user")]
    public partial class User {
        /// <summary>
        /// 主键
        /// </summary>
        /// <value></value>
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <value></value>
        [Column (TypeName = "varchar(45)")]
        public string name { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        /// <value></value>
        [Column (TypeName = "datetime")]
        public DateTime? createTime4 { get; set; }

        [Column (TypeName = "datetime")]
        public DateTime? createTime5 { get; set; }

        public OrderNo orderNo { get; set; }
        // public int? orderNoId { get; set; }

        public OssFile headImage { get; set; }

        [NotMapped]
        public int? headImageId { get; set; }

    }
}