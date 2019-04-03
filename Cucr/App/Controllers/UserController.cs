using System;
using System.Collections;
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
using Cucr.CucrSaas.Common.Util;
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
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
namespace Cucr.CucrSaas.App.Controllers
{

    /// <summary>
    /// App登录注册授权接口
    /// </summary>
    [Route("api/CucrSaas/App/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
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
        public UserController(OAContext _oaContext,
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
        /// 获取自己的用户信息
        /// 更加详细
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public CommonRtn getMyInfo(UserInfoInput input)
        {
            var instance = this.userService.decodeToken(this.commonService.getAuthenticationHeader());

            // if (instance.user.mechineId == input.mechineId)
            // {
            var dbUser = (from user in this.sysContext.users where user.id == instance.user.id select user)
                .Include(u => u.company)
                .Include(u => u.post)
                .Include(u => u.companyFramework)
                .FirstOrDefault();

            return new CommonRtn { success = true, message = "", resData = new Dictionary<string, object> { { "user", dbUser } } };

            // else
            // {
            //     return new CommonRtn { success = true, message = "设备不一致" };
            // }

        }

        /// <summary>
        /// 搜索用户
        ///  </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public CommonRtn searchCompanyUserList([FromBody] object input)
        {
            var options = new DataSourceLoadOptions();

            var token = this.commonService.getAuthenticationHeader();
            var instance = this.userService.decodeToken(token);
            var companyId = instance.user.companyId;

            options.Filter = new List<object> { new string[] { "companyId", "=", companyId } };
            // options.Select = new string[] { "name", "id", "jobNumber","companyId",
            // "postId","companyFrameworkId",
            //  "totleScore", "company", "post", "companyFramework" };
            var query = (from user in this.sysContext.users select user)
                .Include(u => u.company)
                .Include(u => u.post)
                .Include(u => u.companyFramework);
            var users = DataSourceLoader.Load(query, options).data;
            var data = new Dictionary<string, object>();
            var LETTERS = new string[] {
                "A",
                "B",
                "C",
                "D",
                "E",
                "F",
                "G",
                "H",
                "I",
                "J",
                "K",
                "L",
                "M",
                "N",
                "L",
                "M",
                "N",
                "O",
                "P",
                "Q",
                "R",
                "S",
                "T",
                "U",
                "V",
                "W",
                "X",
                "Y",
                "Z"
            };
            foreach (var letter in LETTERS)
            {
                var letterUsers = new List<User>();
                data[letter] = letterUsers;
            }
            foreach (var user in users)
            {

                var userEntity = JsonConvert.DeserializeObject<User>(JsonConvert.SerializeObject(user));
                if (userEntity.token == null)
                    Console.WriteLine("no token");
                var name = userEntity.name;
                var nameLetter = CharUtil.GetPYChar(name).ToUpper();
                if (name != null && name != "" && name.Length > 0)
                {

                    if (LETTERS.Contains(nameLetter))
                    {
                        ((List<User>)data[nameLetter]).Add(userEntity);
                    }
                    else
                    {
                        if (nameLetter == "*")
                        {
                            Console.WriteLine("**************");
                            ((List<User>)data["A"]).Add(userEntity);

                        }
                        // Console.WriteLine(letter + ":" + name + ":" + nameLetter);
                    }
                }
                else
                {
                    Console.WriteLine("no name:" + name);
                }

            }
            foreach (var key in data.Keys.ToArray())
            {
                var userList = (List<User>)data[key];
                if (userList.Count <= 0)
                {
                    data.Remove(key);
                }
            }

            return CommonRtn.Success(data);

        }
        /// <summary>
        /// 通过关键字搜索公司用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public CommonRtn searchCompanyUserListByKeyword(AppSearchUserInput input)
        {
            var options = new DataSourceLoadOptions();

            var token = this.commonService.getAuthenticationHeader();
            var instance = this.userService.decodeToken(token);
            var companyId = instance.user.companyId;

            options.Filter = new List<object> { new string[] { "companyId", "=", companyId } };
            options.Filter.Add("and");
            options.Filter.Add(new List<string> { "name", "contains", input.keyword });

            // options.Select = new string[] { "name", "id", "jobNumber","companyId",
            // "postId","companyFrameworkId",
            //  "totleScore", "company", "post", "companyFramework" };
            var query = (from user in this.sysContext.users select user)
                .Include(u => u.company)
                .Include(u => u.post)
                .Include(u => u.companyFramework);
            return CommonRtn.Success(new Dictionary<string, object> { { "users", DataSourceLoader.Load(query, options) } });
        }
        /// <summary>
        /// 搜索组织架构以及下级用户
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public CommonRtn searchCompanyFramework([FromBody] SearchCompanyFrameworkInput input)
        {
            var options = new DataSourceLoadOptions();
            var token = this.commonService.getAuthenticationHeader();
            Console.WriteLine(token);
            var instance = this.userService.decodeToken(token);
            var companyId = instance.user.companyId;

            Console.WriteLine("companuyId:" + companyId);
            List<CompanyFramework> companyFrameworks;
            if (input.companyFrameworkId == null || input.companyFrameworkId == String.Empty)
            {
                companyFrameworks = (from companyFramework in this.sysContext.companyFrameworks
                                     where companyFramework.companyId == companyId
                                     select new CompanyFramework
                                     {
                                         id = companyFramework.id,
                                         companyId = companyFramework.companyId,
                                         department = companyFramework.department,
                                         userNum = companyFramework.userNum,
                                         subCompanyFrameworkNum = (from cf in this.sysContext.companyFrameworks where companyFramework.id == cf.parentId select cf).Count(),
                                     }).ToList();

                return CommonRtn.Success(new Dictionary<string, object> { { "companyFrameworks", companyFrameworks }, { "users", new ArrayList() } });

            }
            else
            {
                companyFrameworks = (from companyFramework in this.sysContext.companyFrameworks
                                     where companyFramework.companyId == companyId && companyFramework.parentId == input.companyFrameworkId

                                     select new CompanyFramework
                                     {
                                         parentId = companyFramework.parentId,
                                         id = companyFramework.id,
                                         companyId = companyFramework.companyId,
                                         department = companyFramework.department,
                                         userNum = companyFramework.userNum,
                                         subCompanyFrameworkNum = (from cf in this.sysContext.companyFrameworks where companyFramework.id == cf.parentId select cf).Count(),
                                     }).ToList();

                // var cfIds = companyFrameworks.Select(cf => cf.id).Distinct().ToArray();
                // Console.WriteLine(JsonConvert.SerializeObject(cfIds));

                var users = (from user in this.sysContext.users
                             where user.companyFrameworkId == input.companyFrameworkId
&& user.companyId == instance.user.companyId
                             select user).ToArray();
                users = users.Where(user => user.id != instance.user.id).ToArray();
                return CommonRtn.Success(new Dictionary<string, object> { { "companyFrameworks", companyFrameworks }, { "users", users } });

            }

        }

        /// <summary>
        /// 上传头像
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public CommonRtn changeAvator(AppChangeAvatorInput input)
        {
            var token = this.commonService.getAuthenticationHeader();
            var instance = this.userService.decodeToken(token);
            var user = this.sysContext.users.Find(instance.user.id);
            user.headPortrait = input.url;
            this.sysContext.SaveChanges();
            return CommonRtn.Success(new Dictionary<string, object> { });

        }
        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public CommonRtn getUserBaseInfo(GetUserBaseInfoInput input)
        {
            var user = this.sysContext.users.Find(input.userId);
            return CommonRtn.Success(new Dictionary<string, object> { { "user", user } });
        }
    }
}