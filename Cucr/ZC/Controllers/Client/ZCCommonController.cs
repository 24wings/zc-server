using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
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
    [Route("api/CucrSaas/ZC/Client/[controller]")]
    [ApiController]

    public class ZCCommonController : ControllerBase
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
        public ZCCommonController(
            ClzcContext _clzcContext,
            ZCSysContext _zcSysContext
        )
        {
            this.clzcContext = _clzcContext;
            this.zcSysContext = _zcSysContext;
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public CommonRtn uploadFile(UploadFileInput input)
        {

            var url = this.SaveFile(input.base64, input.ext);
            var file = new File { PATH = url };
            this.clzcContext.files.Add(file);
            this.clzcContext.SaveChanges();
            return CommonRtn.Success(new Dictionary<string, object> { { "url", url }, { "file", file } });

        }

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
            var file = new File { PATH = url };
            this.clzcContext.files.Add(file);
            this.clzcContext.SaveChanges();
            return CommonRtn.Success(new Dictionary<string, object> { { "url", url }, { "file", file } });
        }

        /// <summary>
        ///  将echarts返回的base64 转成图片
        /// </summary>
        /// <param name="image">图片的base64形式</param>
        /// <param name="proname">项目区分</param>
        private string SaveImage(string image, string proname)
        {

            var matchPng = Regex.Match(image, "data:image/png;base64,([\\w\\W]*)$");
            var matchJpg = Regex.Match(image, "data:image/jpg;base64,([\\w\\W]*)$");
            var matchJpeg = Regex.Match(image, "data:image/jpeg;base64,([\\w\\W]*)$");
            if (matchPng.Success)
            {
                image = matchPng.Groups[1].Value;
            }
            if (matchJpg.Success)
            {
                image = matchJpg.Groups[1].Value;
            }
            if (matchJpeg.Success)
            {
                image = matchJpeg.Groups[1].Value;
            }
            var photoBytes = Convert.FromBase64String(image);
            var key = Guid.NewGuid() + ".png";
            OSSService.uploadFile(new System.IO.MemoryStream(photoBytes), key);
            return "https://cucr.oss-cn-beijing.aliyuncs.com/" + key;

        }

        /// <summary>
        ///  将echarts返回的base64 转成图片
        /// </summary>
        /// <param name="image">文件的base64</param>
        /// <param name="ext">扩展名</param>
        private string SaveFile(string image, string ext)
        {
            var mime = ext;
            if (ext == "ico") mime = "image/x-icon";

            var match = Regex.Match(image, "data:" + mime + ";base64,([\\w\\W]*)$");
            if (match.Success)
            {
                Console.WriteLine("match");
                image = match.Groups[1].Value;
            }
            var photoBytes = Convert.FromBase64String(image);
            var key = Guid.NewGuid() + "." + ext;
            OSSService.uploadFile(new System.IO.MemoryStream(photoBytes), key);
            return "https://cucr.oss-cn-beijing.aliyuncs.com/" + key;

        }
        /// <summary>
        /// 获取区域列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public CommonRtn listAreas([FromQuery] DataSourceLoadOptions options)
        {
            var areas = DataSourceLoader.Load(this.clzcContext.areas, options);
            return CommonRtn.Success(new Dictionary<string, object> { { "areas", areas } });
        }
    }
}