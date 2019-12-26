using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JX_StandardMethod_WMS
{
    /// <summary>
    /// OfficeExcel操作工具类
    /// </summary>
    public class JXExcelUtil
    {

        /// <summary>
        /// Excel导入成Datable
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static DataTable ExcelToTable(string file)
        {
            
            try
            {
                File.Copy(file, file + ".wmstemp");
                DataTable dt = new DataTable();
                IWorkbook workbook;
                string fileExt = Path.GetExtension(file).ToLower();
                using (FileStream fs = new FileStream(file + ".wmstemp", FileMode.Open, FileAccess.Read))
                {
                    //XSSFWorkbook 适用XLSX格式，HSSFWorkbook 适用XLS格式
                    if (fileExt == ".xlsx")
                    {
                        workbook = new XSSFWorkbook(fs);
                    }
                    else if (fileExt == ".xls")
                    {
                        workbook = new HSSFWorkbook(fs);
                    }
                    else
                    {
                        workbook = null;
                    }
                    //关闭文件字节流
                    fs.Close();
                    //删除临时文件
                    File.Delete(file + ".wmstemp");
                    if (workbook == null)
                    {
                        return null;
                    }
                    ISheet sheet = workbook.GetSheetAt(0);
                    //表头  
                    IRow header = sheet.GetRow(sheet.FirstRowNum);
                    List<int> columns = new List<int>();
                    for (int i = 0; i < header.LastCellNum; i++)
                    {
                        object obj = GetValueType(header.GetCell(i));
                        try
                        {
                            if (obj == null || obj.ToString() == string.Empty)
                            {
                                dt.Columns.Add(new DataColumn("Columns" + JXStringUtil.InvalidClear(i.ToString())));
                            }
                            else
                            {
                                dt.Columns.Add(new DataColumn(JXStringUtil.InvalidClear(obj.ToString())));
                            }
                        }
                        catch
                        {
                            dt.Columns.Add(new DataColumn("Columns_" + JXStringUtil.InvalidClear(obj.ToString()) +"_"+ i.ToString()));
                        }
                        columns.Add(i);
                    }
                    //数据  
                    for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                    {
                        try
                        {
                            DataRow dr = dt.NewRow();
                            bool hasValue = false;
                            foreach (int j in columns)
                            {
                                dr[j] = GetValueType(sheet.GetRow(i).GetCell(j));
                                if (dr[j] != null && dr[j].ToString() != string.Empty)
                                {
                                    hasValue = true;
                                }
                            }
                            if (hasValue)
                            {
                                dt.Rows.Add(dr);
                            }
                            else
                            {
                                break;
                            }
                        }
                        catch
                        {

                        }

                    }
                }
                try
                {
                    //清洗导入数据
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            
                            dt.Rows[i][j] = JXStringUtil.InvalidClear(dt.Rows[i][j].ToString());
                        }
                    }
                }
                catch
                {

                }


                return dt;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// Excel导入成Datable
        /// </summary>
        /// <param name="file"></param>
        /// <param name="SonTableName">子表名</param>
        /// <returns></returns>
        private static DataTable ExcelToTable(string file,string SonTableName)
        {
            try
            {

                DataTable dt = new DataTable();
                IWorkbook workbook;
                string fileExt = Path.GetExtension(file).ToLower();
                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    //XSSFWorkbook 适用XLSX格式，HSSFWorkbook 适用XLS格式
                    if (fileExt == ".xlsx")
                    {
                        workbook = new XSSFWorkbook(fs);
                    }
                    else if (fileExt == ".xls")
                    {
                        workbook = new HSSFWorkbook(fs);
                    }
                    else { workbook = null; }
                    if (workbook == null) { return null; }
                    ISheet sheet = workbook.GetSheet(SonTableName);

                    //表头  
                    IRow header = sheet.GetRow(sheet.FirstRowNum);
                    List<int> columns = new List<int>();
                    for (int i = 0; i < header.LastCellNum; i++)
                    {
                        object obj = GetValueType(header.GetCell(i));
                        if (obj == null || obj.ToString() == string.Empty)
                        {
                            dt.Columns.Add(new DataColumn("Columns" + i.ToString()));
                        }
                        else
                            dt.Columns.Add(new DataColumn(obj.ToString()));
                        columns.Add(i);
                    }
                    //数据  
                    for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                    {
                        DataRow dr = dt.NewRow();
                        bool hasValue = false;
                        foreach (int j in columns)
                        {
                            dr[j] = GetValueType(sheet.GetRow(i).GetCell(j));
                            if (dr[j] != null && dr[j].ToString() != string.Empty)
                            {
                                hasValue = true;
                            }
                        }
                        if (hasValue)
                        {
                            dt.Rows.Add(dr);
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return null;
            }
        }
        /// <summary>
        /// 这个方法需要您传入【内存表】【文件名称（系统将自动跟上时间和后缀）】
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static int TableToExcelDesk(DataTable dt, string file)
        {
            try
            {
                DateTime dtm = DateTime.Now;
                string FILE = file + "_" + dtm.ToString("yyyy年MM月dd日HH点mm分ss秒导出") + ".xls";
                TableToExcel(dt, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + FILE);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// Datable导出成Excel
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="file"></param>
        public static int TableToExcel(DataTable dt, string file)
        {
            try
            {
                IWorkbook workbook;
                string fileExt = Path.GetExtension(file).ToLower();
                if (fileExt == ".xlsx") { workbook = new XSSFWorkbook(); } else if (fileExt == ".xls") { workbook = new HSSFWorkbook(); } else { workbook = null; }
                if (workbook == null) { return -1; }
                ISheet sheet = string.IsNullOrEmpty(dt.TableName) ? workbook.CreateSheet("Sheet1") : workbook.CreateSheet(dt.TableName);

                //表头  
                IRow row = sheet.CreateRow(0);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ICell cell = row.CreateCell(i);
                    cell.SetCellValue(dt.Columns[i].ColumnName);
                }

                //数据  
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow row1 = sheet.CreateRow(i + 1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ICell cell = row1.CreateCell(j);
                        cell.SetCellValue(dt.Rows[i][j].ToString());
                    }
                }

                //转为字节数组  
                MemoryStream stream = new MemoryStream();
                workbook.Write(stream);
                var buf = stream.ToArray();

                //保存为Excel文件  
                using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(buf, 0, buf.Length);
                    fs.Flush();
                }
                return 1;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return -1;
            }

        }

        /// <summary>
        /// 获取单元格类型
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static object GetValueType(ICell cell)
        {
            if (cell == null)
                return null;
            switch (cell.CellType)
            {
                case CellType.Blank: //BLANK:  
                    return null;
                case CellType.Boolean: //BOOLEAN:  
                    return cell.BooleanCellValue;
                case CellType.Numeric: //NUMERIC:  
                    return cell.NumericCellValue;
                case CellType.String: //STRING:  
                    return cell.StringCellValue;
                case CellType.Error: //ERROR:  
                    return cell.ErrorCellValue;
                case CellType.Formula: //FORMULA:  
                default:
                    return "=" + cell.CellFormula;
            }
        }

    }
}
