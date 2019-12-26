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
    /// 用于进行HTTP请求
    /// </summary>
    public class JXHTTP
    {
        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="geturl">请求地址</param>
        /// <returns></returns>
        public static string GetPage(string geturl)
        {
            try
            {

                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(geturl);
                myRequest.Method = "GET";
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                string content = reader.ReadToEnd();
                reader.Close();
                return content;
            }
            catch (WebException we)
            {
                string crr = "error" + we.Message + we.Status;
                return crr;
            }
            catch (Exception ex)
            {
                string err = "error" + ex.Message;
                return err;
            }
            //return string.Empty;
        }

        /// <summary>
        /// Post请求，如果请求失败没有响应 返回空字符串
        /// </summary>
        /// <param name="posturl">请求地址</param>
        /// <param name="postData">内容</param>
        /// <returns></returns>
        public static string PostPage(string posturl, string postData)
        {
            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            Encoding encoding = Encoding.UTF8;
            byte[] data = encoding.GetBytes(postData);
            // 准备请求...
            try
            {
                // 设置参数
                request = WebRequest.Create(posturl) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                outstream = request.GetRequestStream();
                outstream.Write(data, 0, data.Length);
                outstream.Close();
                //发送请求并获取相应回应数据
                response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                instream = response.GetResponseStream();
                sr = new StreamReader(instream, encoding);
                //返回结果网页（html）代码
                string content = sr.ReadToEnd();
                string err = string.Empty;
                return content;
            }
            catch (WebException we)
            {
                string crr = "error" + we.Message + we.Status;
            }
            catch (Exception ex)
            {
                string err = "error" + ex.Message;

            }
            return string.Empty;
        }




        /// <summary>
        /// Http上传文件
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string HttpUploadFile(string url, string path)
        {
            try
            {
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                string boundary = DateTime.Now.Ticks.ToString("X"); // 随机分隔线
                request.ContentType = "multipart/form-data;charset=utf-8;boundary=" + boundary;
                byte[] itemBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
                byte[] endBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

                int pos = path.LastIndexOf("\\");
                string fileName = path.Substring(pos + 1);

                //请求头部信息 
                StringBuilder sbHeader = new StringBuilder(string.Format("Content-Disposition:form-data;name=\"fileContent\";filename=\"{0}\"\r\nContent-Type:application/octet-stream\r\n\r\n", fileName));
                byte[] postHeaderBytes = Encoding.UTF8.GetBytes(sbHeader.ToString());

                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                byte[] bArr = new byte[fs.Length];
                fs.Read(bArr, 0, bArr.Length);
                fs.Close();

                Stream postStream = request.GetRequestStream();
                postStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
                postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
                postStream.Write(bArr, 0, bArr.Length);
                postStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
                postStream.Close();

                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream instream = response.GetResponseStream();
                StreamReader sr = new StreamReader(instream, Encoding.UTF8);
                //返回结果网页（html）代码
                string content = sr.ReadToEnd();
                return content;
            }
            catch (WebException we)
            {
                string crr = we.Message + we.Status;
            }
            catch (Exception ex)
            {
                string err = ex.Message;

            }
            return string.Empty;


        }


        /// <summary>
        /// Http上传文件【无效】
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string HttpUploadFile2(string url, string path)
        {
            try
            {
                string 文件参数名称 = "fileContent";
                string 信息参数名称 = "otherMessage";
                string 信息参数内容 = "{'n':'1'}";
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                string boundary = DateTime.Now.Ticks.ToString("X"); // 随机分隔线
                request.ContentType = "multipart/form-data;charset=utf-8;boundary=" + boundary;
                byte[] itemBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
                byte[] endBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

                int pos = path.LastIndexOf("\\");
                string fileName = path.Substring(pos + 1);

                //请求头部信息 
                StringBuilder sbHeader = new StringBuilder(
                    string.Format("Content-Disposition:form-data;name=\""+ 文件参数名称 + "\";filename=\"{0}\"\r\nContent-Type:application/octet-stream\r\n\r\n", fileName)
                    );
                byte[] postHeaderBytes = Encoding.UTF8.GetBytes(sbHeader.ToString());

                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                byte[] bArr = new byte[fs.Length];
                fs.Read(bArr, 0, bArr.Length);
                fs.Close();

                Stream postStream = request.GetRequestStream();
                postStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
                postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
                postStream.Write(bArr, 0, bArr.Length);
                postStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
                postStream.Close();

                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream instream = response.GetResponseStream();
                StreamReader sr = new StreamReader(instream, Encoding.UTF8);
                //返回结果网页（html）代码
                string content = sr.ReadToEnd();
                return content;
            }
            catch (WebException we)
            {
                string crr = we.Message + we.Status;
            }
            catch (Exception ex)
            {
                string err = ex.Message;

            }
            return string.Empty;


        }


        /// <summary>
        /// 文件上传【无效】
        /// </summary>
        /// <param name="webUrl"></param>
        /// <param name="localFileName"></param>
        /// <returns></returns>
        public static bool UploadFileByHttp(string webUrl, string localFileName)
        {
            // 检查文件是否存在  
            if (!System.IO.File.Exists(localFileName))
            {
                //MessageBox.Show("{0} does not exist!", localFileName);
                return false;
            }
            try
            {
                System.Net.WebClient myWebClient = new System.Net.WebClient();
                myWebClient.UploadFile(webUrl, "POST", localFileName);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /**/
        /// <summary>
        /// WebClient上传文件至服务器
        /// </summary>
        /// <param name="fileNamePath">文件名，全路径格式</param>
        /// <param name="uriString">服务器文件夹路径</param>
        //public bool UpLoadFile(string fileNamePath, string uriString)
        //{
        //    bool bo = false;
        //    string fileName = fileNamePath;//.Substring(fileNamePath.LastIndexOf("\\") + 1);
        //    string NewFileName = fileName.Substring(fileName.LastIndexOf("\\") + 1);//DateTime.Now.ToString("yyMMddhhmmss") + DateTime.Now.Millisecond.ToString() + fileNamePath.Substring(fileNamePath.LastIndexOf("."));
        //    string fileNameExt = fileName.Substring(fileName.LastIndexOf(".") + 1);
        //    if (uriString.EndsWith("/") == false) uriString = uriString + "/";

        //    uriString = uriString + NewFileName;
        //    /**/
        //    /// 创建WebClient实例
        //    WebClient myWebClient = new WebClient();
        //    myWebClient.Credentials = CredentialCache.DefaultCredentials;

        //    // 要上传的文件
        //    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        //    //FileStream fs = OpenFile();
        //    BinaryReader r = new BinaryReader(fs);
        //    try
        //    {
        //        //使用UploadFile方法可以用下面的格式
        //        //myWebClient.UploadFile(uriString,"PUT",fileNamePath);
        //        byte[] postArray = r.ReadBytes((int)fs.Length);
        //        Stream postStream = myWebClient.OpenWrite(uriString, "PUT");
        //        if (postStream.CanWrite)
        //        {
        //            postStream.Write(postArray, 0, postArray.Length);
        //        }
        //        else
        //        {
        //            bo = false;
        //            //MessageBox.Show("文件目前不可写！");
        //            //AppHelper.MessageService.ShowError();
        //        }
        //        postStream.Close();
        //        bo = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        //NJKX.Server.Util.B调试.记录("文件压缩：", ex);
        //        bo = false;
        //        //MessageBox.Show("文件上传失败，请稍候重试~" + ex.ToString());
        //        //AppHelper.MessageService.ShowError("文件上传失败，请稍候重试~");
        //    }
        //    fs.Close();
        //    return bo;
        //}

        /// <summary>
        /// 获取网页————带cookie
        /// </summary>
        /// <param name="name">cookieName</param>
        /// <param name="value">cookieValue</param>
        /// <param name="url">请求路径</param>
        /// <returns></returns>
        public string getHtml(string cookieStr, string url)
        {
            try
            {
                //  CookieCollection cookies = new CookieCollection();
                //cookies.Add(new Cookie(cookieStr));
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0; QQWubi 133; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; CIBA; InfoPath.2)";
                request.Method = "GET";
                request.Headers.Add("Cookie", cookieStr);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                return reader.ReadToEnd();
            }

            catch (WebException webEx)
            {
                string err = webEx.Message;
                return "";

            }



        }

        /// <summary>
        /// 获取图片
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fiele">图片保存路径</param>
        /// <param name="Message"></param>
        //public void picturefile(string url, string fiele, ref string Message)
        //{
        //    try
        //    {
        //        ServicePointManager.DefaultConnectionLimit = 50;
        //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //        request.Timeout = 3000000;
        //        request.UserAgent = "mozilla/4.0 (compatible; msie 7.0; windows nt 6.2; wow64; trident/7.0; .net4.0c; .net4.0e; .net clr 2.0.50727; .net clr 3.0.30729; .net clr 3.5.30729)";
        //        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //        Stream stream = response.GetResponseStream();
        //        Image image = Image.FromStream(stream);
        //        image.Save(fiele);

        //        image.Dispose();//释放bmp文件资源
        //    }
        //    catch (Exception ex)
        //    {
        //        Message = ex.Message; ;
        //    }
        //}


        /// <summary>
        /// 获取远程文件的数据流
        /// </summary>
        /// <param name="name">cookieName</param>
        /// <param name="value">cookieValue</param>
        /// <param name="url">请求路径</param>
        /// <param name="filepath">保存文件路径和文件名</param>
        /// <returns></returns>
        public string getHtmlfile(string cookieStr, string url, string filepath, ref string Message)
        {
            try
            {
                //  CookieCollection cookies = new CookieCollection();
                //  cookies.Add(new Cookie(name, value));
                //获取远程文件的数据流
                ServicePointManager.DefaultConnectionLimit = 50;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 3000000;
                request.UserAgent = "mozilla/5.0 (windows nt 10.0; wow64) applewebkit/537.36 (khtml, like gecko) chrome/55.0.2883.87 safari/537.36";
                request.Headers.Add("Cookie", cookieStr);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                // long letnt = response.ContentLength;
                FileStream fs = new FileStream(filepath, FileMode.Create);
                int bufferSize = 2048;
                byte[] bytes = new byte[bufferSize];


                int length = stream.Read(bytes, 0, bufferSize);

                while (length > 0)
                {

                    fs.Write(bytes, 0, length);
                    length = stream.Read(bytes, 0, bufferSize);

                }
                stream.Close();
                fs.Close();
                response.Close();
                request.Abort();
                return "1";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return "";
            }

        }

        /// <summary>
        /// 下载文件【可用】
        /// </summary>
        /// <param name="downloadUrl">下载路径</param>
        /// <param name="filename">保存文件名称</param>
        public static void Downfile(string downloadUrl, string filename)
        {
            //downloadUrl = "http://192.168.2.6:8080/DownFile.jiaxuan?filename=JXUSERFILEU201908091G17363380583E15";
            HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(downloadUrl);
            hwr.Timeout = 150000;
            HttpWebResponse hwp = (HttpWebResponse)hwr.GetResponse();
            Stream ss = hwp.GetResponseStream();
            byte[] buffer = new byte[1024];
            FileStream fs = new FileStream(
                string.Format(filename),
                FileMode.Create);
            try
            {
                int i;
                while ((i = ss.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fs.Write(buffer, 0, i);
                }
                fs.Close();
                ss.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
