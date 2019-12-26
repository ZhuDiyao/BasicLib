using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JX_TCPIPDataProtocol
{
    /// <summary>
    /// 在正常项目中禁止调用此类下面的任何方法。诸迪耀201911151354
    /// 键盘交互协议
    /// </summary>
    public class JXKeyProtocol
    {
        public static void Test1()
        {
            //模拟按下ctrl键
            JXKeyProtocolAPI.keybd_event(JXKeyProtocolAPI.vbKeyControl, 0, 0, 0);
            //模拟按下Alt键
            JXKeyProtocolAPI.keybd_event(JXKeyProtocolAPI.vbKeyAlt, 0, 0, 0);
            //模拟按下A键
            JXKeyProtocolAPI.keybd_event(JXKeyProtocolAPI.vbKeyA, 0, 0, 0);
            //模拟松开ctrl键
            JXKeyProtocolAPI.keybd_event(JXKeyProtocolAPI.vbKeyControl, 0, 2, 0);
            //模拟松开Alt键
            JXKeyProtocolAPI.keybd_event(JXKeyProtocolAPI.vbKeyAlt, 0, 2, 0);
            //模拟松开A键
            JXKeyProtocolAPI.keybd_event(JXKeyProtocolAPI.vbKeyA, 0, 2, 0);
        }
    }
}
