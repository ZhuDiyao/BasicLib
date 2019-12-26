using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JX_StandardMethod_WMS
{
    /// <summary>
    /// 文件压缩和解压缩操作工具类
    /// </summary>
    public class JXZipUtil
    {
        /// <summary>
        /// 功能：将 文件夹 变成 压缩包
        /// 【传入参数1，目标文件夹路径（源）】
        /// 【传入参数2，打包文件路径（目标）】
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="PackagePath"></param>
        public static void ToPackage(string FilePath, string PackagePath)
        {
            JXZipUtil zipUtility = new JXZipUtil();
            zipUtility.ZipFileFromDirectory(FilePath, PackagePath, 0);
        }

        /// <summary>
        /// 功能：将 文件夹 变成 压缩包
        /// 【传入参数1，目标文件夹路径（源）】
        /// 【传入参数2，打包文件路径（目标）】
        /// 【传入参数3，需要排除文件的文件名，只要包含就排除】
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="PackagePath"></param>
        /// <param name="badFile"></param>
        public static void ToPackage(string FilePath, string PackagePath,List<string> badFile)
        {
            JXZipUtil zipUtility = new JXZipUtil();
            zipUtility.ZipFileFromDirectory(FilePath, PackagePath, 0, badFile);
        }
        /// <summary>
        /// 功能：将 压缩包 变成 文件夹
        /// 【传入参数1，目标包名】
        /// 【传入参数2，目标文件夹】
        /// </summary>
        /// <param name="PackagePath"></param>
        /// <param name="FilePath"></param>
        public static void ToFilePath(string PackagePath, string FilePath)
        {
            JXZipUtil zipUtility = new JXZipUtil();
            zipUtility.UnZip(PackagePath, FilePath);
        }
        /// <summary>  
        /// 压缩目录（包括子目录及所有文件）  
        /// </summary>  
        /// <param name="rootPath">要压缩的根目录</param>  
        /// <param name="destinationPath">保存路径</param>  
        /// <param name="compressLevel">压缩程度，范围0-9，数值越大，压缩程序越高</param>  
        private void ZipFileFromDirectory(string rootPath, string destinationPath, int compressLevel)
        {
            GetAllDirectories(rootPath);

            /* while (rootPath.LastIndexOf("\\") + 1 == rootPath.Length)//检查路径是否以"\"结尾 
            { 
 
            rootPath = rootPath.Substring(0, rootPath.Length - 1);//如果是则去掉末尾的"\" 
 
            } 
            */
            //string rootMark = rootPath.Substring(0, rootPath.LastIndexOf("\\") + 1);//得到当前路径的位置，以备压缩时将所压缩内容转变成相对路径。  
            string rootMark = rootPath + "\\";//得到当前路径的位置，以备压缩时将所压缩内容转变成相对路径。  
            Crc32 crc = new Crc32();
            ZipOutputStream outPutStream = new ZipOutputStream(File.Create(destinationPath));
            outPutStream.SetLevel(compressLevel); // 0 - store only to 9 - means best compression  
            foreach (string file in files)
            {
                FileStream fileStream = File.OpenRead(file);//打开压缩文件  
                byte[] buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, buffer.Length);
                ZipEntry entry = new ZipEntry(file.Replace(rootMark, string.Empty));
                entry.DateTime = DateTime.Now;

                entry.Size = fileStream.Length;
                fileStream.Close();
                crc.Reset();
                crc.Update(buffer);
                entry.Crc = crc.Value;
                outPutStream.PutNextEntry(entry);
                outPutStream.Write(buffer, 0, buffer.Length);
            }

            this.files.Clear();

            foreach (string emptyPath in paths)
            {
                ZipEntry entry = new ZipEntry(emptyPath.Replace(rootMark, string.Empty) + "/");
                outPutStream.PutNextEntry(entry);
            }

            this.paths.Clear();
            outPutStream.Finish();
            outPutStream.Close();
            GC.Collect();
        }


        /// <summary>  
        /// 压缩目录（包括子目录及所有文件）  
        /// </summary>  
        /// <param name="rootPath">要压缩的根目录</param>  
        /// <param name="destinationPath">保存路径</param>  
        /// <param name="compressLevel">压缩程度，范围0-9，数值越大，压缩程序越高</param>  
        /// <param name="badFile">坏文件列表_根据关键字排除文件_只要包含，就不打包进去</param>  
        private void ZipFileFromDirectory(string rootPath, string destinationPath, int compressLevel,List<string> badFile)
        {
            GetAllDirectories(rootPath);

            /* while (rootPath.LastIndexOf("\\") + 1 == rootPath.Length)//检查路径是否以"\"结尾 
            { 
 
            rootPath = rootPath.Substring(0, rootPath.Length - 1);//如果是则去掉末尾的"\" 
 
            } 
            */
            //string rootMark = rootPath.Substring(0, rootPath.LastIndexOf("\\") + 1);//得到当前路径的位置，以备压缩时将所压缩内容转变成相对路径。  
            string rootMark = rootPath + "\\";//得到当前路径的位置，以备压缩时将所压缩内容转变成相对路径。  
            Crc32 crc = new Crc32();
            ZipOutputStream outPutStream = new ZipOutputStream(File.Create(destinationPath));
            outPutStream.SetLevel(compressLevel); // 0 - store only to 9 - means best compression  
            foreach (string file in files)
            {
                bool flag = false;
                if (badFile!=null)
                {
                    for (int i = 0; i < badFile.Count; i++)
                    {
                        if (file.IndexOf(badFile[i]) !=-1)
                        {
                            flag = true;
                            continue;
                        }
                    }
                }
                if (flag)
                {
                    continue;
                }
                
                FileStream fileStream = File.OpenRead(file);//打开压缩文件  
                byte[] buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, buffer.Length);
                ZipEntry entry = new ZipEntry(file.Replace(rootMark, string.Empty));
                entry.DateTime = DateTime.Now;

                entry.Size = fileStream.Length;
                fileStream.Close();
                crc.Reset();
                crc.Update(buffer);
                entry.Crc = crc.Value;
                outPutStream.PutNextEntry(entry);
                outPutStream.Write(buffer, 0, buffer.Length);
            }

            this.files.Clear();

            foreach (string emptyPath in paths)
            {
                ZipEntry entry = new ZipEntry(emptyPath.Replace(rootMark, string.Empty) + "/");
                outPutStream.PutNextEntry(entry);
            }

            this.paths.Clear();
            outPutStream.Finish();
            outPutStream.Close();
            GC.Collect();
        }


        /// <summary>  
        /// 解压缩文件(压缩文件中含有子目录)  
        /// </summary>  
        /// <param name="zipfilepath">待解压缩的文件路径</param>  
        /// <param name="unzippath">解压缩到指定目录</param>  
        /// <returns>解压后的文件列表</returns>  
        private List<string> UnZip(string zipfilepath, string unzippath)
        {
            //解压出来的文件列表  
            List<string> unzipFiles = new List<string>();

            //检查输出目录是否以“\\”结尾  
            if (unzippath.EndsWith("\\") == false || unzippath.EndsWith(":\\") == false)
            {
                unzippath += "\\";
            }

            ZipInputStream s = new ZipInputStream(File.OpenRead(zipfilepath));
            ZipEntry theEntry;
            while ((theEntry = s.GetNextEntry()) != null)
            {
                string directoryName = Path.GetDirectoryName(unzippath);
                string fileName = Path.GetFileName(theEntry.Name);

                //生成解压目录【用户解压到硬盘根目录时，不需要创建】  
                if (!string.IsNullOrEmpty(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }

                if (fileName != String.Empty)
                {
                    //如果文件的压缩后大小为0那么说明这个文件是空的,因此不需要进行读出写入  
                    if (theEntry.CompressedSize == 0)
                        continue;
                    //解压文件到指定的目录  
                    directoryName = Path.GetDirectoryName(unzippath + theEntry.Name);
                    //建立下面的目录和子目录  
                    Directory.CreateDirectory(directoryName);

                    //记录导出的文件  
                    unzipFiles.Add(unzippath + theEntry.Name);

                    FileStream streamWriter = File.Create(unzippath + theEntry.Name);

                    int size = 2048;
                    byte[] data = new byte[2048];
                    while (true)
                    {
                        size = s.Read(data, 0, data.Length);
                        if (size > 0)
                        {
                            streamWriter.Write(data, 0, size);
                        }
                        else
                        {
                            break;
                        }
                    }
                    streamWriter.Close();
                }
            }
            s.Close();
            GC.Collect();
            return unzipFiles;
        }

        /// <summary>  
        /// 所有文件缓存  
        /// </summary>  
        List<string> files = new List<string>();

        /// <summary>  
        /// 所有空目录缓存  
        /// </summary>  
        List<string> paths = new List<string>();

        /// <summary>  
        /// 压缩单个文件  
        /// </summary>  
        /// <param name="fileToZip">要压缩的文件</param>  
        /// <param name="zipedFile">压缩后的文件全名</param>  
        /// <param name="compressionLevel">压缩程度，范围0-9，数值越大，压缩程序越高</param>  
        /// <param name="blockSize">分块大小</param>  
        private void ZipFile(string fileToZip, string zipedFile, int compressionLevel, int blockSize)
        {
            if (!System.IO.File.Exists(fileToZip))//如果文件没有找到，则报错  
            {
                throw new FileNotFoundException("The specified file " + fileToZip + " could not be found. Zipping aborderd");
            }

            FileStream streamToZip = new FileStream(fileToZip, FileMode.Open, FileAccess.Read);
            FileStream zipFile = File.Create(zipedFile);
            ZipOutputStream zipStream = new ZipOutputStream(zipFile);
            ZipEntry zipEntry = new ZipEntry(fileToZip);
            zipStream.PutNextEntry(zipEntry);
            zipStream.SetLevel(compressionLevel);
            byte[] buffer = new byte[blockSize];
            int size = streamToZip.Read(buffer, 0, buffer.Length);
            zipStream.Write(buffer, 0, size);

            try
            {
                while (size < streamToZip.Length)
                {
                    int sizeRead = streamToZip.Read(buffer, 0, buffer.Length);
                    zipStream.Write(buffer, 0, sizeRead);
                    size += sizeRead;
                }
            }
            catch (Exception ex)
            {
                GC.Collect();
                throw ex;
            }

            zipStream.Finish();
            zipStream.Close();
            streamToZip.Close();
            GC.Collect();
        }



        /// <summary>  
        /// 取得目录下所有文件及文件夹，分别存入files及paths  
        /// </summary>  
        /// <param name="rootPath">根目录</param>  
        private void GetAllDirectories(string rootPath)
        {
            string[] subPaths = Directory.GetDirectories(rootPath);//得到所有子目录  
            foreach (string path in subPaths)
            {
                GetAllDirectories(path);//对每一个字目录做与根目录相同的操作：即找到子目录并将当前目录的文件名存入List  
            }
            string[] files = Directory.GetFiles(rootPath);
            foreach (string file in files)
            {
                this.files.Add(file);//将当前目录中的所有文件全名存入文件List  
            }
            if (subPaths.Length == files.Length && files.Length == 0)//如果是空目录  
            {
                this.paths.Add(rootPath);//记录空目录  
            }
        }



        private string GetZipFileExtention(string fileFullName)
        {
            int index = fileFullName.LastIndexOf(".");
            if (index <= 0)
            {
                throw new Exception("The source package file is not a compress file");
            }

            //extension string
            string ext = fileFullName.Substring(index);

            if (ext == ".rar" || ext == ".zip")
            {
                return ext;
            }
            else
            {
                throw new Exception("The source package file is not a compress file");
            }
        }
    }
}
