using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JX_StandardLibrary_WMS
{
    public partial class JXMessageCheckBox : Form
    {
        /// <summary>
        /// 用于表示用户的选择
        /// </summary>
        public bool 用户选择 = false;
        /// <summary>
        /// 佳轩消息确认盒子
        /// </summary>
        public JXMessageCheckBox()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 传入消息内容进行构造
        /// 成员变量：【用户选择】是表示用户选择了什么，确认：true。取消：false。
        /// </summary>
        /// <param name="内容_"></param>
        public JXMessageCheckBox(string 内容_)
        {
            InitializeComponent();
            label1.Text = JXPROJECTABOUT.NAME_Chinese;
            label2.Text = 内容_;
        }
        /// <summary>
        /// 确认：true。取消：false。
        /// </summary>
        /// <param name="提示内容_"></param>
        public static bool Show(string 提示内容_)
        {
            JXMessageCheckBox jXMessageBox = new JXMessageCheckBox(提示内容_);
            jXMessageBox.ShowDialog();
            return jXMessageBox.用户选择;
        }
        /// <summary>
        /// 展示消息内容的方法
        /// </summary>
        private static void Show(string 标题,string 内容)
        {

        }
        private void JXMessageCheckBox_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            用户选择 = true;
            Close();
        }
    }
}
