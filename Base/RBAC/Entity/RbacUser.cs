using System;
using System.Collections.Generic;

namespace Wings.Base.RBAC.Entity
{
    public partial class RbacUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <value></value>
        public DateTime? createTime { get; set; }
    }
}
