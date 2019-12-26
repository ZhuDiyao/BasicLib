using JX_StandardLibrary_WMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JX_StandardMethod_WMS
{
    /// <summary>
    /// 对C#的时间操作的补充
    /// </summary>
    public class JXDateUtil : ApplicationException
    {
        /// <summary>
        /// 将时间格式的字符串转换为时间类型。
        /// </summary>
        /// <param name="TimeStr"></param>
        /// <param name="TimeFormat"></param>
        /// <returns></returns>
        public static DateTime StringTimeToTime(string TimeStr,string TimeFormat)
        {
            return DateTime.ParseExact(TimeStr, TimeFormat, System.Globalization.CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// 比较两个时间，是否是同一天。
        /// 如果是同一天，返回 0
        /// 如果time1是在time2之前，比如（2019年1月1日，2019年8月2日），返回 -1
        /// 如果time1是在time2之后，比如（2019年9月1日，2019年8月2日），返回 1
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static int CompareTime(DateTime time1,DateTime time2)
        {
            return DateTime.Compare(time1, time2);
        }

        /// <summary>
        /// 获取当前时间的时间戳
        /// </summary>
        /// <returns></returns>
        public static long CurrentTimeMillis()
        {
            return CurrentTimeMillis(DateTime.Now);
        }
        /// <summary>
        /// 计算从 格林威治时间1970年01月01日00时00分00秒 到 参数时间 之间过去了多少毫秒。
        /// </summary>
        /// <param name="dtime">参数时间</param>
        /// <returns></returns>
        public static long CurrentTimeMillis(DateTime dtime)
        {
            return (dtime.ToUniversalTime().Ticks - 621355968000000000) / 10000;
        }

        /// <summary>
        /// 延时操作
        /// </summary>
        /// <param name="ms">毫秒</param>
        public static void Wait(int ms)
        {
            DateTime InitTime = DateTime.Now;
            DateTime OverTime = DateTime.Now;
            OverTime = OverTime.AddMilliseconds(ms);
            while (true)
            {
                InitTime = DateTime.Now;
                if (OverTime < InitTime)
                {
                    return;
                }
            }
        }
        /// <summary>
        /// 
        /// 获取服务端时间（如果获取失败，返回null）。请注意这个方法非常消耗时间。
        /// </summary>
        /// <returns></returns>
        public static string GetServiceTime()
        {
            string timestrX = JXHTTP.PostPage("http://time.jiaxuan.info/CheckTime.jiaxuan", "");
            if (timestrX.Equals(""))
            {
                return null;
            }
            JX_m_Message_SM OBJResultStr = JXJsonToObjetc.FromJSON<JX_m_Message_SM>(timestrX);
            if (!OBJResultStr.a_Result.Equals("success"))
            {
                return null;
            }
            return OBJResultStr.a_Time;
        }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public JXDateUtil() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public JXDateUtil(string message)
            : base(message) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public JXDateUtil(string message, Exception inner)
            : base(message, inner) { }


        /// <summary>
        /// 服务器时间成功获取标记
        /// </summary>
        static bool 服务器时间获取成功标记 = false;
        /// <summary>
        /// 毫秒
        /// </summary>
        static long 时间差;
        /// <summary>
        /// 记录时间校准线程是否正确开启
        /// </summary>
        static bool 线程校准标记 = false;

        /// <summary>
        /// 快速获取服务端时间。
        /// 
        /// ！如果项目中调用了此方法。
        /// 必须在主窗体退出时，通知线程退出。
        /// 主程序退出标记.主程序退出标记值 = true;
        /// </summary>
        /// <returns></returns>
        public static string GetServiceTimeFast()
        {
            if (!线程校准标记)
            {
                线程校准标记 = true;
                Thread t1 = new Thread(线程校准实际差);
                t1.Start();
            }

            if (!服务器时间获取成功标记)
            {
                校准时间差();
            }
            if (!服务器时间获取成功标记)
            {
                var ex = new JXDateUtil("引发了佳轩标准库的异常：向服务器请求标准时间时出错，请检查网络。");
                throw ex;
                //return null;
            }
            DateTime LocalTime = DateTime.Now.ToLocalTime();
            LocalTime = LocalTime.AddMilliseconds(时间差);
            return LocalTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>
        /// 此方法会调整时间差
        /// </summary>
        /// <returns></returns>
        public static void 校准时间差()
        {
            string ServiceTime = JXDateUtil.GetServiceTime();
            if (ServiceTime == null)
            {
                return;
            }
            DateTime LocalTime = DateTime.Now.ToLocalTime();
            DateTime ServeTime = JXDateUtil.StringTimeToTime(ServiceTime, "yyyy-MM-dd HH:mm:ss");
            long LocalTime_ = JXDateUtil.CurrentTimeMillis(LocalTime);
            long ServeTime_ = JXDateUtil.CurrentTimeMillis(ServeTime);
            时间差 = ServeTime_ - LocalTime_;
            服务器时间获取成功标记 = true;
        }
        /// <summary>
        /// 开启一个线程来不停的校准时间差，保证时间的准确性。
        /// </summary>
        public static void 线程校准实际差()
        {
            while (true)
            {
                try
                {
                    if (主程序退出标记.主程序退出标记值)
                    {
                        break;
                    }
                    校准时间差();
                    Thread.Sleep(2 * 1000);
                }
                catch
                {

                }
            }
        }

    }
}
