using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JX_StandardMethod_WMS
{
    /// <summary>
    /// 佳轩Http请求，以保持连接的方式进行请求。可以模拟登陆后取数据。
    /// </summary>
    public class JXHTTPKeepConnect
    {
        /// <summary>
        /// 保存cookie，以达到保持连接的目的。
        /// </summary>
        private static CookieContainer cc = new CookieContainer();
        /// <summary>
        /// 执行保持连接形式的post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="RequestParameters"></param>
        /// <returns></returns>
        public static string DoPost(string url,string RequestParameters)
        {
            try
            {
                HttpWebRequest request = null;
                //string url = url1;
                request = (HttpWebRequest)WebRequest.Create(url);
                request.CookieContainer = cc; //给第一个request指定容器
                request.Method = "POST";
                request.Accept = "*/*;";
                request.UserAgent = "Mozilla/5.0";
                request.ContentType = "application/x-www-form-urlencoded";
                request.AllowAutoRedirect = true;
                request.KeepAlive = true;
                string postData = string.Format(RequestParameters);
                byte[] postdatabyte = Encoding.GetEncoding("utf-8").GetBytes(postData);
                request.ContentLength = postdatabyte.Length;
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(postdatabyte, 0, postdatabyte.Length);
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                {
                    string strWebData = string.Empty;
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")))
                    {
                        strWebData = reader.ReadToEnd();
                    }
                    return strWebData;
                }
            }
            catch
            {
                
            }
            return "";

        }

    }
}
