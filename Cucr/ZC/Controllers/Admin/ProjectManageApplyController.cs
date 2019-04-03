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

namespace Cucr.CucrSaas.ZC.Controllers {

    /// <summary>
    /// App登录注册授权接口
    /// </summary>
    // [EnableCors ("AllowAllOrigin")]
    [Route ("api/CucrSaas/ZC/Admin/[controller]")]
    [ApiController]

    public class ProjectManageApplyController : ControllerBase {

        /// <summary>
        ///      众筹数据库驱动
        /// </summary>
        private ClzcContext clzcContext { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_clzcContext"></param>
        public ProjectManageApplyController (
            ClzcContext _clzcContext
        ) {
            this.clzcContext = _clzcContext;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        [HttpGet]
        public object Get (DataSourceLoadOptions options) {
            return DataSourceLoader.Load (this.clzcContext.projectManageApplys, options);
        }

        /// <summary>
        /// 创建组织
        /// </summary>
        /// <param name="bodyData"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Post (BodyDataInput bodyData) {
            var role = new ProjectManageApply ();
            JsonConvert.PopulateObject (bodyData.values, role);
            //Validate(order);
            if (!ModelState.IsValid)
                return false;
            this.clzcContext.projectManageApplys.Add (role);
            this.clzcContext.SaveChanges ();
            return true;
        }

        /// <summary>
        /// 删除组织
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpDelete]
        public bool Delete ([FromForm] string key) {

            var order = this.clzcContext.projectManageApplys.Find (key);
            this.clzcContext.projectManageApplys.Remove (order);
            this.clzcContext.SaveChanges ();
            return true;
        }
        /// <summary>
        /// 更新组织
        /// </summary>
        /// <param name="bodyData"></param>
        /// <returns></returns>
        [HttpPut]
        public bool Put ([FromForm] BodyDataInput bodyData) {

            var order = this.clzcContext.projectManageApplys.Find (bodyData.key);
            JsonConvert.PopulateObject (bodyData.values, order);
            this.clzcContext.SaveChanges ();
            return true;

        }
        /// <summary>
        /// 审核产品经理资质
        /// </summary>
        /// <param name="projectManageApplyId"></param>
        /// <returns></returns>
        [HttpGet ("[action]")]
        public CommonRtn projectManageApplyVerifyPass (string projectManageApplyId) {
            var projectManageApply = this.clzcContext.projectManageApplys.Find (projectManageApplyId);
            if (projectManageApply.status == ProjectManageApplyStatus.Submit) {
                projectManageApply.status = ProjectManageApplyStatus.Approve;
                this.clzcContext.SaveChanges ();
                var user = this.clzcContext.users.Find (projectManageApply.userId);
                Console.WriteLine (user.roleIds);
                if (user.roleIds == String.Empty || user.roleIds == null) {
                    user.roleIds = CommonRole.ProductManage;
                    this.clzcContext.SaveChanges ();
                    return CommonRtn.Success (new Dictionary<string, object> { { "", "" } });
                } else {

                    if (user.roleIds.Split (",").Contains (CommonRole.ProductManage)) {
                        return CommonRtn.Error ("用户已经包含该角色");
                    } else {
                        user.roleIds += "," + CommonRole.ProductManage;
                        this.clzcContext.SaveChanges ();
                        return CommonRtn.Success (new Dictionary<string, object> { { "", "" } });
                    }
                }

            } else {
                return CommonRtn.Error ("已提交申请不可以再次审核");
            }
        }
    }
}