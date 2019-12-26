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
    public class JXMouseProtocolAPI
    {
        /// <summary>
        /// 鼠标控制参数
        /// </summary>
        public const int MOUSEEVENTF_LEFTDOWN = 0x2;
        public const int MOUSEEVENTF_LEFTUP = 0x4;
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x20;
        public const int MOUSEEVENTF_MIDDLEUP = 0x40;
        public const int MOUSEEVENTF_MOVE = 0x1;
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x8;
        public const int MOUSEEVENTF_RIGHTUP = 0x10;

        /// <summary>
        /// 鼠标的位置
        /// </summary>
        public struct PONITAPI
        {
            public int x, y;
        }

        [DllImport("user32.dll")]
        public static extern int GetCursorPos(ref PONITAPI p);

        [DllImport("user32.dll")]
        public static extern int SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

    }
}
