using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JX_StandardLibrary_WMS
{
    /// <summary>
    /// 用于统一标准时间格式
    /// </summary>
    public class JXDateFormat
    {
        /// <summary>
        /// 年月日的时间格式标准
        /// </summary>
        /// <returns></returns>
        public static string DF_yyyyMMdd()
        {
            return "yyyy-MM-dd";
        }
        /// <summary>
        /// 年月日时分秒的时间格式标准
        /// </summary>
        /// <returns></returns>
        public static string DF_yyyyMMddHHmmss()
        {
            return "yyyy-MM-dd HH:mm:ss";
        }
        /// <summary>
        /// 年月日时分秒毫秒的时间格式标准
        /// </summary>
        /// <returns></returns>
        public static string DF_yyyyMMddHHmmssfff()
        {
            return "yyyy-MM-dd HH:mm:ss.fff";
        }
    }
}
