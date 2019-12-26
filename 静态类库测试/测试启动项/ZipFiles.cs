using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 测试启动项
{
    ///// <summary>
    ///// 制作压缩包（多个文件压缩到一个压缩包，支持加密、注释）
    ///// </summary>
    ///// <param name="fileNames">要压缩的文件</param>
    ///// <param name="topDirectoryName">压缩文件目录</param>
    ///// <param name="zipedFileName">压缩包文件名</param>
    ///// <param name="compresssionLevel">压缩级别 1-9</param>
    ///// <param name="password">密码</param>
    ///// <param name="comment">注释</param>
    //public static void ZipFiles(string[] fileNames, string topDirectoryName, string zipedFileName, int? compresssionLevel, string password = "", string comment = "")
    //{
    //    using (ZipOutputStream zos = new ZipOutputStream(File.Open(zipedFileName, FileMode.OpenOrCreate)))
    //    {
    //        if (compresssionLevel.HasValue)
    //        {
    //            zos.SetLevel(compresssionLevel.Value);//设置压缩级别
    //        }

    //        if (!string.IsNullOrEmpty(password))
    //        {
    //            zos.Password = password;//设置zip包加密密码
    //        }

    //        if (!string.IsNullOrEmpty(comment))
    //        {
    //            zos.SetComment(comment);//设置zip包的注释
    //        }

    //        foreach (string file in fileNames)
    //        {
    //            string fileName = string.Format("{0}/{1}", topDirectoryName, file);
    //            if (File.Exists(fileName))
    //            {
    //                FileInfo item = new FileInfo(fileName);
    //                FileStream fs = File.OpenRead(item.FullName);
    //                byte[] buffer = new byte[fs.Length];
    //                fs.Read(buffer, 0, buffer.Length);

    //                ZipEntry entry = new ZipEntry(item.Name);
    //                zos.PutNextEntry(entry);
    //                zos.Write(buffer, 0, buffer.Length);
    //            }
    //        }
    //    }
    //}
}
