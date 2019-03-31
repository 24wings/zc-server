using System;
using System.Collections.Generic;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Profile;

namespace CommonRequestDemo {
    public class SmsService {
        public static CommonResponse sendSms () {
            IClientProfile profile = DefaultProfile.GetProfile ("cn-hangzhou", "<accessKeyId>", "<accessSecret>");
            DefaultAcsClient client = new DefaultAcsClient (profile);
            CommonRequest request = new CommonRequest ();
            request.Method = MethodType.POST;
            request.Domain = "dysmsapi.aliyuncs.com";
            request.Version = "2017-05-25";
            request.Action = "SendSms";
            // request.Protocol = ProtocolType.HTTP;
            request.AddQueryParameters ("PhoneNumbers", "13419597065");
            request.AddQueryParameters ("SignName", "邦为科技");
            request.AddQueryParameters ("TemplateCode", "SMS_130920608");
            try {
                CommonResponse response = client.GetCommonResponse (request);
                Console.WriteLine (System.Text.Encoding.Default.GetString (response.HttpResponse.Content));

                return response;
            } catch (ServerException e) {
                Console.WriteLine (e);
            } catch (ClientException e) {
                Console.WriteLine (e);
            }
        }
    }
}