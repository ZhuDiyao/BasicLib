using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JX_TCPIPDataProtocol
{
    /// <summary>
    /// 在正常项目中禁止调用此类下面的任何方法。诸迪耀201911151354
    /// 
    /// </summary>
    public class PlatFormInvokeUSER32
    {
        //引入一些USER32中的方法
        public const int SM_CXSCREEN = 0;
        public const int SM_CYSCREEN = 1;

        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll", EntryPoint = "GetDC")]
        public static extern IntPtr GetDC(IntPtr ptr);

        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        public static extern int GetSystemMetrics(int abc);

        [DllImport("user32.dll", EntryPoint = "GetWindowDC")]
        public static extern IntPtr GetWindowDC(Int32 ptr);

        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

        public PlatFormInvokeUSER32()
        {

        }

        //屏幕大小
        public struct SIZE
        {
            public int cx;
            public int cy;
        }
    }
}
