using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace CucrSaasDataAccess.Common
{
    /// <summary>
    /// 时间戳工具类
    /// </summary>
    public class TimeStampOperation
    {

        /// <summary>
        ///     时间==》时间戳
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long EnTimeStamp(DateTime dateTime)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, dateTime.Kind);
            return Convert.ToInt64((dateTime - start).TotalSeconds);
        }

        /// <summary>
        /// 时间戳==》时间
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime DeTimeStamp(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

    }
}
