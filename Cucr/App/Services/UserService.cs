using System;
using Cucr.CucrSaas.App.DTO;
using Cucr.CucrSaas.App.Entity.Sys;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using Newtonsoft.Json;

namespace Cucr.CucrSaas.App.Service {

    /// <summary>
    /// 用户业务接口
    /// </summary>
    public interface IUserService {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appToken"></param>
        /// <returns></returns>
        string getUserToken (AppTokenOutput appToken);

        /// <summary>
        /// 根据token解码用户信息
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        AppTokenOutput decodeToken (string token);
    }

    /// <summary>
    /// 用户业务具体实现
    /// </summary>
    public class UserService : IUserService {
        /// <summary>
        /// 密钥
        /// </summary>
        public const string secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";

        /// <summary>
        /// 获取用户登录的token
        /// </summary>
        /// <param name="appToken"></param>
        /// <returns></returns>
        public string getUserToken (AppTokenOutput appToken) {
            var token = new JwtBuilder ()
                .WithAlgorithm (new HMACSHA256Algorithm ())
                .WithSecret (secret)

                // .AddClaim ("tokenInstance", appToken.tokenInstance)
                .AddClaim ("user", appToken.user)
                .Build ();
            return token;
        }

        /// <summary>
        /// 根据token 解密token数据
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>

        public AppTokenOutput decodeToken (string token) {
            if (token.StartsWith ("Bearer ")) {
                token = token.Replace ("Bearer ", "");
            }
            try {
                var json = new JwtBuilder ()
                    .WithSecret (secret)
                    // .MustVerifySignature ()
                    .Decode (token);
                return JsonConvert.DeserializeObject<AppTokenOutput> (json);
            } catch (TokenExpiredException) {
                Console.WriteLine ("Token has expired");
                return null;
            } catch (SignatureVerificationException) {
                Console.WriteLine ("Token has invalid signature");
                return null;
            }
        }
    }

}