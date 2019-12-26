using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JX_StandardMethod_WMS
{
    /// <summary>
    /// 诸迪耀
    /// 20190702
    /// 请不要调用这个类，正常操作不需要使用此类。
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
    
    public class SystemTime
    {
        /// <summary>
        /// 年
        /// </summary>
        public ushort vYear;
        /// <summary>
        /// 月
        /// </summary>
        public ushort vMonth;
        /// <summary>
        /// 日
        /// </summary>
        public ushort vDayOfWeek;
        /// <summary>
        /// 日
        /// </summary>
        public ushort vDay;
        /// <summary>
        /// 时
        /// </summary>
        public ushort vHour;
        /// <summary>
        /// 分
        /// </summary>
        public ushort vMinute;
        /// <summary>
        /// 秒
        /// </summary>
        public ushort vSecond;

    }
}
