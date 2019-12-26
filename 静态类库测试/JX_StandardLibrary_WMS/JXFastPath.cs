using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JX_StandardLibrary_WMS
{
    /// <summary>
    /// 快捷路径获取方式
    /// </summary>
    public class JXFastPath
    {
        /// <summary>
        /// 获取桌面文件的路径，传入桌面的文件名，返回这个文件的完整路径。
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static string GetDeskFilePath(string FileName)
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + FileName;
        }

        /// <summary>
        /// 调用此方法，会弹出一个文件选择窗口
        /// 让用户选择表格文件
        /// 若用户进行了选择，就返回 文件全路径
        /// 如果用户没有选择，则返回 null
        /// </summary>
        /// <returns></returns>
        public static string ChooseExcelPath(string describe)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = JXFastPath.GetDeskFilePath("");
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = describe;
            dialog.Filter = "请选择表格|*.xls;*.xlsx";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return dialog.FileName;
            }
            return null;
        }

        /// <summary>
        /// 调用此方法，会弹出一个文件选择窗口
        /// 让用户选择文件
        /// 若用户进行了选择，就返回 文件全路径
        /// 如果用户没有选择，则返回 null
        /// </summary>
        /// <returns></returns>
        public static string ChooseExcelPath(string describe,string 指定文件后缀)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = JXFastPath.GetDeskFilePath("");
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = describe;
            dialog.Filter = "请选择|*."+ 指定文件后缀;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return dialog.FileName;
            }
            return null;
        }
    }
}
