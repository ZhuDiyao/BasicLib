using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JX_StandardMethod_WMS
{
    /// <summary>
    /// 打印工具类
    /// </summary>
    public class JXPrintUtil
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public JXPrintUtil()
        {
            this.docToPrint.PrintPage += new PrintPageEventHandler(docToPrint_PrintPage);
        }
        //将事件处理函数添加到PrintDocument的PrintPage中
        // Declare the PrintDocument object.
        private System.Drawing.Printing.PrintDocument docToPrint =
        new System.Drawing.Printing.PrintDocument();//创建一个PrintDocument的实例
        private string streamType;
        private string streamtxt;
        private Image streamima;

        /// <summary>
        /// 打印文本类型
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="streamType"></param>
        public void StartPrint(string txt, string streamType)
        {
            this.streamType = streamType;
            this.streamtxt = txt;
            // Allow the user to choose the page range he or she would
            // like to print.
            System.Windows.Forms.PrintDialog PrintDialog1 = new PrintDialog();//创建一个PrintDialog的实例。
            PrintDialog1.AllowSomePages = true;

            // Show the help button.
            PrintDialog1.ShowHelp = true;

            // Set the Document property to the PrintDocument for 
            // which the PrintPage Event has been handled. To display the
            // dialog, either this property or the PrinterSettings property 
            // must be set 
            PrintDialog1.Document = docToPrint;//把PrintDialog的Document属性设为上面配置好的PrintDocument的实例

            DialogResult result = PrintDialog1.ShowDialog();//调用PrintDialog的ShowDialog函数显示打印对话框,如果不要注释即可，直接调用docToPrint.Print()
            // If the result is OK then print the document.
            if (result == DialogResult.OK)
            {
                docToPrint.Print();//开始打印
            }
        }
        /// <summary>
        /// 打印图片类型
        /// </summary>
        /// <param name="ima"></param>
        /// <param name="streamType"></param>
        public void StartPrint(Image ima, string streamType)
        {
            this.streamType = streamType;
            this.streamima = ima;
            System.Windows.Forms.PrintDialog PrintDialog1 = new PrintDialog();//创建一个PrintDialog的实例。
            PrintDialog1.AllowSomePages = true;
            PrintDialog1.ShowHelp = true;
            PrintDialog1.Document = docToPrint;
            //DialogResult result = PrintDialog1.ShowDialog();//调用PrintDialog的ShowDialog函数显示打印对话框,如果不要注释即可，直接调用docToPrint.Print()
            //if (result == DialogResult.OK)
            {
                docToPrint.Print();//开始打印
            }
        }
        // The PrintDialog will print the document
        // by handling the document's PrintPage event.
        private void docToPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)//设置打印机开始打印的事件处理函数
        {
            switch (this.streamType)
            {
                case "txt":
                    {
                        string text = null;
                        System.Drawing.Font printFont = new System.Drawing.Font
                         ("Arial", 35, System.Drawing.FontStyle.Regular);
                        text = streamtxt;
                        e.Graphics.DrawString(text, printFont, System.Drawing.Brushes.Black, e.MarginBounds.X, e.MarginBounds.Y);
                        break;
                    }
                case "image":
                    {
                        System.Drawing.Image image = streamima;
                        //此处写 -150 是为了让外框向外偏移，从而打印整张纸。
                        int x = e.MarginBounds.X - 150;
                        int y = e.MarginBounds.Y - 150;
                        int width = image.Width;
                        int height = image.Height;
                        System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(x, y, width, height);
                        e.Graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, System.Drawing.GraphicsUnit.Pixel);
                        break;
                    }
                case "image_90":
                    {
                        System.Drawing.Image image = streamima;
                        //此处写 -150 是为了让外框向外偏移，从而打印整张纸。
                        int x = e.MarginBounds.X - 150;
                        int y = e.MarginBounds.Y - 150;
                        int width = image.Width;
                        int height = image.Height;
                        Rectangle destRect = new Rectangle(x, y, width, height);
                        e.Graphics.TranslateTransform(0, width);
                        e.Graphics.RotateTransform(-90.0F);
                        e.Graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, System.Drawing.GraphicsUnit.Pixel);
                        //e.Graphics.RotateTransform(-90.0F);
                        break;
                    }
                default:
                    break;
            }

        }
    }
}
