using System;
using System.Linq;
using Cucr.CucrSaas.App.DataAccess;
using Cucr.CucrSaas.App.DTO;
using Cucr.CucrSaas.App.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections;
namespace Cucr.CucrSaas.App.Filters
{

    /// <summary>
    /// 获取用户token
    /// </summary>

    public class SingleLoginFilter : IActionFilter
    {
        /// <summary>
        /// 白名单
        /// </summary>
        /// <value></value>
        public string[] whiteList = new[] { "/api/CucrSaas/App/Auth/appLogin" };

        private ICommonService commonService { get; set; }
        private IUserService userService { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        private SysContext sysContext { get; set; }
        /// <summary>
        /// 单点登录
        /// </summary>
        /// <param name="_commonService"></param>
        /// <param name="_userService"></param>

        public SingleLoginFilter(ICommonService _commonService, IUserService _userService, SysContext _sysContext)
        {
            this.commonService = _commonService;
            this.userService = _userService;
            this.sysContext = _sysContext;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (this.whiteList.Contains(context.HttpContext.Request.Path.ToString()))
            {
                Console.WriteLine("白名单");
            }
            else
            {

                Console.WriteLine("=================");
                var token = this.commonService.getAuthenticationHeader();
                if (token == "" || token == null)
                {
                    context.Result = new JsonResult(new CommonRtn { success = false, message = "用户尚未登陆" });

                }
                var tokenUserCount = (from user in this.sysContext.users where user.token == token select user).Count();
                if (tokenUserCount <= 0)
                {
                    Console.WriteLine("===========error======");
                    context.Result = new JsonResult(new CommonRtn { success = false, message = "你已经在其他设备登录" });
                }
            }

        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

    }

}