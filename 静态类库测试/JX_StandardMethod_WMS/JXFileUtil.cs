using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JX_StandardMethod_WMS
{
    /// <summary>
    /// 文件读写工具类
    /// </summary>
    public class JXFileUtil
    {
        /// <summary>
        /// 将文件转换成byte[] 数组
        /// </summary>
        /// <param name="fileUrl">文件路径文件名称</param>
        /// <returns>byte[]</returns>
        public static byte[] FileToByteArray(string fileUrl)
        {
            FileStream fs = new FileStream(fileUrl, FileMode.Open, FileAccess.Read);
            try
            {
                byte[] buffur = new byte[fs.Length];
                fs.Read(buffur, 0, (int)fs.Length);

                return buffur;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }
        /// <summary>
        /// 字节数组转文件
        /// </summary>
        /// <param name="fileUrl"></param>
        /// <param name="bytearr"></param>
        public static void ByteArrayToFile(string fileUrl, byte[] bytearr)
        {
            fileUrl = fileUrl.Trim();
            File.WriteAllBytes(fileUrl, bytearr);
        }
        /// <summary>
        /// 文件写出，传入字符串
        /// </summary>
        public static void StringToFile(string FilePath, string str)
        {
            FileStream fs = new FileStream(FilePath, FileMode.Create);
            //获得字节数组
            byte[] data = Encoding.UTF8.GetBytes(str);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }
        /// <summary>
        /// 文件读取
        /// </summary>
        /// <param name="path"></param>
        public static string FileToString(string path)
        {
            //直接读取出字符串
            try
            {
                string text = File.ReadAllText(path);
                return text;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 传入目标路径，搜索关键字。返回最新的文件。
        /// 只要文件名中包含 key，就在筛选范围内。
        /// 取文件名 请使用 
        /// Name
        /// 取文件创建时间 请使用
        /// CreationTime
        /// </summary>
        /// <param name="path"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static FileInfo GetNewFile(string path,string key)
        {
            DirectoryInfo root = new DirectoryInfo(path);
            FileInfo[] files = root.GetFiles();
            long NewestFileCreationTime = 0;
            string NewestFileName = "";
            FileInfo fileInfo=null;
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Name.Contains(key))
                {
                    DateTime dt = files[i].CreationTime;
                    NewestFileCreationTime = JXDateUtil.CurrentTimeMillis(dt);
                    NewestFileName = files[i].Name;
                    fileInfo = files[i];
                }
            }
            return fileInfo;
        }
        /// <summary>
        /// 传入目录,请注意目录最后 不能 有斜杠 \ ，返回目录下所有文件
        /// 【0】仅文件名
        /// 【1】全路径包含文件名
        /// </summary>
        /// <param name="path"></param>
        /// <param name="flag">【0】仅文件名...【1】全路径包含文件名...</param>
        /// <returns></returns>
        public static List<string> GetFileList(string path,int flag)
        {
            DirectoryInfo root = new DirectoryInfo(path);
            FileInfo[] files = root.GetFiles();
            List<string> filelist = new List<string>();
            for (int i = 0; i < files.Length; i++)
            {
                if (flag == 0)
                {
                    filelist.Add(files[i].Name);
                }
                if (flag == 1)
                {
                    filelist.Add(path + "\\" + files[i].Name);
                }
            }
            return filelist;

        }
    }
}
