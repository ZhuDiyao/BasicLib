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
    public partial class JXSearcherTools : Form
    {
        DataTable DTB = new DataTable();
        /// <summary>
        /// 选择条件的返回值
        /// </summary>
        public static string TextSear = "";
        /// <summary>
        /// 构造方法。返回值请 获取 TextSear
        /// </summary>
        public JXSearcherTools(DataTable DTB_)
        {
            InitializeComponent();
            DTB = DTB_;
        }
        /// <summary>
        /// 调用此方法来显示搜索方法
        /// </summary>
        /// <param name="DTB_"></param>
        public static void Show(DataTable DTB_)
        {
            TextSear = "";
            JXSearcherTools ST = new JXSearcherTools(DTB_);
            ST.ShowDialog();
        }

        private void JXSearcherTools_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            #region 逻辑
            {
                DataGridViewComboBoxColumn Column = new System.Windows.Forms.DataGridViewComboBoxColumn();
                Column.HeaderText = "逻辑";
                Column.Items.Add("并且");
                Column.Items.Add("或者");
                Column.Width = 75;
                dataGridView1.Columns.Add(Column);
            }
            #endregion
            #region （
            {
                DataGridViewComboBoxColumn Column = new System.Windows.Forms.DataGridViewComboBoxColumn();
                Column.HeaderText = "（";
                Column.Items.Add("(");
                Column.Items.Add("((");
                Column.Items.Add("(((");
                Column.Items.Add("((((");
                Column.Items.Add("(((((");
                Column.Items.Add("((((((");
                Column.Width = 75;
                dataGridView1.Columns.Add(Column);
            }
            #endregion
            #region 列名称
            {
                DataGridViewComboBoxColumn Column = new System.Windows.Forms.DataGridViewComboBoxColumn();
                Column.HeaderText = "列名称";
                Column.Width = 120;
                for (int i = 0; i < DTB.Columns.Count; i++)
                {
                    Column.Items.Add(DTB.Columns[i].ColumnName);
                }
                dataGridView1.Columns.Add(Column);
            }
            #endregion
            #region 比较关系
            {
                DataGridViewComboBoxColumn Column = new System.Windows.Forms.DataGridViewComboBoxColumn();
                Column.HeaderText = "比较关系";
                Column.Items.Add("大于");
                Column.Items.Add("小于");
                Column.Items.Add("等于");
                Column.Items.Add("包含");
                Column.Items.Add("不等于");
                Column.Width = 75;
                dataGridView1.Columns.Add(Column);
            }
            #endregion
            #region 数值
            {
                DataGridViewTextBoxColumn Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
                Column.HeaderText = "数值";
                Column.Width = 120;
                dataGridView1.Columns.Add(Column);
            }
            #endregion
            #region )
            {
                DataGridViewComboBoxColumn Column = new System.Windows.Forms.DataGridViewComboBoxColumn();
                Column.HeaderText = "）";
                Column.Items.Add(")");
                Column.Items.Add("))");
                Column.Items.Add(")))");
                Column.Items.Add("))))");
                Column.Items.Add(")))))");
                Column.Items.Add("))))))");
                Column.Width = 75;
                dataGridView1.Columns.Add(Column);
                
            }
            #endregion
            dataGridView1.Rows[0].Cells[0].ReadOnly = true;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        string DataRowToStr(DataRow dataRow)
        {
            string ReturnStr = "";
            string 逻辑 = dataRow["Column1"].ToString();
            string 左括号 = dataRow["Column2"].ToString();
            string 列名称 = dataRow["Column3"].ToString();
            string 条件 = dataRow["Column4"].ToString();
            string 值 = dataRow["Column5"].ToString();
            string 右括号 = dataRow["Column6"].ToString();

            if (逻辑.Equals("并且"))
            {
                逻辑 = "and";
            }
            if (逻辑.Equals("或者"))
            {
                逻辑 = "or";
            }

            switch (条件)
            {
                case "大于":
                    {
                        ReturnStr = 逻辑 + " " + 左括号 + "[" + 列名称 + "]" + " > " + "'" + 值 + "'" + 右括号 + " ";
                    }
                    break;
                case "小于":
                    {
                        ReturnStr = 逻辑 + " " + 左括号 + "[" + 列名称 + "]" + " < " + "'" + 值 + "'" + 右括号 + " ";
                    }
                    break;
                case "等于":
                    {
                        ReturnStr = 逻辑 + " " + 左括号 + "[" + 列名称 + "]" + " = " + "'" + 值 + "'" + 右括号 + " ";
                    }
                    break;
                case "包含":
                    {
                        ReturnStr = 逻辑 + " " + 左括号 + "[" + 列名称 + "]" + " like " + "'%" + 值 + "%'" + 右括号 + " ";
                    }
                    break;
                case "不等于":
                    {
                        ReturnStr = 逻辑 + " " + 左括号 + "[" + 列名称 + "]" + " <> " + "'" + 值 + "'" + 右括号 + " ";
                    }
                    break;
            }
            return ReturnStr;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DataTable SearDtb = JXDataTableUtil.GetDgvToTable(dataGridView1);
            string STRINGSTR = "";
            for(int i = 0; i < SearDtb.Rows.Count; i++)
            {
                string str = DataRowToStr(SearDtb.Rows[i]);
                STRINGSTR = STRINGSTR + str + "\r\n";
            }
            TextSear = STRINGSTR;
            ;
            try
            {
                DataRow[] dtr = DTB.Select(STRINGSTR);
                JXMessageBox.Show("语法检查通过");
            }
            catch(Exception ex)
            {
                JXMessageBox.Show("语法检查错误"+ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            JXFileUtil.StringToFile(
                JXFastPath.GetDeskFilePath("查询模板"+DateTime.Now.ToString("yyyyMMddHHmmssfff")+ ".JXSear")
                ,
                JXDataTableUtil.DataTableToJson(JXDataTableUtil.GetDgvToTable(dataGridView1)));
            JXMessageBox.Show("已导出到桌面");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.InitialDirectory = JXFastPath.GetDeskFilePath("");
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = dialog.FileName;
                string filestr = JXFileUtil.FileToString(file);
                DataTable dtb = JXDataTableUtil.JsonToDataTable(filestr);
                for(int i = 0; i < dtb.Rows.Count; i++)
                {
                    int index = dataGridView1.Rows.Add();
                    for(int j = 0; j < 6; j++)
                    {
                        dataGridView1.Rows[index].Cells[j].Value = dtb.Rows[i][j].ToString();
                    }
                }
            }

            
        }
        bool 关闭原因指示器 = false;
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable SearDtb = JXDataTableUtil.GetDgvToTable(dataGridView1);
            string STRINGSTR = "";
            for (int i = 0; i < SearDtb.Rows.Count; i++)
            {
                string str = DataRowToStr(SearDtb.Rows[i]);
                STRINGSTR = STRINGSTR + str + "\r\n";
            }
            TextSear = STRINGSTR;
            ;
            try
            {
                DataRow[] dtr = DTB.Select(STRINGSTR);
                关闭原因指示器 = true;
                Close();
            }
            catch (Exception ex)
            {
                JXMessageBox.Show("语法检查错误" + ex.ToString());
            }
        }

        private void JXSearcherTools_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!关闭原因指示器)
            TextSear = "";
        }
    }
}
