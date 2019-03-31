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
using Cucr.CucrSaas.App.Entity.OA;
using Cucr.CucrSaas.App.Entity.Sys;
using Cucr.CucrSaas.App.Service;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Serializers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
namespace Cucr.CucrSaas.App.Controllers {

    /// <summary>
    /// App登录注册授权接口
    /// </summary>
    [Route ("api/CucrSaas/App/[controller]")]
    [ApiController]

    // [Authorize]
    public class WorkReportController : ControllerBase {

        private ICommonService commonService { get; set; }
        /// <summary>
        /// OA数据访问对象
        /// </summary>
        /// <value></value>
        public OAContext oaContext { get; set; }
        /// <summary>
        /// 系统数据库访问
        /// </summary>
        /// <value></value>
        public SysContext sysContext { get; set; }
        /// <summary>
        /// 用户接口
        /// </summary>
        /// <value></value>
        public IUserService userService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_oaContext"></param>
        /// <param name="_sysContext"></param>
        /// <param name="_commonService"></param>
        /// <param name="_userService"></param>
        public WorkReportController (OAContext _oaContext,
            SysContext _sysContext,
            ICommonService _commonService, IUserService _userService) {
            this.oaContext = _oaContext;
            this.sysContext = _sysContext;
            this.commonService = _commonService;
            this.userService = _userService;
        }

        /// <summary>
        /// 搜索OA工作报告
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        [HttpGet ("[action]")]
        public CommonRtn searchWorkReport ([FromQuery] DataSourceLoadOptions options) {
            return new CommonRtn {
                resData = new Dictionary<string, object> { { "workreports", DataSourceLoader.Load (this.oaContext.workreports, options) } },
                    success = true,
                    message = ""
            };
        }
        /// <summary>
        /// 
        /// 获取报告详情
        /// </summary>
        /// <returns></returns>
        [HttpGet ("[action]")]
        public CommonRtn getWorkReportInfo ([FromQuery] GetWorkReportInput input) {
            var token = this.commonService.getAuthenticationHeader ();
            var appUser = this.userService.decodeToken (token);
            if (appUser.user.mechineId == input.mechineId) {
                var workReport = this.oaContext.workreports.Find (input.workReportId);
                return new CommonRtn { success = true, resData = new Dictionary<string, object> { { "workReport", workReport } } };
            } else {
                return new CommonRtn { success = false, message = "设备不一致" };
            }

        }

        /// <summary>
        /// 添加工作报告
        /// </summary>
        /// <returns></returns>
        [HttpPost ("[action]")]
        public CommonRtn addOaWorkReportInfo ([FromBody] WorkReport workReport) {
            this.oaContext.workreports.Add (workReport);
            this.oaContext.SaveChanges ();
            return new CommonRtn { success = true, message = "" };
        }

        /// <summary>
        /// 删除工作报告
        /// </summary>
        /// <returns></returns>
        [HttpDelete ("[action]")]
        public CommonRtn deleteWorkReportInfo (string workReportId) {
            var token = this.commonService.getAuthenticationHeader ();
            var tokenInstance = this.userService.decodeToken (token);
            if (tokenInstance?.user.id != null) {

                var workReport = this.oaContext.workreports.Find (workReportId);
                if (workReport != null) {
                    return new CommonRtn {
                    success = true, message = "",
                    resData = new Dictionary<string, object> { { "workreport", workReport } }
                    };

                } else {
                    return new CommonRtn { success = false, message = "工作报告不存在" };
                }

            } else {
                return new CommonRtn { success = false, message = "请先登录" };
            }

        }

    }
}