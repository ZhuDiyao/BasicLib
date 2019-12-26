using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JX_StandardMethod_WMS
{
    /// <summary>
    /// 佳轩图片类库
    /// </summary>
    public class JXImageUtil
    {
        public static void 压缩图片()
        {
            //FileStream fs = new FileStream(@"C:\Users\ZhuDiyao\Desktop\a.bmp", FileMode.Open);
            //Bitmap img1 = new Bitmap(fs);
            //fs.Close();

            //Bitmap imgx = ChangeSize_KeepProportion(img1,0.2);
            //imgx.Save(@"C:\Users\ZhuDiyao\Desktop\b.bmp", ImageFormat.Bmp);
            //imgx = ChangeSize(img1, 300, 300);
            //imgx.Save(@"C:\Users\ZhuDiyao\Desktop\c.bmp", ImageFormat.Bmp);
            //imgx = AddTextToImg(img1, "aaaaaaa");
            //imgx = ChangeSize_KeepProportion(imgx, 0.2);
            //imgx = AddTextToImg(imgx, "VVVVV");
            //imgx.Save(@"C:\Users\ZhuDiyao\Desktop\d.bmp", ImageFormat.Bmp);

            string BASICPATH = @"C:\Users\ZhuDiyao\Desktop\";

            Bitmap 读取图片 = ReadImg(BASICPATH + @"a.bmp");

            Bitmap 等比缩小图片 = ChangeSize_KeepProportion(读取图片, 0.2);
            Bitmap 设置尺寸图片 = ChangeSize(读取图片,800,800);
            Bitmap 加字图片 = AddTextToImg(读取图片, "加字");

            PrintImg(等比缩小图片, BASICPATH + "等比缩小图片.bmp");
            PrintImg(设置尺寸图片, BASICPATH + "设置尺寸图片.bmp");
            PrintImg(加字图片, BASICPATH + "加字图片.bmp");

        }
        /// <summary>
        /// 读取指定路径下的图片文件
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static Bitmap ReadImg(string Path)
        {
            try
            {
                File.Copy(Path, Path + ".wmstemp");
                FileStream fs = new FileStream(Path + ".wmstemp", FileMode.Open);
                Bitmap img1 = new Bitmap(fs);
                fs.Close();
                File.Delete(Path + ".wmstemp");
                return img1;
            }
            catch
            {
                try
                {
                    File.Delete(Path + ".wmstemp");
                }
                catch
                {

                }
            }
            return null;
        }
        /// <summary>
        /// 将图片输出到文件
        /// </summary>
        /// <param name="img"></param>
        /// <param name="path"></param>
        public static void PrintImg(Bitmap img,string path)
        {
            img.Save(path, ImageFormat.Bmp);
        }
        /// <summary>
        /// 等比例放大或者缩小图片
        /// </summary>
        /// <param name="SourceImg"></param>
        /// <param name="Proportion">以1为基准，表示100%（原图）等比例放大或者缩小图片</param>
        /// <returns></returns>
        public static Bitmap ChangeSize_KeepProportion(Bitmap SourceImg,double Proportion)
        {
            int Width = (int)(SourceImg.Width * Proportion);
            int Height = (int)(SourceImg.Height * Proportion);
            Bitmap img2 = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
            img2.SetResolution(900.0F, 900.0F);
            using (Graphics g = Graphics.FromImage(img2))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(SourceImg, new Rectangle(0, 0, img2.Width, img2.Height), 0, 0, SourceImg.Width, SourceImg.Height, GraphicsUnit.Pixel);
                g.Dispose();                
            }
            return img2;
        }
        /// <summary>
        /// 通过拉伸，直接更改图片尺寸
        /// </summary>
        /// <param name="SourceImg"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <returns></returns>
        public static Bitmap ChangeSize(Bitmap SourceImg, int Width,int Height)
        {
            Bitmap img2 = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
            img2.SetResolution(900.0F, 900.0F);
            using (Graphics g = Graphics.FromImage(img2))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(SourceImg, new Rectangle(0, 0, img2.Width, img2.Height), 0, 0, SourceImg.Width, SourceImg.Height, GraphicsUnit.Pixel);
                g.Dispose();
            }
            return img2;
        }
        /// <summary>
        /// 为图片添加文本描述，此方法仅表示一个示例。
        /// </summary>
        /// <param name="SourceImg"></param>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static Bitmap AddTextToImg(Bitmap SourceImg, string Text)
        {
            Bitmap bitmap = SourceImg;
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
            //字体大小
            float fontSize = 40.0f;
            //下面定义一个矩形区域，以后在这个矩形里画上白底黑字
            float rectX = 0;
            float rectY = 0;
            float rectWidth = SourceImg.Width;
            float rectHeight = SourceImg.Height;
            //声明矩形域
            RectangleF textArea = new RectangleF(rectX, rectY, rectWidth, rectHeight);
            //定义字体
            Font font = new Font("微软雅黑", fontSize, System.Drawing.FontStyle.Bold);
            //白笔刷，画文字用
            Brush whiteBrush = new SolidBrush(System.Drawing.Color.DodgerBlue);
            //黑笔刷，画背景用
            //Brush blackBrush = new SolidBrush(Color.Black);   
            g.DrawString(Text, font, whiteBrush, textArea);
            return bitmap;
        }

        /// <summary>
        /// 为图片添加文本描述，此方法仅表示一个示例。
        /// </summary>
        /// <param name="SourceImg"></param>
        /// <param name="Text"></param>
        /// <param name="字体大小"></param>
        /// <param name="字体颜色"></param>
        /// <returns></returns>
        public static Bitmap AddTextToImg(Bitmap SourceImg, string Text,float 字体大小, Color 字体颜色)
        {
            Bitmap bitmap = SourceImg;
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
            //字体大小
            float fontSize = 40.0f;
            fontSize = 字体大小;
            //下面定义一个矩形区域，以后在这个矩形里画上白底黑字
            float rectX = 0;
            float rectY = 0;
            float rectWidth = SourceImg.Width;
            float rectHeight = SourceImg.Height;
            //声明矩形域
            RectangleF textArea = new RectangleF(rectX, rectY, rectWidth, rectHeight);
            //定义字体
            Font font = new Font("微软雅黑", fontSize, System.Drawing.FontStyle.Bold);
            //白笔刷，画文字用
            Brush whiteBrush = new SolidBrush(字体颜色);
            //黑笔刷，画背景用
            //Brush blackBrush = new SolidBrush(Color.Black);   
            g.DrawString(Text, font, whiteBrush, textArea);
            return bitmap;
        }
    }
}
