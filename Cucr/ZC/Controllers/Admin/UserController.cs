using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Cucr.CucrSaas.Common.DTO;
using Cucr.CucrSaas.ZC.DataAccess;
using Cucr.CucrSaas.ZC.DTO;
using Cucr.CucrSaas.ZC.Entity.Clzc;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Serializers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Cucr.CucrSaas.ZC.Controllers
{

    /// <summary>
    /// 用户系统
    /// </summary>
    // [EnableCors ("AllowAllOrigin")]
    [Route("api/CucrSaas/ZC/Admin/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {

        /// <summary>
        ///      众筹数据库驱动
        /// </summary>
        private ClzcContext clzcContext { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_clzcContext"></param>
        public UserController(
            ClzcContext _clzcContext
        )
        {
            this.clzcContext = _clzcContext;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        [HttpGet]
        public object Get(DataSourceLoadOptions options)
        {
            return DataSourceLoader.Load(this.clzcContext.users, options);
        }

        /// <summary>
        /// 创建组织
        /// </summary>
        /// <param name="bodyData"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Post([FromForm] BodyDataInput bodyData)
        {
            var user = new User();
            JsonConvert.PopulateObject(bodyData.values, user);
            //Validate(order);
            if (!ModelState.IsValid)
                return false;
            this.clzcContext.users.Add(user);
            this.clzcContext.SaveChanges();
            return true;
        }

        /// <summary>
        /// 删除组织
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpDelete]
        public bool Delete([FromForm] string key)
        {

            var user = this.clzcContext.users.Find(key);
            this.clzcContext.users.Remove(user);
            this.clzcContext.SaveChanges();
            return true;
        }
        /// <summary>
        /// 更新组织
        /// </summary>
        /// <param name="bodyData"></param>
        /// <returns></returns>
        [HttpPut]
        public bool Put([FromForm] BodyDataInput bodyData)
        {
            var order = this.clzcContext.users.Find(bodyData.key);
            JsonConvert.PopulateObject(bodyData.values, order);
            this.clzcContext.SaveChanges();
            return true;
        }

    }
}