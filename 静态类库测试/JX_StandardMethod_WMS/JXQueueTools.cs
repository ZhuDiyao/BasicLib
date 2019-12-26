using JX_StandardLibrary_WMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JX_StandardMethod_WMS
{
    /// <summary>
    /// 佳轩列队搜索器
    /// </summary>
    public partial class JXQueueTools : Form
    {
        /// <summary>
        /// 用来计数，保证此窗口同一时间仅有一个被打开。如果值为0，证明窗口被关闭。
        /// </summary>
        public static int 窗口总打开数 = 0;
        /// <summary>
        /// 用于外部窗体获取当前内容
        /// </summary>
        public static string 已发射内容 = "";

        /// <summary>
        /// 构造方法,请不要调用此方法进行构造。
        /// </summary>
        public JXQueueTools(string buttonName)
        {
            InitializeComponent();
            button1.Text = buttonName;

        }
        /// <summary>
        /// 使用此窗口，一般而言，您需要做以下事情
        /// 0、定义一个 上一次接收到的已发射内容 的变量
        /// 1、开启一个计时器，在计时器中检查  JXQueueTools.窗口总打开数  是否等于0，如果是，则关闭计时器
        /// 2、开启一个计时器，在计时器中检查  JXQueueTools.已发射内容  是否与上一次相同，如果不是，则进行填充
        /// </summary>
        /// <param name="ButtonName"></param>
        public static void Show(string ButtonName)
        {
            if (窗口总打开数 == 0)
            {
                窗口总打开数++;
                JXQueueTools jXQueueTools = new JXQueueTools(ButtonName);
                jXQueueTools.Show();
            }
            else
            {
                JXMessageBox.Show("排队搜索器只允许被打开一个");
            }
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                已发射内容 = textBox1.Text;
                textBox1.Text = textBox2.Text.Substring(0, textBox2.Text.IndexOf("\r\n"));
                textBox2.Text = textBox2.Text.Substring(textBox2.Text.IndexOf("\r\n") + 2, textBox2.Text.Length - textBox1.Text.Length - 2);
            }
            catch
            {
                JXMessageBox.Show("发射失败，请补充内容！");
            }
        }

        private void JXQueueTools_FormClosing(object sender, FormClosingEventArgs e)
        {
            窗口总打开数 = 0;
        }

        private void JXQueueTools_Load(object sender, EventArgs e)
        {

        }
    }
}
