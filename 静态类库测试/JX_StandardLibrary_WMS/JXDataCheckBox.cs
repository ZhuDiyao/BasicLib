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
    public partial class JXDataCheckBox : Form
    {
        /// <summary>
        /// 用于表示用户的选择
        /// </summary>
        public bool 用户选择 = false;
        /// <summary>
        /// 佳轩消息确认盒子
        /// </summary>
        public JXDataCheckBox()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 传入消息内容进行构造
        /// 成员变量：【用户选择】是表示用户选择了什么，确认：true。取消：false。
        /// </summary>
        /// <param name="内容_"></param>
        /// <param name="数据表"></param>
        public JXDataCheckBox(string 内容_,DataTable 数据表)
        {
            InitializeComponent();
            label1.Text = JXPROJECTABOUT.NAME_Chinese;
            dataGridView1.DataSource = 数据表;
            JXStyle.SetDataGridViewStandardStyle(dataGridView1);
            label2.Text = 内容_;
        }
        /// <summary>
        /// 确认：true。取消：false。
        /// </summary>
        /// <param name="提示内容_"></param>
        public static bool Show(string 提示内容_, DataTable 数据表_)
        {
            JXDataCheckBox jXMessageBox = new JXDataCheckBox(提示内容_,数据表_);
            jXMessageBox.ShowDialog();
            return jXMessageBox.用户选择;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            用户选择 = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void JXDataCheckBox_Load(object sender, EventArgs e)
        {

        }
    }
}
