using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JX_TCPIPDataProtocol
{
    /// <summary>
    /// 在正常项目中禁止调用此类下面的任何方法。诸迪耀201911151354
    /// 佳轩TCPIP文件传输协议
    /// </summary>
    public class JXFileProtocol
    {
        /// <summary>
        /// 命令长度
        /// </summary>
        public static readonly int CommandLength = 4096;



        /// <summary>
        /// 创建标准命令
        /// </summary>
        /// <param name="Command">未补齐的命令</param>
        /// <param name="Annex">附件</param>
        /// <returns></returns>
        public static byte[] SynthesisCommand(byte[] Command, byte[] Annex)
        {
            byte[] AllZero = new byte[CommandLength - Command.Length];
            Command = Command.Concat(AllZero).ToArray();
            byte[] Result = Command.Concat(Annex).ToArray();
            return Result;
        }
        /// <summary>
        /// 获取消息的命令部分
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static byte[] GetCommand(byte[] Message)
        {
            byte[] Result = new byte[CommandLength];
            Array.Copy(Message, 0, Result, 0, CommandLength);
            return Result;
        }
        /// <summary>
        /// 获取消息的文件部分
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static byte[] GetAnnex(byte[] Message)
        {
            byte[] Result = new byte[Message.Length - CommandLength];
            Array.Copy(Message, CommandLength, Result, 0, Message.Length - CommandLength);
            return Result;
        }
    }
}
