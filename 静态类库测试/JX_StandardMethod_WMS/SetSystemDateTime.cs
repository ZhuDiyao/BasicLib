using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace JX_StandardMethod_WMS
{
    /// <summary>
    /// 修改操作系统时间
    /// </summary>
    public class SetSystemDateTime
    {
        /// <summary>
        /// 获取 本地时间
        /// </summary>
        /// <param name="st"></param>
        [DllImportAttribute("Kernel32.dll")]
        public static extern void GetLocalTime(SystemTime st);
        /// <summary>
        /// 设置 本地时间
        /// </summary>
        /// <param name="st"></param>
        [DllImportAttribute("Kernel32.dll")]
        public static extern void SetLocalTime(SystemTime st);

    }
}
