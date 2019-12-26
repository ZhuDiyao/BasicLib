using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using JX_StandardMethod_WMS;

namespace JX_TCPIPDataProtocol
{
    /// <summary>
    /// 在正常项目中禁止调用此类下面的任何方法。诸迪耀201911151354
    /// 图片交互协议
    /// </summary>
    public class JXImageProtocol
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static byte[] ImgToByteArr(Bitmap bmp)
        {
            string FileName = "JXImageFile" + JXCryptography.GetSystemUniqueCode_Simple("");
            string Path = "SendImage\\"+ FileName;
            JXFilePathUtil.CheckPath(Path);

            JXImageUtil.PrintImg(bmp, Path);
            byte[] barr = JXFileUtil.FileToByteArray(Path);
            return barr;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytearr"></param>
        /// <returns></returns>
        public static Bitmap ByteArrToImage(byte[] bytearr)
        {
            string FileName = "JXImageFile" + JXCryptography.GetSystemUniqueCode_Simple("");
            string Path = "Receive\\" + FileName;
            JXFilePathUtil.CheckPath(Path);

            JXFileUtil.ByteArrayToFile(Path, bytearr);
            Bitmap bitmap = JXImageUtil.ReadImg(Path);
            return bitmap;
        }

        /// <summary>
        /// 获取桌面当前截图
        /// </summary>
        /// <returns></returns>
        public static Bitmap GetDesktopImage()
        {
            PlatFormInvokeUSER32.SIZE size;

            IntPtr hBitmap;   // 图像

            //user32中的GetDesktopWindow方法
            IntPtr hDC = PlatFormInvokeUSER32.GetDC(PlatFormInvokeUSER32.GetDesktopWindow());

            //GDI32中的CreateCompatibleDC方法
            IntPtr hMenDC = PlatFormInvokeGDI32.CreateCompatibleDC(hDC);

            size.cx = PlatFormInvokeUSER32.GetSystemMetrics(PlatFormInvokeUSER32.SM_CXSCREEN); //宽度
            size.cy = PlatFormInvokeUSER32.GetSystemMetrics(PlatFormInvokeUSER32.SM_CYSCREEN); //长度
            //创建图像
            hBitmap = PlatFormInvokeGDI32.CreateCompatibleBitmap(hDC, size.cx, size.cy);

            //截屏处理
            if (hBitmap != IntPtr.Zero)
            {
                IntPtr hOld = (IntPtr)PlatFormInvokeGDI32.SelectObject(hMenDC, hBitmap);

                PlatFormInvokeGDI32.BitBlt(hMenDC, 0, 0, size.cx, size.cy, hDC, 0, 0, PlatFormInvokeGDI32.SRCCOPY);
                PlatFormInvokeGDI32.SelectObject(hMenDC, hOld);
                PlatFormInvokeGDI32.DeleteDC(hMenDC);
                PlatFormInvokeUSER32.ReleaseDC(PlatFormInvokeUSER32.GetDesktopWindow(), hDC);

                Bitmap bmp = Image.FromHbitmap(hBitmap);
                PlatFormInvokeGDI32.DeleteObject(hBitmap);

                GC.Collect();

                return bmp; //返回图像
            }

            return null;
        }

    }
}
