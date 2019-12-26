using System;

using System.Windows.Forms;

namespace JX_StandardLibrary_WMS
{
    /// <summary>
    /// 提示消息的盒子
    /// </summary>
    public partial class JXMessageBox : Form
    {
        /// <summary>
        /// 用于指示消息盒子当前是否已经处在弹出状态。
        /// </summary>
        private static bool flag = false;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="倒计时值_"></param>
        /// <param name="标题内容_"></param>
        /// <param name="提示内容_"></param>
        public JXMessageBox(int 倒计时值_, string 标题内容_, string 提示内容_)
        {
            InitializeComponent();

            Number = 倒计时值_;
            button1.Text = "我已知晓（" + (Number+1) + "）";
            label1.Text = 标题内容_;
            label2.Text = 提示内容_;

            if (label2.Text.Length > 200)
            {
                this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
        }
        /// <summary>
        /// 推荐使用的提示。
        /// </summary>
        /// <param name="提示内容_"></param>
        public static void Show(string 提示内容_)
        {
            Show(15, JXPROJECTABOUT.NAME_Chinese, 提示内容_);
        }
        /// <summary>
        /// 一般使用一个参数的。标题一般不需要修改。
        /// </summary>
        /// <param name="标题内容_"></param>
        /// <param name="提示内容_"></param>
        public static void Show(string 标题内容_,string 提示内容_)
        {
            Show(15, 标题内容_, 提示内容_);
        }
        private static void Show(int 倒计时值_, string 标题内容_, string 提示内容_)
        {
            if (flag)
            {
                //如果 消息盒子 当前处在弹出状态，那么什么都不做
            }
            else
            {
                //将 消息盒子 标记为 弹出状态
                flag = true;
                JXMessageBox jXMessageBox = new JXMessageBox(倒计时值_, 标题内容_, 提示内容_);
                jXMessageBox.ShowDialog();
                //将消息盒子标记为 非弹出状态
                flag = false;
            }
        }
        private void JXMessageBox_Load(object sender, EventArgs e)
        {

        }
        int Number = 0;
        string Tip = "";
        private void button1_Click(object sender, EventArgs e)
        {
            //flag = false;
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TopMost = true;
            button1.Text = "我已知晓（"+Number+"）"+ Tip;
            if (Number <= 0)
            {
                //flag = false;
                Close();
            }
            Number--;


            if(label2.Visible == false)
            {
                timer1.Interval = 10000;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(label2.Text, true);
                Tip = "内容已复制";
            }
            catch
            {
                Tip = "复制失败,请手动操作。";
                textBox1.Text = label2.Text;
                textBox1.Visible = true;
                label2.Visible = false;
                //timer1.Interval = 10000;
            }
            
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            timer1.Interval = 200;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            timer1.Interval = 10000;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
