using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JX_StandardMethod_WMS
{
    /// <summary>
    /// 佳轩文件路径工具类
    /// </summary>
    public class JXFilePathUtil
    {
        private static List<string> str = new List<string>();
        /// <summary>
        /// 浏览目录
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<string> SeePath(string path)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(path);
                DirectoryInfo[] dis = di.GetDirectories();
                if (dis.Length == 0 || dis == null)
                {
                    return str;
                }
                for (int i = 0; i < dis.Length; i++)
                {
                    str.Add(dis[i].FullName + "\\");
                }
                FileInfo[] fis = di.GetFiles();
                for (int i = 0; i < fis.Length; i++)
                {
                    str.Add(fis[i].FullName);
                }
            }
            catch (Exception)
            {
            }
            List<string> RrturnList = str;
            str = new List<string>();
            return RrturnList;
        }

        /// <summary>
        /// 
        /// 校验文件路径是否存在，如果不存在，则创建。
        /// 未发生异常 返回 true
        ///   发生异常 返回 false
        ///   
        /// 请注意参数，路径结尾必须带有 “\”，从左上向右下的斜杠。否则最后一级会被认为是文件名
        /// 正确示例：
        /// 1、C:\Users\ZhuDiyao\Desktop\
        /// 2、C:\Users\ZhuDiyao\Desktop\新建文本文档 (2).txt
        /// 错误示例：(如果这样做，会错误的创建文件夹。)
        /// 1、C:\Users\ZhuDiyao\Desktop
        /// 2、C:\Users\ZhuDiyao\Desktop\新建文本文档 (2).txt\
        /// </summary>
        /// <param name="Path">请注意参数，路径结尾必须带有 “\”，从左上向右下的斜杠。否则最后一级会被认为是文件名 </param>
        public static bool CheckPath(string Path)
        {
            try
            {
                int 最后一位斜杠值 = Path.LastIndexOf("\\");
                if (最后一位斜杠值 == -1)
                {
                    return true;
                }
                Path = Path.Substring(0, 最后一位斜杠值);
                if (Path.Equals(""))
                {
                    return true;
                }
                int 字符路径长度 = Path.Length;
                if (!Directory.Exists(Path))
                {
                    Directory.CreateDirectory(Path);

                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 传入完整的路径 【示例（Y:\$AI_beijing\相关资料\TestDEMO_倪工\826he9604.proj）】
        /// 传入标记
        /// 标记为【1】，返回文件所在的路径，最后不带斜杠【返回示例（Y:\$AI_beijing\相关资料\TestDEMO_倪工）】
        /// 标记为【2】，返回文件名，包含后缀【返回示例（826he9604.proj）】
        /// 标记为【3】，返回文件名，不包含后缀【返回示例（826he9604）】
        /// </summary>
        /// <param name="FullPath">完成的路径</param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public static string GetDesignatedValue(string FullPath,int flag)
        {
            try
            {
                switch (flag)
                {
                    case 1:
                        {
                            return FullPath.Substring(0, FullPath.LastIndexOf("\\"));
                        }

                    case 2:
                        {
                            return FullPath.Substring(FullPath.LastIndexOf("\\")+1,FullPath.Length- FullPath.LastIndexOf("\\")-1);
                        }

                    case 3:
                        {
                            string sss = FullPath.Substring(FullPath.LastIndexOf("\\") + 1, FullPath.Length - FullPath.LastIndexOf("\\") - 1);
                            return sss.Substring(0, sss.IndexOf("."));
                        }
                }
            }
            catch
            {
                
            }
            return null;
        }
    }
}
