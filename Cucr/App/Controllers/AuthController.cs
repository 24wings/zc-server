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
namespace Cucr.CucrSaas.App.Controllers {

    /// <summary>
    /// App登录注册授权接口
    /// </summary>
    [Route ("api/CucrSaas/App/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase {

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
        public AuthController (OAContext _oaContext,
            SysContext _sysContext,
            ICommonService _commonService, IUserService _userService) {
            this.oaContext = _oaContext;
            this.sysContext = _sysContext;
            this.commonService = _commonService;
            this.userService = _userService;
        }

        /// <summary>
        /// app登录
        /// </summary>
        /// <returns></returns>
        [HttpPost ("[action]")]
        public object appLogin ([FromBody] AppUserLoginInput loginInput) {

            var exisitUser = (from user in this.sysContext.users where user.phone == loginInput.phone select user).FirstOrDefault ();
            if (exisitUser != null) {
                if (DESEncrypt.DecryptString (exisitUser.loginPassword) == loginInput.loginPassword) {
                    var loginIp = this.commonService.getRequestIp ();
                    exisitUser.loginNumber++;
                    exisitUser.loginIP = loginIp;
                    exisitUser.mechineId = loginInput.mechineId;
                    this.sysContext.SaveChanges ();
                    var token = this.userService.getUserToken (new AppTokenOutput { user = exisitUser });
                    return new CommonRtn { success = true, message = "登录成功", resData = new Dictionary<string, object> () { { "token", token } } };
                } else {
                    return new CommonRtn { success = false, message = "登录失败,用户密码错误", };
                }
            } else {

                return new CommonRtn { success = false, message = "登录失败,用户不存在", };
            }

        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost ("[action]")]
        public CommonRtn signup (SignupInput input) {
            var exisitUser = (from user in this.sysContext.users where user.phone == input.phone select user).Count ();
            if (exisitUser > 0) {
                return new CommonRtn { success = false, message = "用户已经注册" };
            } else {
                var user = new User {
                    phone = input.phone,
                    loginPassword = DESEncrypt.Encrypt (input.loginPassword),
                    id = Guid.NewGuid ().ToString ()
                };
                this.sysContext.users.Add (user);
                this.sysContext.SaveChanges ();
                return new CommonRtn { success = true, message = "注册成功" };
            }
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost ("[action]")]
        public CommonRtn getUserInfo ([FromBody] UserInfoInput input) {
            var user = this.userService.decodeToken (input.token);
            Console.WriteLine (user.user == null);
            if (user.user.mechineId == input.mechineId) {
                return new CommonRtn { success = true, message = "", resData = new Dictionary<string, object> { { "user", user.user } } };
            } else {
                return new CommonRtn { success = true, message = "设备不一致" };
            }

        }
    }
}