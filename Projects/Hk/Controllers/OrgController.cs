using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wings.Base.Common.Attrivute;
using Wings.Base.Common.DTO;
using Wings.DataAccess;

namespace Wings.Projects.Hk.Controllers {
    /// <summary>
    /// 组织管理
    /// </summary>
    [ApiController]
    public class OrgController {
        private HkContext hk { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_hk"></param>
        public OrgController (HkContext _hk) { hk = _hk; }

    }
}