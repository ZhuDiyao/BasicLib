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
    public partial class JXDataSelectBox : Form
    {
        /// <summary>
        /// 用于表示用户的选择
        /// </summary>
        public DataRow 用户选择 = null;
        /// <summary>
        /// 
        /// </summary>
        private DataTable 内存表 = null;

        /// <summary>
        /// 佳轩内容选择盒子
        /// </summary>
        public JXDataSelectBox()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 佳轩内容选择盒子
        /// </summary>
        /// <param name="内容_"></param>
        /// <param name="数据表"></param>
        /// <param name="隐藏列标题"></param>
        public JXDataSelectBox(string 内容_, DataTable 数据表,bool 隐藏列标题)
        {
            InitializeComponent();
            label1.Text = JXPROJECTABOUT.NAME_Chinese;
            dataGridView1.DataSource = 数据表;
            JXStyle.SetDataGridViewSytle(dataGridView1);
            if (隐藏列标题)
            {
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].HeaderText = "";
                }
            }
            //JXStyle.SetDataGridViewStandardStyle(dataGridView1);
            label2.Text = 内容_;
            内存表 = 数据表;
        }


        /// <summary>
        /// 返回用户选择结果
        /// </summary>
        /// <param name="提示内容_"></param>
        /// <param name="数据表_"></param>
        /// <param name="隐藏列标题_"></param>
        /// <returns></returns>
        public static DataRow Show(string 提示内容_, DataTable 数据表_, bool 隐藏列标题_)
        {
            JXDataSelectBox jXMessageBox = new JXDataSelectBox(提示内容_, 数据表_, 隐藏列标题_);
            jXMessageBox.ShowDialog();


            return jXMessageBox.用户选择;
        }


        private void JXDataSelectBox_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            JXMessageBox.Show("请双击对应的行进行选择。");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                用户选择 = 内存表.Rows[e.RowIndex];

            }
            catch
            {
                用户选择 = null;
                JXMessageBox.Show("非正常操作");
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
