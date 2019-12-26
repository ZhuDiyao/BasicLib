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
    /// 佳轩文本输入工具
    /// </summary>
    public partial class JXTextBoxTools : Form
    {
        /// <summary>
        /// 文本输入工具空构造方法
        /// </summary>
        public JXTextBoxTools()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 根据标题和文本进行构造
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="txt"></param>
        public JXTextBoxTools(string Title, string txt)
        {
            InitializeComponent();
            标题 = Title;
            文本 = txt;
        }
        /// <summary>
        /// 根据标题和文本进行构造
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="txt"></param>
        public JXTextBoxTools(string Title, string txt,bool password)
        {
            InitializeComponent();
            标题 = Title;
            文本 = txt;
            if (password)
            {
                textBox1.PasswordChar = '*';
            }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string 标题 = "";
        /// <summary>
        /// 文本
        /// </summary>
        public string 文本 = "";
        private void JXTextBoxTools_Load(object sender, EventArgs e)
        {
            Text = 标题;
            textBox1.Text = 文本;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            文本 = textBox1.Text;
        }
    }
}
