using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Wings.Base.Common.Attrivute;
using Wings.Base.Common.DTO;
using Wings.DataAccess;

namespace Wings.Projects.Hk.Controllers {

    public class LoginInput {
        /// <summary>
        /// 用户名
        /// </summary>
        /// <value></value>
        public string username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        /// <value></value>
        public string password { get; set; }
    }
    /// <summary>
    /// 自动化管理控制器
    /// </summary>
    [Route ("/api/Hk/Auth")]
    public class AuthController : Controller {

        private HkContext hk { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_hk"></param>
        public AuthController (HkContext _hk) { hk = _hk; }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="input"></param>
        [HttpGet ("[action]")]
        public void login (LoginInput input) {
            var refere = this.HttpContext.Request.Headers.Where (h => h.Key == "Origin").FirstOrDefault ().Value;
            this.HttpContext.Response.Redirect (refere + "/home/page");
        }

    }
}