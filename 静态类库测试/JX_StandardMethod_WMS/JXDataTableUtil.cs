using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace JX_StandardMethod_WMS
{
    /// <summary>
    /// DataTable操作方法工具类（对于C# 操作方法的补充）
    /// </summary>
    public class JXDataTableUtil
    {
        /// <summary>
        /// 将DataRow的数组转换为DataTable
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        public static DataTable DataRowArrayToDataTable(DataRow[] rows)
        {
            if (rows == null || rows.Length == 0) return null;
            DataTable tmp = rows[0].Table.Clone();  // 复制DataRow的表结构  
            foreach (DataRow row in rows)
                tmp.Rows.Add(row.ItemArray);  // 将DataRow添加到DataTable中  
            return tmp;
        }


        /// <summary>
        /// 传入源表，搜索关键字。返回搜索结果语句。默认第一列不参与搜索。
        /// 
        /// 请特别注意：列类型为string的才会参与搜索。最后一列必须要是string
        /// 如果指定要搜索的列 值类型不是string，那么会被忽略。
        /// </summary>
        /// <param name="SearchSource"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public static string DataTableQueryMode(DataTable SearchSource, string Key)
        {
            return DataTableQueryMode(SearchSource,Key,1);
        }
        /// <summary>
        /// 传入源表，搜索关键字。返回搜索结果语句。传入前多少列不参与搜索。
        /// 
        /// 请特别注意：列类型为string的才会参与搜索。最后一列必须要是string
        /// 如果指定要搜索的列 值类型不是string，那么会被忽略。
        /// </summary>
        /// <param name="SearchSource">原表</param>
        /// <param name="Key">关键字</param>
        /// <param name="Ignore">前多少列不参与搜索</param>
        /// <returns></returns>
        public static string DataTableQueryMode(DataTable SearchSource, string Key,int Ignore)
        {
            if (SearchSource == null)
            {
                return "";
            }
            string Result = "";
            for (int i = Ignore; i < SearchSource.Columns.Count; i++)
            {
                if (typeof(string).Equals(SearchSource.Columns[i].DataType))
                {
                    Result += "[" + SearchSource.Columns[i].ColumnName + "] like '%" + Key + "%'";
                    if (SearchSource.Columns.Count != i + 1)
                    {
                        Result += " or ";
                    }
                }

            }
            return Result;
        }
        /// <summary>
        /// 功能：一般用于中英文翻译
        /// 传入参数
        /// 【映射源（一般是英文）】
        /// 【映射源匹配的目标列（一般是写0）】
        /// 【一个数组（一般是【英文】【列宽】【中文】）】
        /// 【传入数组的一行有几个数据（一般是3）】
        /// 【映射目标（一般写中文所在列）】
        /// </summary>
        /// <param name="MappingSource">【映射源（一般是英文）】</param>
        /// <param name="MappingSourceColumns">【映射源匹配的目标列（一般是0）】</param>
        /// <param name="MappingArr">【一个数组（一般是【英文】【列宽】【中文】）】</param>
        /// <param name="ArrOneLineNumber">【传入数组的一行有几个数据（一般是3个）】</param>
        /// <param name="TargetColumns">【映射目标（一般写中文所在列）】</param>
        /// <returns></returns>
        public static string DataTableColumnsMapping(string MappingSource, int MappingSourceColumns,string[,] MappingArr,int ArrOneLineNumber,int TargetColumns)
        {
            for (int i = 0; i < MappingArr.Length / ArrOneLineNumber; i++)
            {
                if (MappingArr[i, MappingSourceColumns].Equals(MappingSource))
                {
                    return MappingArr[i, TargetColumns];
                }
            }
            return MappingSource;
        }


        /// <summary>
        /// DataTable 对象 转换为Json 字符串
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToJson(DataTable dt)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值
            ArrayList arrayList = new ArrayList();
            foreach (DataRow dataRow in dt.Rows)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();  //实例化一个参数集合
                foreach (DataColumn dataColumn in dt.Columns)
                {
                    dictionary.Add(dataColumn.ColumnName, dataRow[dataColumn.ColumnName].ToString());
                }
                arrayList.Add(dictionary); //ArrayList集合中添加键值
            }

            return javaScriptSerializer.Serialize(arrayList);  //返回一个json字符串
        }


        /// <summary>
        /// Json 字符串 转换为 DataTable数据集合
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static DataTable JsonToDataTable(string json)
        {
            DataTable dataTable = new DataTable();  //实例化
            DataTable result;
            try
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值
                ArrayList arrayList = javaScriptSerializer.Deserialize<ArrayList>(json);
                if (arrayList.Count > 0)
                {
                    foreach (Dictionary<string, object> dictionary in arrayList)
                    {
                        if (dictionary.Keys.Count<string>() == 0)
                        {
                            result = dataTable;
                            return result;
                        }
                        if (dataTable.Columns.Count == 0)
                        {
                            foreach (string current in dictionary.Keys)
                            {
                                dataTable.Columns.Add(current, dictionary[current].GetType());
                            }
                        }
                        DataRow dataRow = dataTable.NewRow();
                        foreach (string current in dictionary.Keys)
                        {
                            dataRow[current] = dictionary[current];
                        }

                        dataTable.Rows.Add(dataRow); //循环添加行到DataTable中
                    }
                }
            }
            catch
            {
            }
            result = dataTable;
            return result;
        }

        /// <summary>
        /// 提取DGV的列宽信息，转为JSON格式
        /// </summary>
        /// <param name="dataGridView1"></param>
        /// <returns></returns>
        public static string GetDGVWidthMessage(DataGridView dataGridView1)
        {
            try
            {
                string str = "";
                str = str + "{" + "\r\n";
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    str = str + "\"col_" + i + "_" + dataGridView1.Columns[i].Name + "\":\"" + dataGridView1.Columns[i].Width + "\"" + "\r\n";
                    if ((dataGridView1.Columns.Count - 1) != i)
                    {
                        str = str + "," + "\r\n";
                    }
                }
                str = str + "}" + "\r\n";
                return str;
            }
            catch
            {
                return "失败";
            }

        }
        /// <summary>
        /// 将未绑定过数据源的 DataGridView 转换为 DataTable
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public static DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            // 列强制转换
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dt.Columns.Add(dc);
            }

            // 循环行
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Value);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        /// <summary>
        /// 判断【SourceDTB】中的指定列【TargetColumn】 中的非重复值有几个
        /// 去重后计数
        /// </summary>
        /// <param name="SourceDTB"></param>
        /// <param name="TargetColumn"></param>
        /// <returns></returns>
        public static int Counter(DataTable SourceDTB,string TargetColumn)
        {
            try
            {
                HashSet<string> HSet = new HashSet<string>();
                for(int i=0;i< SourceDTB.Rows.Count; i++)
                    HSet.Add(SourceDTB.Rows[i][TargetColumn].ToString());
                return HSet.Count;
            }
            catch
            {

            }
            return -1;
        }

        /// <summary>
        /// 传入内存表，指定列。计算这列的和。非法字符记为0；
        /// </summary>
        /// <param name="SourceDTB"></param>
        /// <param name="TargetColumn"></param>
        /// <returns></returns>
        public static int Sum(DataTable SourceDTB, string TargetColumn)
        {
            int sum = 0;
            for (int i = 0; i < SourceDTB.Rows.Count; i++)
            {
                int lineNumber = 0;
                try
                {
                    lineNumber = int.Parse(SourceDTB.Rows[i][TargetColumn].ToString());
                }
                catch
                {

                }
                sum = sum + lineNumber;
            }
            return sum;
        }

        /// <summary>
        /// 将 一张内存表 按指定列拆分成多张表
        /// 
        /// 请注意，以下情况会返回null
        /// 1、传入内存表为null
        /// 2、传入内存表的行数量为0
        /// 3、传入指定列为null
        /// 4、传入指定列不存在
        /// </summary>
        /// <param name="SourceDTB"></param>
        /// <param name="TargetColumn"></param>
        /// <returns></returns>
        public static List<DataTable> SplitTable(DataTable SourceDTB, string TargetColumn)
        {
            List<DataTable> Result = new List<DataTable>();
            if (SourceDTB==null)return null;
            if (SourceDTB.Rows.Count == 0)return null;
            if (TargetColumn==null)return null;
            if (!SourceDTB.Columns.Contains(TargetColumn))return null;
            //根据目标列，为内存表进行分组，得到有哪些组
            HashSet<string> HSet = new HashSet<string>();
            for (int i = 0; i < SourceDTB.Rows.Count; i++)
                HSet.Add(SourceDTB.Rows[i][TargetColumn].ToString());
            foreach (string TargetCode in HSet)
            {
                DataTable NewDataTable = SourceDTB.Clone();
                for (int i = 0; i < SourceDTB.Rows.Count; i++)
                    if (SourceDTB.Rows[i][TargetColumn].ToString().Equals(TargetCode))
                        NewDataTable.Rows.Add(SourceDTB.Rows[i].ItemArray);
                Result.Add(NewDataTable);
            }
            return Result;
        }



        /// <summary>
        /// 传入【内存表】【指定列】
        /// 将内存表中 指定列里 有重复的行删除。
        /// 请注意，去重之后，内存表的原顺序将被改写。按 【需要去重列】倒序排列。
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="ColumnName"></param>
        /// <returns></returns>
        public static DataTable RemoveRepeated(DataTable Source,string ColumnName)
        {
            Source.DefaultView.Sort = "["+ ColumnName + "] DESC";
            Source = Source.DefaultView.ToTable();
            for (int i = 0; i < Source.Rows.Count; i++)
            {
                if (Source.Rows.Count !=(i+1))
                {
                    if (Source.Rows[i][ColumnName].ToString().Equals(Source.Rows[i + 1][ColumnName].ToString()))
                    {
                        Source.Rows.Remove(Source.Rows[i + 1]);
                        i--;
                    }
                }
                
            }
            return Source;
        }
    }
}
