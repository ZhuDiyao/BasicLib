using JX_StandardMethod_WMS;
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
    public partial class 打印模型测试窗体 : Form
    {
        public 打印模型测试窗体()
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
        void FromInit()
        {
            textBox1.Text = panel1.Width + "";
            textBox2.Text = panel1.Height + "";
            textBox4.Text = panel2.Width + "";
            textBox3.Text = panel2.Height + "";
            textBox6.Text = panel2.Left + "";
            textBox5.Text = panel2.Top + "";

            LabelMoveToTruePoint();
        }
        void LabelMoveToTruePoint()
        {
            label1.Location = new Point(0, 0);
            label2.Location = new Point(panel1.Width - label2.Width - 2, 0);
            label3.Location = new Point(0, panel1.Height - label3.Height - 2);
            label4.Location = new Point(panel1.Width - label4.Width - 2, panel1.Height - label4.Height - 2);

            label5.Location = new Point(0, 0);
            label6.Location = new Point(panel2.Width - label6.Width - 2, 0);
            label7.Location = new Point(0, panel2.Height - label7.Height - 2);
            label8.Location = new Point(panel2.Width - label8.Width - 2, panel2.Height - label8.Height - 2);
        }
        string 打印模式 = "未选择打印模式";
        void TextBoxShowToFrom()
        {
            try
            {
                panel1.Width = int.Parse(textBox1.Text);
                panel1.Height = int.Parse(textBox2.Text);

                panel2.Width = int.Parse(textBox4.Text);
                panel2.Height = int.Parse(textBox3.Text);

                panel2.Location = new Point(int.Parse(textBox6.Text), int.Parse(textBox5.Text));
                LabelMoveToTruePoint();

                label16.Text =
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"\r\n"+
                      "外框宽度：" + textBox1.Text + "\r\n"
                    + "外框高度：" + textBox2.Text + "\r\n"

                    + "内框宽度：" + textBox4.Text + "\r\n"
                    + "内框高度：" + textBox3.Text + "\r\n"

                    + "内框横坐标：" + textBox6.Text + "\r\n"
                    + "内框纵坐标：" + textBox5.Text + "\r\n"

                    + "打印模式：" + 打印模式 + "\r\n"


                    ;
            }
            catch
            {
                label15.Text = label15.Text + "。";
            }
        }
        void TextBoxAdd(TextBox tb, int x)
        {
            int xxx = 0;
            try
            {
                xxx = int.Parse(tb.Text);
            }
            catch
            {

            }
            xxx = xxx + x;
            tb.Text = xxx + "";
            TextBoxShowToFrom();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBoxAdd(textBox1, 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextBoxAdd(textBox1, -1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TextBoxAdd(textBox2, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TextBoxAdd(textBox2, -1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TextBoxAdd(textBox4, 1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TextBoxAdd(textBox4, -1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TextBoxAdd(textBox3, 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TextBoxAdd(textBox3, -1);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            TextBoxAdd(textBox6, 1);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            TextBoxAdd(textBox6, -1);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            TextBoxAdd(textBox5, 1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            TextBoxAdd(textBox5, -1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBoxShowToFrom();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextBoxShowToFrom();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            TextBoxShowToFrom();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            TextBoxShowToFrom();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            TextBoxShowToFrom();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            TextBoxShowToFrom();
        }
        private void 打印模型测试窗体_Load(object sender, EventArgs e)
        {

        }
        public void Print(Bitmap bmp)
        {
            JXPrintUtil ps = new JXPrintUtil();
            //ps.StartPrint("33333", "txt");//打印文字
            ps.StartPrint(bmp, "image");//打印图片
        }
        public void Print_90(Bitmap bmp)
        {
            JXPrintUtil ps = new JXPrintUtil();
            //ps.StartPrint("33333", "txt");//打印文字
            ps.StartPrint(bmp, "image_90");//打印图片
        }
        private void button14_Click(object sender, EventArgs e)
        {
            打印模式 = "纵向打印";
            TextBoxShowToFrom();
            Bitmap bmp = new Bitmap(panel1.Width, panel1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            panel1.DrawToBitmap(bmp, new Rectangle(0, 0, panel1.Width, panel1.Height));
            //bmp.Save("led.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            Print(bmp);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TextBoxShowToFrom();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            打印模式 = "横向打印";
            TextBoxShowToFrom();
            Bitmap bmp = new Bitmap(panel1.Width, panel1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            panel1.DrawToBitmap(bmp, new Rectangle(0, 0, panel1.Width, panel1.Height));
            //bmp.Save("led.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            Print_90(bmp);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = "1137";
            textBox2.Text = "850";
            textBox4.Text = "1086";
            textBox3.Text = "790";
            textBox6.Text = "51";
            textBox5.Text = "51";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = "1490";
            textBox2.Text = "2150";
            textBox4.Text = "790";
            textBox3.Text = "1133";
            textBox6.Text = "51";
            textBox5.Text = "51";
        }
    }
}
