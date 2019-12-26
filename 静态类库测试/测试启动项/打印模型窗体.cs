using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 测试启动项
{
    public partial class 打印模型窗体 : Form
    {
        public 打印模型窗体()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);//<<===准备打印内容
            pd.DefaultPageSettings.PaperSize = new PaperSize("myPaper", panel1.Width, panel1.Height);//
            PrintDialog dlgPrint = new PrintDialog();
            pd.PrinterSettings.Copies = short.Parse("1");//份数
            dlgPrint.Document = pd;
            pd.Print();
        }
        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(bmp, new Rectangle(Point.Empty, panel1.Size));
            e.Graphics.DrawImage(bmp, Point.Empty);
        }
    }
}
