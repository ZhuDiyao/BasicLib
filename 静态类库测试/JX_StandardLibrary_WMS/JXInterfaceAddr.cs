using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JX_StandardLibrary_WMS
{
    /// <summary>
    /// 请求接口地址信息
    /// </summary>
    public class JXInterfaceAddr
    {

        /// <summary>
        /// 请求基础地址
        /// </summary>
        private static string BasicAddr="http://101.227.67.120:30007/";
        
        /// <summary>
        /// 应使用POST请求，请求参数包含【uname（用户名）】【pword（密码）】
        /// </summary>
        /// <returns></returns>
        public static string GetLoginInterface()
        {
            return BasicAddr+ "logincheck.jxwlcheck";
        }
    }
}
