using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Moq;
using Xunit;
namespace Cucr.CucrSaas.App.Test.Controllers {

    public class AuthControllerTest {

        private static readonly HttpClient client = new HttpClient ();

        /// <summary>桉树
        /// 测试h
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async void test () {
            var res = await client.GetStringAsync ("https://api.github.com/orgs/dotnet/repos");

            Assert.Equal (2, 2);
        }
    }
}