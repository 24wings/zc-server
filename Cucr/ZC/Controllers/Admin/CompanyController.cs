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
using Cucr.CucrSaas.App.DTO;
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
    /// 众筹登录
    /// </summary>
    [Route("api/CucrSaas/ZC/Admin/[controller]")]
    [ApiController]

    public class CompanyController : ControllerBase
    {

        /// <summary>
        ///      众筹数据库驱动
        /// </summary>
        private ClzcContext clzcContext { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_clzcContext"></param>
        public CompanyController(
            ClzcContext _clzcContext
        )
        {
            this.clzcContext = _clzcContext;
        }


    }
}