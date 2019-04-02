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
namespace Cucr.CucrSaas.App.Controllers
{

    /// <summary>
    /// App登录注册授权接口
    /// </summary>
    [Route("api/CucrSaas/App/[controller]")]
    [ApiController]

    public class WorkOrderController : ControllerBase
    {

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
        /// 短信验证码
        /// </summary>
        /// <value></value>
        public ISmsService smsService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_oaContext"></param>
        /// <param name="_sysContext"></param>
        /// <param name="_commonService"></param>
        /// <param name="_userService"></param>
        /// <param name="_smsService"></param>
        public WorkOrderController(OAContext _oaContext,
            SysContext _sysContext,
            ICommonService _commonService,
            IUserService _userService,
            ISmsService _smsService
        )
        {
            this.oaContext = _oaContext;
            this.sysContext = _sysContext;
            this.commonService = _commonService;
            this.userService = _userService;
            this.smsService = _smsService;
        }
        /// <summary>
        /// 获取直派给我我的工单
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public CommonRtn listWorkOrdersGiveMe()
        {
            var tokenUser = this.userService.getUserFromAuthcationHeader();

            var workOrders = (from workOrder in this.oaContext.workOrders where workOrder.assignId == tokenUser.id select workOrder).ToArray();
            return CommonRtn.Success(new Dictionary<string, object> { { "workOrders", workOrders } });
        }


        /// <summary>
        /// 获取我指派的工单
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public CommonRtn listWorkOrderFromMe()
        {
            var tokenUser = this.userService.getUserFromAuthcationHeader();
            var workOrders = (from workOrder in this.oaContext.workOrders where workOrder.userId == tokenUser.id select workOrder).ToArray();
            return CommonRtn.Success(new Dictionary<string, object> { { "workOrders", workOrders } });
        }


    }
}