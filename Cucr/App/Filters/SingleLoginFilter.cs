using System;
using System.Collections;
using System.Linq;
using Cucr.CucrSaas.App.DataAccess;
using Cucr.CucrSaas.App.DTO;
using Cucr.CucrSaas.App.Service;
using Cucr.CucrSaas.ZC.Provider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Cucr.CucrSaas.App.Filters {

    /// <summary>
    /// 获取用户token
    /// </summary>

    public class SingleLoginFilter : IActionFilter {
        /// <summary>
        /// 白名单
        /// </summary>
        /// /// <value></value>
        public string[] whiteList = new [] { "/api/CucrSaas/App/Auth/appLogin", "Test" };

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
        /// <param name="_sysContext"></param>
        public SingleLoginFilter (ICommonService _commonService, IUserService _userService, SysContext _sysContext) {
            this.commonService = _commonService;
            this.userService = _userService;
            this.sysContext = _sysContext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting (ActionExecutingContext context) {
            var exist = (from url in this.whiteList where context.HttpContext.Request.Path.ToString ().Contains (url) select url).Count ();
            if (this.whiteList.Contains (context.HttpContext.Request.Path.ToString ()) || exist > 0) {
                Console.WriteLine ("白名单");
            } else {

                Console.WriteLine ("=================");
                var token = this.commonService.getAuthenticationHeader ();
                if (token == "" || token == null) {
                    context.Result = new JsonResult (new CommonRtn { success = false, message = "用户尚未登陆" });

                }
                var tokenUserCount = (from user in this.sysContext.users where user.token == token select user).Count ();
                if (tokenUserCount <= 0) {
                    Console.WriteLine ("===========error======");
                    context.Result = new JsonResult (new CommonRtn { success = false, message = "你已经在其他设备登录" });
                }
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted (ActionExecutedContext context) {
            if (context.Result is ObjectResult) {
                string ignored = JsonConvert.SerializeObject (
                    context.Result,
                    Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                context.Result = new JsonResult (JsonConvert.DeserializeObject (ignored));
            }

        }
        //eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1c2VyIjp7ImlkIjoiNWU1ZDk0MTctZjZhYS00MDEwLWIxNzgtYmRlZDgwODY3ODE1IiwiY29tcGFueUlkIjpudWxsLCJjb21wYW55RnJhbWV3b3JrSWQiOm51bGwsInBvc3RJZCI6bnVsbCwibmFtZSI6bnVsbCwibG9naW5BY2NvdW50IjpudWxsLCJsb2dpblBhc3N3b3JkIjoia0g2ZzY2c045UUNiVTVmSWI5WU9OTmhVNi9QQndBZVg4YXozUGpFdWpZZz0iLCJzZXgiOm51bGwsInBob25lIjoic3RyaW5nIiwidGVsZXBob25lIjpudWxsLCJtYWlsIjpudWxsLCJkb2N1bWVudFR5cGUiOm51bGwsImRvY3VtZW50TnVtYmVyIjpudWxsLCJiaXJ0aCI6bnVsbCwicXFOdW1iZXIiOm51bGwsIndlaVhpbk51bWJlciI6bnVsbCwiaHlTdGF0dXMiOm51bGwsImFkZHJlc3MiOm51bGwsImF1dG9ncmFwaCI6bnVsbCwiY29tcGFueU5hbWUiOm51bGwsImpvYk51bWJlciI6MSwiZGVwYXJ0bWVudCI6bnVsbCwicG9zaXRpb24iOm51bGwsInJ6RGF0ZSI6bnVsbCwienpEYXRlIjpudWxsLCJsekRhdGUiOm51bGwsInR4RGF0ZSI6bnVsbCwiaW53b3JrVHlwZSI6bnVsbCwid29ya0RhdGUiOm51bGwsInBob3RvIjpudWxsLCJ1cmdlbnRQZXJzb24xIjpudWxsLCJ1cmdlbnRQZXJzb24yIjpudWxsLCJoZWFkUG9ydHJhaXQiOm51bGwsInNraWxsIjpudWxsLCJ0b3RsZVNjb3JlIjowLCJjb250cmFjdCI6bnVsbCwidG9rZW4iOiJleUowZVhBaU9pSktWMVFpTENKaGJHY2lPaUpJVXpJMU5pSjkuZXlKMWMyVnlJanA3SW1sa0lqb2lOV1UxWkRrME1UY3RaalpoWVMwME1ERXdMV0l4TnpndFltUmxaRGd3T0RZM09ERTFJaXdpWTI5dGNHRnVlVWxrSWpwdWRXeHNMQ0pqYjIxd1lXNTVSbkpoYldWM2IzSnJTV1FpT201MWJHd3NJbkJ2YzNSSlpDSTZiblZzYkN3aWJtRnRaU0k2Ym5Wc2JDd2liRzluYVc1QlkyTnZkVzUwSWpwdWRXeHNMQ0pzYjJkcGJsQmhjM04zYjNKa0lqb2lhMGcyWnpZMmMwNDVVVU5pVlRWbVNXSTVXVTlPVG1oVk5pOVFRbmRCWlZnNFlYb3pVR3BGZFdwWlp6MGlMQ0p6WlhnaU9tNTFiR3dzSW5Cb2IyNWxJam9pYzNSeWFXNW5JaXdpZEdWc1pYQm9iMjVsSWpwdWRXeHNMQ0p0WVdsc0lqcHVkV3hzTENKa2IyTjFiV1Z1ZEZSNWNHVWlPbTUxYkd3c0ltUnZZM1Z0Wlc1MFRuVnRZbVZ5SWpwdWRXeHNMQ0ppYVhKMGFDSTZiblZzYkN3aWNYRk9kVzFpWlhJaU9tNTFiR3dzSW5kbGFWaHBiazUxYldKbGNpSTZiblZzYkN3aWFIbFRkR0YwZFhNaU9tNTFiR3dzSW1Ga1pISmxjM01pT201MWJHd3NJbUYxZEc5bmNtRndhQ0k2Ym5Wc2JDd2lZMjl0Y0dGdWVVNWhiV1VpT201MWJHd3NJbXB2WWs1MWJXSmxjaUk2TVN3aVpHVndZWEowYldWdWRDSTZiblZzYkN3aWNHOXphWFJwYjI0aU9tNTFiR3dzSW5KNlJHRjBaU0k2Ym5Wc2JDd2llbnBFWVhSbElqcHVkV3hzTENKc2VrUmhkR1VpT201MWJHd3NJblI0UkdGMFpTSTZiblZzYkN3aWFXNTNiM0pyVkhsd1pTSTZiblZzYkN3aWQyOXlhMFJoZEdVaU9tNTFiR3dzSW5Cb2IzUnZJanB1ZFd4c0xDSjFjbWRsYm5SUVpYSnpiMjR4SWpwdWRXeHNMQ0oxY21kbGJuUlFaWEp6YjI0eUlqcHVkV3hzTENKb1pXRmtVRzl5ZEhKaGFYUWlPbTUxYkd3c0luTnJhV3hzSWpwdWRXeHNMQ0owYjNSc1pWTmpiM0psSWpvd0xDSmpiMjUwY21GamRDSTZiblZzYkN3aWRHOXJaVzRpT2lKbGVVb3daVmhCYVU5cFNrdFdNVkZwVEVOS2FHSkhZMmxQYVVwSlZYcEpNVTVwU2prdVpYbEtNV015Vm5sSmFuQTNTVzFzYTBscWIybE9WMVV4V2tSck1FMVVZM1JhYWxwb1dWTXdNRTFFUlhkTVYwbDRUbnBuZEZsdFVteGFSR2QzVDBSWk0wOUVSVEZKYVhkcFdUSTVkR05IUm5WbFZXeHJTV3B3ZFdSWGVITk1RMHBxWWpJeGQxbFhOVFZTYmtwb1lsZFdNMkl6U25KVFYxRnBUMjAxTVdKSGQzTkpia0oyWXpOU1NscERTVFppYmxaellrTjNhV0p0Um5SYVUwazJZbTVXYzJKRGQybGlSemx1WVZjMVFsa3lUblprVnpVd1NXcHdkV1JYZUhOTVEwcHpZakprY0dKc1FtaGpNMDR6WWpOS2EwbHFiMmxoTUdjeVducFpNbU13TkRWVlZVNXBWbFJXYlZOWFNUVlhWVGxQVkcxb1ZrNXBPVkZSYm1SQ1dsWm5ORmxZYjNwVlIzQkdaRmR3V2xwNk1HbE1RMHA2V2xobmFVOXROVEZpUjNkelNXNUNiMkl5Tld4SmFtOXBZek5TZVdGWE5XNUphWGRwWkVkV2MxcFlRbTlpTWpWc1NXcHdkV1JYZUhOTVEwcDBXVmRzYzBscWNIVmtWM2h6VEVOS2EySXlUakZpVjFaMVpFWlNOV05IVldsUGJUVXhZa2QzYzBsdFVuWlpNMVowV2xjMU1GUnVWblJaYlZaNVNXcHdkV1J
        //'eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1c2VyIjp7ImlkIjoiNWU1ZDk0MTctZjZhYS00MDEwLWIxNzgtYmRlZDgwODY3ODE1IiwiY29tcGFueUlkIjpudWxsLCJjb21wYW55RnJhbWV3b3JrSWQiOm51bGwsInBvc3RJZCI6bnVsbCwibmFtZSI6bnVsbCwibG9naW5BY2NvdW50IjpudWxsLCJsb2dpblBhc3N3b3JkIjoia0g2ZzY2c045UUNiVTVmSWI5WU9OTmhVNi9QQndBZVg4YXozUGpFdWpZZz0iLCJzZXgiOm51bGwsInBob25lIjoic3RyaW5nIiwidGVsZXBob25lIjpudWxsLCJtYWlsIjpudWxsLCJkb2N1bWVudFR5cGUiOm51bGwsImRvY3VtZW50TnVtYmVyIjpudWxsLCJiaXJ0aCI6bnVsbCwicXFOdW1iZXIiOm51bGwsIndlaVhpbk51bWJlciI6bnVsbCwiaHlTdGF0dXMiOm51bGwsImFkZHJlc3MiOm51bGwsImF1dG9ncmFwaCI6bnVsbCwiY29tcGFueU5hbWUiOm51bGwsImpvYk51bWJlciI6MSwiZGVwYXJ0bWVudCI6bnVsbCwicG9zaXRpb24iOm51bGwsInJ6RGF0ZSI6bnVsbCwienpEYXRlIjpudWxsLCJsekRhdGUiOm51bGwsInR4RGF0ZSI6bnVsbCwiaW53b3JrVHlwZSI6bnVsbCwid29ya0RhdGUiOm51bGwsInBob3RvIjpudWxsLCJ1cmdlbnRQZXJzb24xIjpudWxsLCJ1cmdlbnRQZXJzb24yIjpudWxsLCJoZWFkUG9ydHJhaXQiOm51bGwsInNraWxsIjpudWxsLCJ0b3RsZVNjb3JlIjowLCJjb250cmFjdCI6bnVsbCwidG9rZW4iOiJleUowZVhBaU9pSktWMVFpTENKaGJHY2lPaUpJVXpJMU5pSjkuZXlKMWMyVnlJanA3SW1sa0lqb2lOV1UxWkRrME1UY3RaalpoWVMwME1ERXdMV0l4TnpndFltUmxaRGd3T0RZM09ERTFJaXdpWTI5dGNHRnVlVWxrSWpwdWRXeHNMQ0pqYjIxd1lXNTVSbkpoYldWM2IzSnJTV1FpT201MWJHd3NJbkJ2YzNSSlpDSTZiblZzYkN3aWJtRnRaU0k2Ym5Wc2JDd2liRzluYVc1QlkyTnZkVzUwSWpwdWRXeHNMQ0pzYjJkcGJsQmhjM04zYjNKa0lqb2lhMGcyWnpZMmMwNDVVVU5pVlRWbVNXSTVXVTlPVG1oVk5pOVFRbmRCWlZnNFlYb3pVR3BGZFdwWlp6MGlMQ0p6WlhnaU9tNTFiR3dzSW5Cb2IyNWxJam9pYzNSeWFXNW5JaXdpZEdWc1pYQm9iMjVsSWpwdWRXeHNMQ0p0WVdsc0lqcHVkV3hzTENKa2IyTjFiV1Z1ZEZSNWNHVWlPbTUxYkd3c0ltUnZZM1Z0Wlc1MFRuVnRZbVZ5SWpwdWRXeHNMQ0ppYVhKMGFDSTZiblZzYkN3aWNYRk9kVzFpWlhJaU9tNTFiR3dzSW5kbGFWaHBiazUxYldKbGNpSTZiblZzYkN3aWFIbFRkR0YwZFhNaU9tNTFiR3dzSW1Ga1pISmxjM01pT201MWJHd3NJbUYxZEc5bmNtRndhQ0k2Ym5Wc2JDd2lZMjl0Y0dGdWVVNWhiV1VpT201MWJHd3NJbXB2WWs1MWJXSmxjaUk2TVN3aVpHVndZWEowYldWdWRDSTZiblZzYkN3aWNHOXphWFJwYjI0aU9tNTFiR3dzSW5KNlJHRjBaU0k2Ym5Wc2JDd2llbnBFWVhSbElqcHVkV3hzTENKc2VrUmhkR1VpT201MWJHd3NJblI0UkdGMFpTSTZiblZzYkN3aWFXNTNiM0pyVkhsd1pTSTZiblZzYkN3aWQyOXlhMFJoZEdVaU9tNTFiR3dzSW5Cb2IzUnZJanB1ZFd4c0xDSjFjbWRsYm5SUVpYSnpiMjR4SWpwdWRXeHNMQ0oxY21kbGJuUlFaWEp6YjI0eUlqcHVkV3hzTENKb1pXRmtVRzl5ZEhKaGFYUWlPbTUxYkd3c0luTnJhV3hzSWpwdWRXeHNMQ0owYjNSc1pWTmpiM0psSWpvd0xDSmpiMjUwY21GamRDSTZiblZzYkN3aWRHOXJaVzRpT2lKbGVVb3daVmhCYVU5cFNrdFdNVkZwVEVOS2FHSkhZMmxQYVVwSlZYcEpNVTVwU2prdVpYbEtNV015Vm5sSmFuQTNTVzFzYTBscWIybE9WMVV4V2tSck1FMVVZM1JhYWxwb1dWTXdNRTFFUlhkTVYwbDRUbnBuZEZsdFVteGFSR2QzVDBSWk0wOUVSVEZKYVhkcFdUSTVkR05IUm5WbFZXeHJTV3B3ZFdSWGVITk1RMHBxWWpJeGQxbFhOVFZTYmtwb1lsZFdNMkl6U25KVFYxRnBUMjAxTVdKSGQzTkpia0oyWXpOU1NscERTVFppYmxaellrTjNhV0p0Um5SYVUwazJZbTVXYzJKRGQybGlSemx1WVZjMVFsa3lUblprVnpVd1NXcHdkV1JYZUhOTVEwcHpZakprY0dKc1FtaGpNMDR6WWpOS2EwbHFiMmxoTUdjeVducFpNbU13TkRWVlZVNXBWbFJXYlZOWFNUVlhWVGxQVkcxb1ZrNXBPVkZSYm1SQ1dsWm5ORmxZYjNwVlIzQkdaRmR3V2xwNk1HbE1RMHA2V2xobmFVOXROVEZpUjNkelNXNUNiMkl5Tld4SmFtOXBZek5TZVdGWE5XNUphWGRwWkVkV2MxcFlRbTlpTWpWc1NXcHdkV1JYZUhOTVEwcDBXVmRzYzBscWNIVmtWM2h6VEVOS2EySXlUakZpVjFaMVpFWlNOV05IVldsUGJUVXhZa2QzYzBsdFVuWlpNMVowV2xjMU1GUnVWblJaYlZaNVNXcHdkV1JYZUhOTVEwcHBZVmhLTUdGRFNUWmlibFp6WWtOM2FXTllSazlrVnpGcFdsaEphVTl0TlRGaVIzZHpTVzVrYkdGV2FIQmlhelV4WWxkS2JHTnBTVFppYmxaellrTjNhV0ZJYkZSa1IwWXdaRmhOYVU5dE5URmlSM2R6U1cxR2ExcElTbXhqTTAxcFQyMDFNV0pIZDNOSmJVWXhaRWM1Ym1OdFJuZGhRMGsyWW01V2MySkRkMmxaTWpsMFkwZEdkV1ZWTldoaVYxVnBUMjAxTVdKSGQzTkpiWEIyV1dzMU1XSlhTbXhqYVVrMlRWTjNhVnBIVm5kWldFb3dZbGRXZFdSRFNUWmlibFp6WWtOM2FXTkhPWHBoV0ZKd1lqSTBhVTl0TlRGaVIzZHpTVzVLTmxKSFJqQmFVMGsyWW01V2MySkRkMmxsYm5CRldWaFNiRWxxY0hWa1YzaHpURU5LYzJWclVtaGtSMVZwVDIwMU1XSkhkM05KYmxJMFVrZEdNRnBUU1RaaWJsWnpZa04zYVdGWE5UTmlNMHB5Vmtoc2QxcFRTVFppYmxaellrTjNhV1F5T1hsaE1GSm9aRWRWYVU5dE5URmlSM2R6U1c1Q2IySXpVblpKYW5CMVpGZDRjMHhEU2pGamJXUnNZbTVTVVZwWVNucGlNalI0U1dwd2RXUlhlSE5NUTBveFkyMWtiR0p1VWxGYVdFcDZZakkwZVVscWNIVmtWM2h6VEVOS2IxcFhSbXRWUnpsNVpFaEthR0ZZVVdsUGJUVXhZa2QzYzBsdVRuSmhWM2h6U1dwd2RXUlhlSE5NUTBvd1lqTlNjMXBXVG1waU0wcHNTV3B2ZDB4RFNtcGlNalV3WTIxR2FtUkRTVFppYmxaellrTjNhV1JIT1hKYVZ6UnBUMmxLYkdWVmIzZGFWbWhDWVZVNWNGTnJkRmROVmtad1ZFVk9TMkZIU2toWk1teFFZVlZ3U2xaWWNFcE5WVFZ3VTJwcmRWcFliRXROVjAxNVZtNXNTbUZ1UVROVFZ6RnpZVEJzY1dJeWJFOVdNVlY0VjJ0U2NrMUZNVlZaTTFKaFlXeHdiMWRXVFhkTlJURkZVbGhrVFZZd2JEUlVibkJ1WkVac2RGVnRlR0ZTUjJRelZEQlNXazB3T1VWU1ZFWktZVmhrY0ZkVVNUVmtSMDVJVW01V2JGWlhlSEpUVjNCM1pGZFNXR1ZJVGsxUk1IQnhXV3BKZUdReGJGaE9WRlpUWW10d2IxbHNaRmROTWtsNlUyNUtWRll4Um5CVU1qQXhUVmRLU0dRelRrcGlhMG95V1hwT1UxTnNjRVJUVkZwcFlteGFlbGxyVGpOaFYwcDBVbTVTWVZVd2F6SlpiVFZYWXpKS1JHUXliR2xTZW14MVdWWmpNVkZzYTNsVWJscHJWbnBWZDFOWGNIZGtWMUpZWlVoT1RWRXdjSHBaYWtwclkwZEtjMUZ0YUdwTk1EUjZXV3BPUzJFd2JIRmlNbXhvVFVkamVWZHVjRnBOYlUxM1RrUldWbFpWTlhCV2JGSlhZbFpPV0ZOVVZsaFdWR3hRVmtjeGIxWnJOWEJQVmtaU1ltMVNRMWRzV201T1JteFpZak53VmxJelFrZGFSbVIzVjJ4d05rMUhiRTFSTUhBMlYyeG9ibUZWT1hST1ZFWnBVak5rZWxOWE5VTmlNa2w1VGxkNFNtRnRPWEJaZWs1VFpWZEdXRTVYTlVwaFdHUndXa1ZrVjJNeGNGbFJiVGxwVFdwV2MxTlhjSGRrVjFKWVpVaE9UVkV3Y0RCWFZtUnpZekJzY1dOSVZtdFdNMmg2VkVWT1MyRXlTWGxVYWtacFZqRmFNVnBGV2xOT1YwNUlWbGRzVUdKVVZYaFphMlF6WXpCc2RGVnVXbHBOTVZvd1YyeGpNVTFHVW5WV2JsSmFZbFphTlZOWGNIZGtWMUpZWlVoT1RWRXdjSEJaVm1oTFRVZEdSRk5VV21saWJGcDZXV3R'

    }

}