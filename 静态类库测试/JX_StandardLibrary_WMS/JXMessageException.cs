using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JX_StandardLibrary_WMS
{
    /// <summary>
    /// 佳轩异常消息类
    /// 调用参考【throw new JXMessageException("123");】
    /// </summary>
    public class JXMessageException :Exception
    {
        private string ErrorMessage;

        private Exception ThisException;
        /// <summary>
        /// 无参构造，不建议调用
        /// </summary>
        public JXMessageException()
        {

        }
        /// <summary>
        /// 建议使用此构造方法
        /// 调用参考【throw new JXMessageException("123");】
        /// </summary>
        /// <param name="msg"></param>
        public JXMessageException(string msg) : base(msg)
        {
            this.ErrorMessage = msg;
        }
    }
}
