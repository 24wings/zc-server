using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wings.Base.Common.Entity;

namespace Wings.Base.RBAC.Entity {
    /// <summary>
    /// 用户管理
    /// </summary>
    public partial class Role {
        /// <summary>
        /// 主键
        /// </summary>
        /// <value></value>
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int roleId { get; set; }
        /// <summary>
        /// 角色名
        /// </summary>
        /// <value></value>
        [Column (TypeName = "varchar(45)")]
        public string name { get; set; }

    }
}