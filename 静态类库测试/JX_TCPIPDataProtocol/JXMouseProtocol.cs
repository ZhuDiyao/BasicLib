using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JX_TCPIPDataProtocol.JXMouseProtocolAPI;

namespace JX_TCPIPDataProtocol
{
    /// <summary>
    /// 在正常项目中禁止调用此类下面的任何方法。诸迪耀201911151354
    /// 鼠标交互协议
    /// </summary>
    public class JXMouseProtocol
    {
        /// <summary>
        /// 查看鼠标当前位置
        /// </summary>
        /// <returns></returns>
        public static Point SeeMousePoint()
        {
            Point returnPoint = new Point();
            PONITAPI p = new PONITAPI();
            GetCursorPos(ref p);
            returnPoint.X = p.x;
            returnPoint.Y = p.y;
            return returnPoint;
        }
        /// <summary>
        /// 让鼠标移动到指定位置
        /// </summary>
        /// <param name="p"></param>
        public static void MouseMove(Point p)
        {
            SetCursorPos(p.X, p.Y);
        }
        /// <summary>
        /// 让鼠标左击
        /// </summary>
        public static void MouseLeftClick()
        {
            Point p = SeeMousePoint();
            mouse_event(MOUSEEVENTF_LEFTDOWN, p.X, p.Y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, p.X, p.Y, 0, 0);
        }
        /// <summary>
        /// 让鼠标右击
        /// </summary>
        public static void MouseRightClick()
        {
            Point p = SeeMousePoint();
            mouse_event(MOUSEEVENTF_RIGHTDOWN, p.X, p.Y, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTUP, p.X, p.Y, 0, 0);
        }
    }
}
