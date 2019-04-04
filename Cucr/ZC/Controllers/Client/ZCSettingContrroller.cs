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

namespace Cucr.CucrSaas.ZC.Controllers {

    /// <summary>
    /// 众筹设置
    /// </summary>
    [Route ("api/CucrSaas/ZC/Admin/[controller]")]
    [ApiController]

    public class ZCSettingController : ControllerBase {

        /// <summary>
        ///      众筹数据库驱动
        /// </summary>
        private ClzcContext clzcContext { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_clzcContext"></param>
        public ZCSettingController (
            ClzcContext _clzcContext
        ) {
            this.clzcContext = _clzcContext;
        }
        /// <summary>
        /// 保存个人信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost ("[action]")]
        public CommonRtn savePersonal ([FromBody] ZCSaveUserInfoInput input) {
            var user = this.clzcContext.users.Find (input.userId);
            user.idcard = input.idCard;
            user.profession = input.profession;
            user.region = input.region;
            user.provinceid = input.provinceId;
            user.sex = input.sex;
            user.name = input.name;
            user.nickname = input.nickname;

            user.companyname = input.companyName;
            user.address = input.address;

            user.areaid = input.areaId;
            user.autograph = input.autograph;

            var userBankCard = (from bankCard in this.clzcContext.bankCards where bankCard.userId == input.userId select bankCard).FirstOrDefault ();
            if (userBankCard == null) {
                userBankCard = new BankCard { no = input.bank.no, bank = input.bank.bank, belongTo = input.bank.belongTo, userId = user.ID };
                this.clzcContext.bankCards.Add (userBankCard);
                this.clzcContext.SaveChanges ();

            } else {
                userBankCard.no = input.bank.no;
                userBankCard.belongTo = input.bank.belongTo;
                userBankCard.bank = input.bank.bank;
                this.clzcContext.bankCards.Update (userBankCard);
                this.clzcContext.SaveChanges ();

            }
            this.clzcContext.Update (user);
            this.clzcContext.SaveChanges ();
            return CommonRtn.Success (new Dictionary<string, object> { { "bankCard", userBankCard }, { "user", user } });

        }

    }
}