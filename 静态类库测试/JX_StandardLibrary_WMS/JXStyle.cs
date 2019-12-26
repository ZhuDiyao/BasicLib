using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JX_StandardLibrary_WMS
{
    /// <summary>
    /// 项目中的样式标准，尽可能使用此处的样式。
    /// </summary>
    public class JXStyle
    {
        /// <summary>
        /// 一般用于标题的颜色
        /// </summary>
        public static Color Color_Title = Color.FromArgb(255,128,255,255);
        /// <summary>
        /// 一般代表好的正确的
        /// </summary>
        public static Color Color_Good = ColorTranslator.FromHtml("#33ffcc");
        /// <summary>
        /// 一般代表坏的错误的
        /// </summary>
        public static Color Color_Bad = ColorTranslator.FromHtml("#FFFF00");
        /// <summary>
        /// 一般代表超级坏的超级错误的（比错的级别更高的错的颜色）
        /// </summary>
        public static Color Color_SupperBad = ColorTranslator.FromHtml("#ff0000");

        /// <summary>
        /// 佳轩WMS 内存表 展示的默认样式
        /// 方法创建时间：2019-08-21
        /// </summary>
        /// <param name="dgv"></param>
        public static void SetDataGridViewStandardStyle(DataGridView dgv)
        {
            //规定表头高度为50px
            dgv.ColumnHeadersHeight = 50;
            //规定用户可以自由调整列宽度
            dgv.AllowUserToResizeColumns = true;
            //规定用户不能自由调整表头列高度
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //规定当标题太长,自动进行换行
            dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //规定表格只读,不允许用户对数据进行任何修改
            dgv.ReadOnly = true;
            //规定表格不显示最后一个空行
            dgv.AllowUserToAddRows = false;
            //规定表格的字体
            dgv.RowsDefaultCellStyle.Font = new Font("宋体", 12, FontStyle.Regular);
            //规定表格中单元格的背景色
            dgv.RowsDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
            //规定表格中奇数行的单元格的背景色
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.Wheat;
            //设置行标题的列宽度
            dgv.RowHeadersWidth = 90;
            //设置行标题的列的列名称
            dgv.TopLeftHeaderCell.Value = " 序号";

            int rowNumber = 1;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = rowNumber.ToString();
                //row.HeaderCell.Style = DataGridViewCellStyle.MiddleCenter;
                rowNumber++;
            }
        }
        /// <summary>
        /// 为正常的表赋样式。
        /// 仅适用于数据量非常少的表。
        /// 列一般要求小于6列。
        /// 单个单元格数据内容少于20个字符。
        /// </summary>
        /// <param name="dgv"></param>
        public static void SetDataGridViewSytle(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = false;
            //表头内容居中
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                //自动列宽
                dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //设置所有列内容居中
                dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            #region 列标题字体设置
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.ForeColor = Color.Red;
            style.Font = new Font("隶书", 15, FontStyle.Bold);
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.HeaderCell.Style = style;
            }
            dgv.EnableHeadersVisualStyles = false;
            #endregion
            #region 行内容字体设置
            dgv.RowsDefaultCellStyle.Font = new Font("宋体", 12, FontStyle.Underline);
            #endregion
            RefuseSort(dgv);
        }
        /// <summary>
        /// 设置DGV不能点击列头部排序.
        /// 请注意，先保证dgv中有数据。
        /// 如果对空的DGV进行设置，然后再填入数据，这样操作是无效的。
        /// </summary>
        /// <param name="dg"></param>
        public static void RefuseSort(DataGridView dg)
        {
            for (int i = 0; i < dg.Columns.Count; i++)
            {
                //禁止点击列头排序
                dg.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        /// <summary>
        /// 佳轩WMS 内存表 展示的默认样式。【不建议使用201910251505诸迪耀】【建议使用SetDataGridViewStandardStyle】
        /// 方法创建时间：项目开始
        /// </summary>
        /// <param name="dg"></param>
        public static void SetGridAlternatingRows(DataGridView dg)
        {
            if (dg != null)
            {
                dg.RowsDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
                dg.AlternatingRowsDefaultCellStyle.BackColor = Color.Wheat;
            }
            dg.RowsDefaultCellStyle.Font = new Font("宋体", 12, FontStyle.Regular);
            dg.RowHeadersWidth = 70;
            dg.AllowUserToAddRows = false;
            dg.TopLeftHeaderCell.Value = " 序号";
        }
        /// <summary>
        /// 为DGV设置一行一行的选择模式。
        /// 修改：2019年06月19日，取消行选择模式。
        /// </summary>
        /// <param name="dg"></param>
        public static void FullRowSelectMode(DataGridView dg)
        {

            //try
            //{
            //    if (dg != null)
            //        dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //}
            //catch {
            //}
        }
        /// <summary>
        /// 为dgv设置表头的高度，并且不可调整。默认值为50
        /// 并且
        /// 不可以自由拖动列标题
        /// </summary>
        /// <param name="dg"></param>
        public static void DGVHeadHeight(DataGridView dg)
        {
            dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dg.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dg.ColumnHeadersHeight = 50;
            dg.AllowUserToResizeColumns = false;
            //dg.AllowUserToOrderColumns = true;
        }
        /// <summary>
        /// 为DGV设置只读，不可修改
        /// </summary>
        /// <param name="dg"></param>
        public static void SetReadOnly(DataGridView dg)
        {
            dg.ReadOnly = true;
        }

        /// <summary>
        /// 时间控件标准显示方式。
        /// 参考标准尺寸 180,13 。
        /// 宽度标准 180 。
        /// </summary>
        /// <param name="dtp"></param>
        /// <param name="day"></param>
        public static void DateTimePickerStandard(DateTimePicker dtp,int day)
        {
            dtp.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.ShowUpDown = true;
            DateTime DT = DateTime.ParseExact(DateTime.Now.AddDays(day).ToString("yyyy-MM-dd 00:00:00"), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            dtp.Value = DT;
        }

        /// <summary>
        /// 时间控件标准显示方式。
        /// 参考标准尺寸 180,13 。
        /// 宽度标准 180 。
        /// </summary>
        /// <param name="dtp"></param>
        public static void DateTimePickerStandard4Start(DateTimePicker dtp)
        {
            DateTimePickerStandard(dtp,0);
        }

        /// <summary>
        /// 时间控件标准显示方式。
        /// 参考标准尺寸 180,13 。
        /// 宽度标准 180 。
        /// </summary>
        /// <param name="dtp"></param>
        public static void DateTimePickerStandard4End(DateTimePicker dtp)
        {
            DateTimePickerStandard(dtp, 1);
        }

    }
}
