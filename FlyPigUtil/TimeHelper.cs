using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlyPig.Util
{
    public class TimeHelper
    {
        //static public string LongDateTimeToDateTimeString(string longDateTime)
        //{
        //    //用来格式化long类型时间的,声明的变量
        //    long unixDate;
        //    DateTime start;
        //    DateTime date;
        //    //ENd

        //    unixDate = long.Parse(longDateTime);
        //    start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        //    date = start.AddMilliseconds(unixDate).ToLocalTime();

        //    return date.ToString("yyyy-MM-dd HH:mm:ss");

        //}

        //public static DateTime ConvertStringToDateTime(string timeStamp)
        //{
        //    DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        //    long lTime = long.Parse(timeStamp + "0000");
        //    TimeSpan toNow = new TimeSpan(lTime);
        //    return dtStart.Add(toNow);
        //}

        /// <summary>
        /// Unix time stamp to DateTime
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime GetTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

        /// <summary>
        /// DateTiem to Unix time stamp
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }  
    }
}
