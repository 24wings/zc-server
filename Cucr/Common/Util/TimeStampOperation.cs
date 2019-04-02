using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace CucrSaasDataAccess.Common
{
    public class TimeStampOperation
    {
        //时间==》时间戳
        public static long EnTimeStamp(DateTime dateTime)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, dateTime.Kind);
            return Convert.ToInt64((dateTime - start).TotalSeconds);
        }

        //时间戳==》时间
        public static DateTime DeTimeStamp(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

    }
}
