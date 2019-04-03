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
using Cucr.CucrSaas.App.DataAccess;
using Cucr.CucrSaas.App.DTO;
using Cucr.CucrSaas.App.Entity.Sys;
using Cucr.CucrSaas.App.Service;
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
    /// App登录注册授权接口
    /// </summary>
    // [EnableCors ("AllowAllOrigin")]
    [Route("api/CucrSaas/ZC/[controller]")]
    [ApiController]

    public class ZCCompanyController : ControllerBase
    {

        /// <summary>
        ///      众筹数据库驱动
        /// </summary>
        private ClzcContext clzcContext { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_clzcContext"></param>
        public ZCCompanyController(
            ClzcContext _clzcContext
        )
        {
            this.clzcContext = _clzcContext;
        }

        /// <summary>
        /// 列出公司列表
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public CommonRtn searchCompany([FromBody] ZCSearchCompanyInput input)
        {
            if (input.keyword != null && input.keyword != String.Empty)
            {
                var companys = (from company in this.clzcContext.companys where company.name.Contains(input.keyword) select company).ToArray();
                return CommonRtn.Success(new Dictionary<string, object> { { "companys", companys } });
            }
            else
            {
                var companys = this.clzcContext.companys.ToArray();
                return CommonRtn.Success(new Dictionary<string, object> { { "companys", companys } });
            }

        }

        /// <summary>
        /// 众筹获取公司详细信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public CommonRtn getCompanyInfo([FromBody] ZCGetCompanyInfoInput input)
        {
            return CommonRtn.Success(new Dictionary<string, object> { { "company", this.clzcContext.companys.Find(input.companyId) } });
        }

        /// <summary>
        /// 提交项目经理申请
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        [HttpPost("[action]")]
        public CommonRtn submitProjectManageApply([FromBody] ZCCreateProjectManageApplyInput input)
        {
            var countExit = (from apply in this.clzcContext.projectManageApplys where apply.userId == input.userId && apply.status == ProjectManageApplyStatus.Submit select apply).Count();
            if (countExit > 0)
            {
                return CommonRtn.Error("请耐心等待审核");
            }
            var result = this.clzcContext.projectManageApplys.Add(
                new ProjectManageApply
                {
                    id = Guid.NewGuid().ToString(),
                    phone = input.phone,
                    status = ProjectManageApplyStatus.Submit,
                    summary = input.summary,
                    userId = input.userId,
                    companyId = input.companyId,
                    fileId = input.fileId
                });
            this.clzcContext.SaveChanges();
            return CommonRtn.Success(new Dictionary<string, object> { { "result", result } });
        }
    }
}