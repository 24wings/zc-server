using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Cucr.CucrSaas.App.DataAccess;
using Cucr.CucrSaas.App.DTO;
using Cucr.CucrSaas.App.Entity.Sys;
using Cucr.CucrSaas.App.Service;
using Cucr.CucrSaas.Common.DTO;
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
    /// 通用控制器,例如图片,文件上传
    /// </summary>
    [Route("api/CucrSaas/Common/[controller]")]
    [ApiController]

    public class CommonController : ControllerBase
    {

        private ICommonService commonService { get; set; }

        /// <summary>
        /// 图片上传接口
        /// 图片轻以base64格式上传
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public CommonRtn uploadImage(UploadImageInput input)
        {
            var url = this.SaveImage(input.base64, "test");
            return CommonRtn.Success(new Dictionary<string, object> { { "url", url } });
        }

        /// <summary>
        ///  将echarts返回的base64 转成图片
        /// </summary>
        /// <param name="image">图片的base64形式</param>
        /// <param name="proname">项目区分</param>
        public string SaveImage(string image, string proname)
        {
            string path = $"{Directory.GetCurrentDirectory()}//wwwroot//Sonarqube//{proname}.png";
            string filepath = Path.GetDirectoryName(path);
            // 如果不存在就创建file文件夹
            if (!Directory.Exists(filepath))
            {
                if (filepath != null) Directory.CreateDirectory(filepath);
            }
            var match = Regex.Match(image, "data:image/png;base64,([\\w\\W]*)$");
            if (match.Success)
            {
                image = match.Groups[1].Value;
            }
            var photoBytes = Convert.FromBase64String(image);
            var key = Guid.NewGuid() + ".png";
            OSSService.uploadFile(new MemoryStream(photoBytes), key);
            return "https://cucr.oss-cn-beijing.aliyuncs.com/" + key;

        }


    }
}