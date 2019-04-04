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

namespace Cucr.CucrSaas.ZC.Controllers
{

    /// <summary>
    /// 众筹登录
    /// </summary>
    [Route("api/CucrSaas/ZC/Admin/[controller]")]
    [ApiController]

    public class ZCAuthController : ControllerBase
    {

        /// <summary>
        ///      众筹数据库驱动
        /// </summary>
        private ClzcContext clzcContext { get; set; }
        /// <summary>
        /// 众筹系统数据库驱动
        /// </summary>
        /// <value></value>
        private ZCSysContext zcSysContext { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_clzcContext"></param>
        /// <param name="_zcSysContext"></param>
        public ZCAuthController(
            ClzcContext _clzcContext,
            ZCSysContext _zcSysContext
        )
        {
            this.clzcContext = _clzcContext;
            this.zcSysContext = _zcSysContext;
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public CommonRtn login(ZCUserLoginInput input)
        {
            var exsitUser = (from user in this.clzcContext.users where user.phone == input.phone select user).FirstOrDefault();
            if (exsitUser == null)
            {
                return CommonRtn.Error("改手机号尚未注册");
            }
            else
            {
                if (exsitUser.roleIds != null && exsitUser.roleIds != String.Empty)
                {
                    var roleIdArr = exsitUser.roleIds.Split(",").Distinct().ToArray();
                    exsitUser.roles = (from role in this.clzcContext.roles where roleIdArr.Contains(role.id) select role).ToList();
                }
                return CommonRtn.Success(new Dictionary<string, object> { { "user", exsitUser } });
            }

        }

        /// <summary>
        /// 用户信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        [HttpPost("[action]")]
        public CommonRtn userInfo([FromBody] ZCUserInfoInput input)
        {
            var user = this.clzcContext.users.Find(input.userId);
            var cardFrontFile = (from file in this.clzcContext.files where file.ID == user.cardFront select file).FirstOrDefault();
            var cardConFile = (from file in this.clzcContext.files where file.ID == user.cardCon select file).FirstOrDefault();
            user.headImgFile = this.clzcContext.files.Find(user.headimg);
            if (user.headImgFile != null)
            {
                var prefix = user.headImgFile.PATH.StartsWith("http") ? "" : "http://z.cucrxt.com/";
                user.headImgFile.PATH = prefix + user.headImgFile.PATH;
            }
            user.cardConFile = cardConFile;
            user.cardFrontFile = cardFrontFile;
            user.bank = (from b in this.clzcContext.bankCards where b.userId == user.ID select b).FirstOrDefault();

            return CommonRtn.Success(new Dictionary<string, object> { { "user", user } });
        }

        /// <summary>
        /// 公司注册
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public CommonRtn companyRegister(ZCCompanyRegisterInput input)
        {

            var newCompany = new Company
            {
                id = Guid.NewGuid().ToString(),
                area = input.area,
                name = input.name,
                capital = input.capital,
                password = DESEncrypt.Encrypt(input.pwd).ToString(),
                account = input.account,
                telephone = input.telephone,
                address = input.address,
                registerDate = input.registerDate,
                legalPerson = input.legalPerson,
                license = input.license,

            };

            return CommonRtn.Success(new Dictionary<string, object> { { "company", newCompany } });
        }

        /// <summary>
        /// 个人注册
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public CommonRtn personSignup([FromBody] ZCPersonSignupInput input)
        {
            Console.WriteLine(input.idCard);
            var newUser = new User
            {
                idcard = input.idCard,
                sex = input.sex,
                name = input.name,
                headimg = input.headImg,
                region = input.region,
                cardFront = input.cardFront,
                cardCon = input.cardCon,
                password = input.password,
                nickname = input.nickname,
                phone = input.phone

            };
            // Console.WriteLine(newUser.);
            var user = this.clzcContext.users.Add(newUser);
            this.clzcContext.SaveChanges();
            return CommonRtn.Success(new Dictionary<string, object> { { "user", user.Entity } }, "注册成功");
        }

    }
}