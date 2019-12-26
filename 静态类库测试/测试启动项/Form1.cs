using JX_StandardLibrary_WMS;
using JX_StandardMethod_WMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using System.IO;
using System.Drawing;
using MySql.Data.MySqlClient;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.Util;
using System.Threading;
using System.Net;
using System.Text;
using System.Linq;
using JX_TCPIPDataProtocol;
using System.Diagnostics;
using static JX_TCPIPDataProtocol.JXMouseProtocol;
using static JX_TCPIPDataProtocol.JXMouseProtocolAPI;

namespace 测试启动项
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //PROJECTABOUT.项目名称 = "1";
            // 公共类.项目名称 = "11";
            //MessageBox.Show(公共类.项目名称);
            //MessageBox.Show(PROJECTABOUT.项目名称);
            if (JXMessageCheckBox.Show("11"))
            {
                JXMessageBox.Show("你选择了确认");
            }
            else
            {
                JXMessageBox.Show("你选择了取消");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = "";
            for(int i = 0; i < 201; i++)
            {
                str = str + "好";
            }
            //JXHTTP.PostPage("","");
            JXMessageBox.Show(str);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //DataSet dataSet = ImportExcel(@"C:\Users\ZhuDiyao\Desktop\xxx.xlsx");
            DataTable dtb = JXExcelUtil.ExcelToTable(@"C:\Users\ZhuDiyao\Desktop\xxx.xls");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ////打包
            //Dictionary<string, object> dicToPack = new Dictionary<string, object>();
            //dicToPack.Add("key1", Image.FromFile(@"D:\1.jpg"));
            ////dicToPack.Add("key1", Image.FromFile(@"D:\QQ.exe"));
            //dicToPack.Add("key2", "hello world");
            //ResPacker.Pack(dicToPack);
            ////解包
            //Dictionary<string, object> dicRcv = ResPacker.GetAllResources();
            //Console.WriteLine((string)dicRcv["key2"]);
            //Console.WriteLine(dicRcv["key1"].GetType().FullName);
            //Console.ReadKey();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string strpath = @"Y:\MicrosoftAbout\$佳轩仓储管理系统\佳轩物流仓储管理系统解决方案\JXWMS\JXWMS\bin\Debug";
            JXZipUtil.ToPackage(strpath, @"C:\Users\ZhuDiyao\Desktop\1.zip");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //JXZipUtil.ToFilePath(@"D:\1.jxzip",@"D:\22d");

            JXZipUtil.ToFilePath(
    @"Y:\$jiaxuanVersion\佳轩本地更新标准程序\佳轩新版本下载通用程序\佳轩新版本下载通用程序\bin\Debug\LastVersion.jiaxuanpackage",
    @"Y:\$jiaxuanVersion\佳轩本地更新标准程序\佳轩新版本下载通用程序\佳轩新版本下载通用程序\bin\Debug\JXHOMESystem\");
            ;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //            DataTable dtb = 
            //            JXExcelUtil.ExcelToTable(
            //                @"C:\Users\ZhuDiyao\Desktop\杭州-5月6日至5月12日锁定排序计划（0415V0）0416（物流版）.xlsx"
            //, "AF OFF"
            //);
            JXMessageBox.Show(JXFastPath.GetDeskFilePath(""));
            //DataTable dataTable = JXExcelUtil.ExcelToTable();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /***
             * 读取本地数据库配置信息
             * 项目中不包含任何数据库信息
             * 因为项目是开源的
             * **/
            try
            {
                string fileSource = @"Y:\home\DBConfig\";
                StaticBox.DBIPAddr = JXFileUtil.FileToString(fileSource + "IPAddr.config");
                StaticBox.DBUSERNAME = JXFileUtil.FileToString(fileSource + "RootDBUserName.config");
                StaticBox.DBPASSWORD = JXFileUtil.FileToString(fileSource + "RootDBPassWord.config");
            }
            catch
            {

            }


            JXDataTableUtil.DataTableQueryMode(null,"");
            textBox2.Text = "JXWMS"+DateTime.Now.ToString("yyyyMMddHH");
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            JXMessageBox.Show(JXCryptography.GetMD5(textBox1.Text));
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            打印模型测试窗体 ppp = new 打印模型测试窗体();
            ppp.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FileInfo str1 = JXFileUtil.GetNewFile(@"D:\wmsExcel", "拉动订单数据");

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Bitmap bt = JXQRCode.GetQRCode("666666666666");
            bt.Save(JXFastPath.GetDeskFilePath("code.jpg"));
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = dialog.FileName;
                JXHTTP.HttpUploadFile("http://localhost:8080/GetFile.jspx", file);
            }
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("列1");
            dataTable.Columns.Add("列2");
            dataTable.Columns.Add("列3");
            JXSearcherTools.Show(dataTable);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //DataTable dataTable = JXExcelUtil.ExcelToTable(JXFastPath.GetDeskFilePath("售后订单明细20190627135717.xls"));
            JXRandomUtil.GetRandomString("0 1 2    3 5 6 7 8 9",10);
        }

        DataTable 结果集 = new DataTable();
        void 向结果集添加一行(DataRow dataRow,bool flag)
        {
            for(int i=0;i< 结果集.Rows.Count; i++)
                if (结果集.Rows[i]["零件编号"].ToString().Trim().Equals(dataRow["零件编号"].ToString().Trim()))
                    return;
            DataRow 新行 = 结果集.NewRow();
            if (flag)
            {
                //尝试使用 零件对应车型消耗表 进行处理
                新行["零件编号"] = dataRow["零件编号"].ToString().Trim();
                新行["零件名称"] = dataRow["零件名称"].ToString().Trim();
                新行["供应商"] = dataRow["供应商代码"].ToString().Trim();
                新行["供应商名称"] = dataRow["供应商名称"].ToString().Trim();
                结果集.Rows.Add(新行);
            }
            else
            {
                结果集.Rows.Add(dataRow.ItemArray);
            }
        }
        private void button15_Click(object sender, EventArgs e)
        {
            DataTable 零件对应车型的消耗量表 = JXExcelUtil.ExcelToTable(JXFastPath.GetDeskFilePath("零件对应车型的消耗量表.xls"));
            DataTable 零件基础信息表 = JXExcelUtil.ExcelToTable(JXFastPath.GetDeskFilePath("零件基础信息表.xls"));
            结果集 = 零件基础信息表.Clone();
            for (int i = 0; i < 零件基础信息表.Rows.Count; i++)向结果集添加一行(零件基础信息表.Rows[i],false);
            for (int i = 0; i < 零件对应车型的消耗量表.Rows.Count; i++)向结果集添加一行(零件对应车型的消耗量表.Rows[i],true);
            JXExcelUtil.TableToExcelDesk(结果集,"处理结果");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string str = "s123da1";
            bool d = JXStringUtil.LastCharIsNumber(str);
            JXMessageBox.Show(str + "的最后一位是数字？"+d);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            DataTable data = JXExcelUtil.ExcelToTable(JXFastPath.GetDeskFilePath("zong.xlsx"));
        }

        private void button18_Click(object sender, EventArgs e)
        {
            DateTime Year = this.dateTimePicker1.Value;
            SystemTime MySystemTime = new SystemTime();
            SetSystemDateTime.GetLocalTime(MySystemTime);
            MySystemTime.vYear = (ushort)this.dateTimePicker1.Value.Year;
            MySystemTime.vMonth = (ushort)this.dateTimePicker1.Value.Month;
            MySystemTime.vDay = (ushort)this.dateTimePicker1.Value.Day;
            MySystemTime.vHour = (ushort)this.dateTimePicker2.Value.Hour;
            MySystemTime.vMinute = (ushort)this.dateTimePicker2.Value.Minute;
            MySystemTime.vSecond = (ushort)this.dateTimePicker2.Value.Second;
            SetSystemDateTime.SetLocalTime(MySystemTime);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            JXMessageBox.Show(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
        }

        private void button21_Click(object sender, EventArgs e)
        {
            DataTable 电子表 = JXExcelUtil.ExcelToTable(JXFastPath.ChooseExcelPath("请选择电子表"));
            DataTable 系统表 = JXExcelUtil.ExcelToTable(JXFastPath.ChooseExcelPath("请选择系统表"));
            try
            {
                DataTable dtb = 执行校对(电子表, 系统表);
                JXExcelUtil.TableToExcelDesk(dtb, "电子表对系统表");

            }
            catch(Exception ex)
            {
                JXMessageBox.Show("校对出错" + ex.ToString());
            }

            try
            {
                DataTable dtb = 执行校对(系统表, 电子表);
                JXExcelUtil.TableToExcelDesk(dtb, "系统表对电子表");

            }
            catch (Exception ex)
            {
                JXMessageBox.Show("校对出错" + ex.ToString());
            }
            JXMessageBox.Show("校对结束");
        }
        /// <summary>
        /// 以第一列为主键，校对两表。
        /// 要求
        /// 1、第一列为主键
        /// 2、所有列的名称必须一致，不可多列少列
        /// </summary>
        /// <param name="主表"></param>
        /// <param name="辅表"></param>
        /// <returns></returns>
        DataTable 执行校对(DataTable 主表,DataTable 辅表)
        {
            DataTable 结果表 = new DataTable();
            结果表.Columns.Add("主表列序号");
            结果表.Columns.Add("键值");
            结果表.Columns.Add("问题描述");
            for (int i = 0; i < 主表.Rows.Count; i++)
            {
                string 主表当前行的所有列内容 = "";

                for (int m = 0; m < 主表.Columns.Count; m++)
                {
                    主表当前行的所有列内容 = 主表当前行的所有列内容 + "【[第"+m+"列的值]" + 主表.Rows[i][m].ToString() + "】";
                }

                string 零件号 = 主表.Rows[i][0].ToString().Trim();
                
                //准备检查结果表的新行
                DataRow 结果表新行 = 结果表.NewRow();

                结果表新行["主表列序号"] = (i+1)+"";
                结果表新行["键值"] = 主表.Rows[i][0].ToString();

                //检查 辅表 中零件号出现次数
                int count = 0;
                for(int j = 0; j < 辅表.Rows.Count; j++)
                {
                    if (零件号.Equals(辅表.Rows[j][0].ToString().Trim()))
                    {
                        count++;
                    }
                }
                if (count == 0)
                {
                    结果表新行["问题描述"] = "在辅表中找不到这个零件"+ 主表当前行的所有列内容;
                    结果表.Rows.Add(结果表新行);
                    continue;
                }
                if (count > 1)
                {
                    结果表新行["问题描述"] = "在辅表中多次找到这个零件"+ 主表当前行的所有列内容;
                    结果表.Rows.Add(结果表新行);
                    continue;
                }

                //遍历辅助表，找到对应的零件，进行数据对比
                for (int j = 0; j < 辅表.Rows.Count; j++)
                {
                    if (零件号.Equals(辅表.Rows[j][0].ToString().Trim()))
                    {
                        //遍历辅助表是所有列
                        for (int n = 1;n< 辅表.Columns.Count;n++)
                        {
                            string 主表校对值 = 主表.Rows[i][n].ToString().Trim();
                            string 辅表校对值 = 辅表.Rows[j][n].ToString().Trim();
                            if (!主表校对值.Equals(辅表校对值))
                            {
                                结果表新行["问题描述"] = "列【"+ 主表.Columns[n].ColumnName.Trim() + "】值不一致(主表："+ 主表校对值 + ")(辅表："+ 辅表校对值 + ")///"+ 主表当前行的所有列内容;
                                结果表.Rows.Add(结果表新行);
                                break;
                            }
                        }
                    }
                }

            }
            return 结果表;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            CreateMysqlDB();
        }
        bool 拦截器()
        {
            string DBNAME = textBox2.Text.Trim();
            if (DBNAME.Equals("JXWMS"))
            {
                MessageBox.Show("主项目数据库无法进行任何操作");
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 创建数据库
        /// </summary>
        public void CreateMysqlDB()
        {
            if (!拦截器()) return;

            MySqlConnection conn = new MySqlConnection("Data Source=" + StaticBox.DBIPAddr + ";Persist Security Info=yes; UserId=" + StaticBox.DBUSERNAME + "; PWD=" + StaticBox.DBPASSWORD);
            MySqlCommand cmd = new MySqlCommand("CREATE DATABASE `" + textBox2.Text.Trim() +"` CHARACTER SET 'utf8' COLLATE 'utf8_bin';", conn);

            conn.Open();

            //防止第二次启动时再次新建数据库
            try
            {
                cmd.ExecuteNonQuery();
                conn.Close();
                JXMessageBox.Show("数据库创建成功");
            }
            catch (Exception ex)
            {
                conn.Close();
                JXMessageBox.Show("数据库创建失败:"+ex.ToString());
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            string str = JXFastPath.ChooseExcelPath("请选择SQL文件","Shape.sql");
            if (str != null)
            {
                label5.Text = str;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            string str = JXFastPath.ChooseExcelPath("请选择SQL文件", "Data.sql");
            if (str != null)
            {
                label6.Text = str;
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            恢复表结构();
        }

        void 恢复表结构()
        {
            if (!拦截器()) return;
            string 文件内容 = JXFileUtil.FileToString(label5.Text) ;
            if (文件内容.Equals(""))
            {
                JXMessageBox.Show("文件读取失败");
                return;
            }
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(文件内容, conn);
            //防止第二次启动时再次新建数据库
            try
            {
                cmd.ExecuteNonQuery();
                conn.Close();
                JXMessageBox.Show("恢复操作成功");
            }
            catch (Exception ex)
            {
                conn.Close();
                JXMessageBox.Show("恢复操作失败:" + ex.ToString());
            }
        }


        public MySqlConnection GetConnection()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(
            "server=" + StaticBox.DBIPAddr + ";User Id=" + StaticBox.DBUSERNAME + ";password=" + StaticBox.DBPASSWORD + ";Database=" + textBox2.Text.Trim() + ";Charset=utf8;Allow User Variables=True");

            mySqlConnection.Open();
            return mySqlConnection;

        }

        private void button24_Click(object sender, EventArgs e)
        {
            恢复表数据();
        }

        void 恢复表数据()
        {
            long starttime = JXDateUtil.CurrentTimeMillis();
            if (!拦截器()) return;
            string 文件内容 = JXFileUtil.FileToString(label6.Text);
            int filelength = 文件内容.Length;
            //JXFileUtil.StringToFile(label6.Text+".txt", 文件内容);
            /**
             * 每1MB，给予延时增加5秒。
             * **/
            int addTime = filelength / 1024 / 1024;

            if (文件内容.Equals(""))
            {
                JXMessageBox.Show("文件读取失败");
                return;
            }
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(文件内容, conn);
            
            cmd.CommandTimeout = 240 + addTime;
            //MessageBox.Show("超时时间：" + cmd.CommandTimeout);
            //防止第二次启动时再次新建数据库
            try
            {
                cmd.ExecuteNonQuery();
                conn.Close();
                JXMessageBox.Show("恢复操作成功");
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("恢复操作失败:" + ex.ToString());
            }
            long endtime = JXDateUtil.CurrentTimeMillis();
            JXMessageCheckBox.Show("恢复数据总耗时：" + (endtime - starttime) + "毫秒");
        }

        private void button25_Click(object sender, EventArgs e)
        {
            CreateMysqlDB();
            恢复表结构();
            恢复表数据();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            string source = "abcdefghijklmnopqrstuvwxyz";
            string aaa = "";
            string bbb = "";
            string str = JXStringUtil.SubStringSenior(source, null, bbb);
            str = JXStringUtil.SubStringSeniorBody(source, "a", "b");
            str = JXStringUtil.SubStringSeniorBody(source, "a", "x");
            str = JXStringUtil.SubStringSeniorBody(source, "x", "a");
            str = JXStringUtil.SubStringSeniorBody(source, "c", "c");
            str = JXStringUtil.SubStringSeniorBody(source, "c", "b");
            str = JXStringUtil.SubStringSeniorBody(source, "cde", "bcd");
            str = JXStringUtil.SubStringSeniorBody(source, "a", "b");
            str = JXStringUtil.SubStringSeniorBody(source, "a", "b");
            str = JXStringUtil.SubStringSeniorBody(source, "a", "b");
            str = JXStringUtil.SubStringSeniorBody(source, "a", "b");

        }

        private void button27_Click(object sender, EventArgs e)
        {
            JXCryptography4RSA.GenerateRSASecretKey();
            
            
            label7.Text = JXCryptography4RSA.PublicKey;

            label8.Text = JXCryptography4RSA.PrivateKey;

            string str = JXCryptography4RSA.RSAEncrypt(JXCryptography4RSA.PublicKey,"123456");

            str = JXCryptography4RSA.RSADecrypt(JXCryptography4RSA.PrivateKey, str);
            string 公钥 = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQC9aVnVxo8wuiHBjyGcTAao0aOhzZp7sNR2k54GOkI8KAOHqGLl7xkYCKuioD5jPgx7dRBKqBPlmw32+q7W8c3V1rVxcLgwgkxRPEHJrbMzoocAj+YikABlOIFJFlO++PneJ6oP6m0QRyZFbKCbZa+sVbNWTYWcqeG0qCjyA1E55wIDAQAB";
            string 私钥 = "MIICdgIBADANBgkqhkiG9w0BAQEFAASCAmAwggJcAgEAAoGBAL1pWdXGjzC6IcGPIZxMBqjRo6HNmnuw1HaTngY6QjwoA4eoYuXvGRgIq6KgPmM+DHt1EEqoE+WbDfb6rtbxzdXWtXFwuDCCTFE8QcmtszOihwCP5iKQAGU4gUkWU774+d4nqg/qbRBHJkVsoJtlr6xVs1ZNhZyp4bSoKPIDUTnnAgMBAAECgYB4iVScEHILRkg5D0cKWe9a+54wV9FZqZxroWFNAUIpWiV07RmSzeegPdRL98H8Ef6LimHFwNR4p4XpiHo/Wz3rIKGSii0wOp77hUIzCwDrPrFI4W3idvaQfbJAXkYg89/bgignhPX5jj0nMjzhPnEyZbnH0d3YBljga4habfTpUQJBAOn5dZaHY4Lw/OlLX8dTfHmOYqoi1xpVMQFVusTJ+FCdX5EqG89zBfHHsAOBF5RPsc2AOXQ6o/1nUABb3VX2JOsCQQDPPfi2CcvOzvKgfWQV9R4sfcHQXEJuaDcGc+mm2y+F0qJZVz83x8DFm7xkWNx4UbIudT+eJa0ixJ+6IAIWum/1AkEAyJcf4q+r9sSYb4I5WPAQVT5nBCnedCr5WoWfG7tz8dkZ56BMO2wHeqOSGU8BYht4+g+mMilcEpISGlynw1zFhQJABADcdxfFWh9hTHxfnJT5mj5rqgy+M8fLmFJQ5ypAxsME49jtnbQ8IxUZFI8q4yAg4wjcy79Kkutdcoj/wVSkqQJAUp5OKk3PQeWMSSvTTGURv3yvhqD/PJv8lRiluaGw2g8hsCXDxgnssM2CI6L3hNWrcguksNpuMpe0LbMFadGzPA==";
            string 密文 = "DTmuIl1llT2SqitFuV70AxOytASgmR9aO4ittXi/V2+QWSTLXB9NXT7ElSq6geXUwgzC5ZEVjM5M5/RjIoi3ArQYSz1iR0TS8vxmaWIS7DFz51GKidZIOoZZT6zv4/W+EomPI/wUHfLAY1lkjqhzxqM7JLE1JyjmUc4L4H5pwlU=";
            str = JXCryptography4RSA.RSADecrypt4Base64(私钥, 密文);
            str = JXCryptography4RSA.RSAEncrypt4Base64(公钥, "123456");
        }

        private void button28_Click(object sender, EventArgs e)
        {
            打印模型测试窗体 sss = new 打印模型测试窗体();
            sss.Show();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            string str = JXFastPath.ChooseExcelPath("选择表格");
            if (str != null)
            {
                DataTable sss = JXDataTableUtil.RemoveRepeated(JXExcelUtil.ExcelToTable(str),"序号");
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            //JXStyle.DateTimePickerStandard(dateTimePicker1);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            string str = JXDateUtil.GetServiceTime();
            string file = JXFastPath.GetDeskFilePath("模板.xls");
            DataTable dt = new DataTable();

            dt.Columns.Add("a11");
            for (int i = 0; i < 100; i++)
            {
                DataRow dr = dt.NewRow();
                dr["a11"] = "23231";

                dt.Rows.Add(dr);
            }

            try
            {
                IWorkbook workbook;
                string fileExt = Path.GetExtension(file).ToLower();
                if (fileExt == ".xlsx") { workbook = new XSSFWorkbook(); } else if (fileExt == ".xls") { workbook = new HSSFWorkbook(); } else { workbook = null; }
                if (workbook == null) { return; }

                ISheet sheet_1_日报 = string.IsNullOrEmpty(dt.TableName) ? workbook.CreateSheet("日报") : workbook.CreateSheet(dt.TableName);
                ISheet sheet_2_到货记录 = string.IsNullOrEmpty(dt.TableName) ? workbook.CreateSheet("到货记录") : workbook.CreateSheet(dt.TableName);
                ISheet sheet_3_出货记录 = string.IsNullOrEmpty(dt.TableName) ? workbook.CreateSheet("出货记录") : workbook.CreateSheet(dt.TableName);
                ISheet sheet_4_来货不良 = string.IsNullOrEmpty(dt.TableName) ? workbook.CreateSheet("来货不良") : workbook.CreateSheet(dt.TableName);
                ISheet sheet_5_GAMC退回 = string.IsNullOrEmpty(dt.TableName) ? workbook.CreateSheet("GAMC退回") : workbook.CreateSheet(dt.TableName);
                ISheet sheet_6_退回供应商 = string.IsNullOrEmpty(dt.TableName) ? workbook.CreateSheet("退回供应商") : workbook.CreateSheet(dt.TableName);
                ISheet sheet_7_不合格记录 = string.IsNullOrEmpty(dt.TableName) ? workbook.CreateSheet("不合格记录") : workbook.CreateSheet(dt.TableName);



                //表头  
                IRow row = sheet_1_日报.CreateRow(0);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ICell cell = row.CreateCell(i);
                    cell.SetCellValue(dt.Columns[i].ColumnName);


                }

                //数据  
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow row1 = sheet_1_日报.CreateRow(i + 1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ICell cell = row1.CreateCell(j);
                        cell.SetCellValue(dt.Rows[i][j].ToString());

                        ICellStyle cellStyle = workbook.CreateCellStyle();
                        cellStyle.FillPattern = FillPattern.SolidForeground;
                        cellStyle.FillForegroundColor = 47;
                        cell.CellStyle = cellStyle;
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
                return;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return;
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> 左表 = new Dictionary<string, int>();
            Dictionary<string, int> 右表 = new Dictionary<string, int>();

            JXListUtil.添加值(左表, "A", 10);
            JXListUtil.添加值(左表, "A", 15);
            JXListUtil.添加值(左表, "B", 5);
            JXListUtil.添加值(左表, "C", 2);
            JXListUtil.添加值(左表, "A", 2);

            JXListUtil.添加值(右表, "A", 27);
            JXListUtil.添加值(右表, "B", 3);
            JXListUtil.添加值(右表, "C", 3);
            JXListUtil.添加值(右表, "B", 2);

            int index = JXListUtil.列表值校对(左表,右表);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            string strpath = JXFastPath.ChooseExcelPath("");
            DataTable dtb = JXExcelUtil.ExcelToTable(strpath);
            if (dtb == null)
            {
                return;
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            string timestr = JXDateUtil.GetServiceTimeFast();
            JXMessageBox.Show(timestr);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            主程序退出标记.主程序退出标记值 = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button35.Text = JXDateUtil.GetServiceTimeFast();

            PONITAPI p = new PONITAPI();
            GetCursorPos(ref p);
            //JXMessageBox.Show(p.x + "," + p.y);
            button50.Text = "鼠标当前位置（"+ p.x + "," + p.y + "）";
        }

        private void button36_Click(object sender, EventArgs e)
        {
            button36.Text = JXStringUtil.InsertSonString(textBox3.Text, textBox4.Text);
        }

        private void button38_Click(object sender, EventArgs e)
        {
            string CookieStr = string.Empty;
            string result = "";
            for (int i = 0; i < 10000; i++)
            {
                CookieStr = string.Empty; //每次都清除cookie SessionID
                result = SimulatedGet("http://localhost:1342/%E5%85%A8%E5%B1%80%E5%BA%94%E7%94%A8%E7%A8%8B%E5%BA%8F%E5%8F%98%E9%87%8F%E7%BB%9F%E8%AE%A1%E5%9C%A8%E7%BA%BF%E4%BA%BA%E6%95%B0.aspx", ref CookieStr);
                result = result.Replace("\r\n", "\r");
                string[] html = result.Split('\r');
                Console.WriteLine(html[0]);
                Thread.Sleep(10);
            }
            Console.ReadKey();
        }
        private static string SimulatedGet(string Url, ref string CookieStr)
        {
            //GET /NewsAdmin/Login.aspx HTTP/1.1
            //Host: localhost
            //User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64; rv:33.0) Gecko/20100101 Firefox/33.0
            //Accept: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8
            //Accept-Language: zh-cn,zh;q=0.8,en-us;q=0.5,en;q=0.3
            //Accept-Encoding: gzip, deflate
            //Connection: keep-alive
            string result = "";
            WebClient context = new WebClient();
            context.Headers.Add("Host: localhost");
            context.Headers.Add("User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64; rv:33.0) Gecko/20100101 Firefox/33.0");
            context.Headers.Add("Accept: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            context.Headers.Add("Accept-Language: zh-cn,zh;q=0.8,en-us;q=0.5,en;q=0.3");
            context.Headers.Add("Content-Type: multipart/form-data");
            context.Headers.Add("Accept-Encoding: gzip, deflate");
            context.Headers.Add("Cache-Control: no-cache"); //Connection: keep-alive
            if (!string.IsNullOrEmpty(CookieStr))
            {
                context.Headers.Add(CookieStr); //把cookie添加到请求报文头中。
            }
            context.Encoding = Encoding.UTF8;
            result = context.DownloadString(Url);
            if (string.IsNullOrEmpty(CookieStr))
            {
                CookieStr = context.ResponseHeaders["Set-Cookie"].ToString();
                CookieStr = GetCookie(CookieStr);
            }
            return result;
        }

        private static string GetCookie(string CookieStr)
        {
            string result = "";
            string[] myArray = CookieStr.Split(',');
            if (myArray.Length > 0)
            {
                result = "Cookie: ";
                foreach (var str in myArray)
                {
                    string[] CookieArray = str.Split(';');
                    result += CookieArray[0].Trim();
                    result += "; ";
                }
                result = result.Substring(0, result.Length - 2);
            }
            return result;
        }

        private void button39_Click(object sender, EventArgs e)
        {

        }

        private void button41_Click(object sender, EventArgs e)
        {
            string str = JXHTTPKeepConnect.DoPost(textBox5.Text,"");
            JXFileUtil.StringToFile(JXFastPath.GetDeskFilePath(DateTime.Now.ToString("yyyyMMddHHmmss")+".html"),str);
        }

        private void button42_Click(object sender, EventArgs e)
        {
            JXImageUtil.压缩图片();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            //JXFileUtil.StringToFile("D:\\a\\b\\c.txt","???A打");

            JXFilePathUtil.CheckPath(textBox6.Text);
        }
        /// <summary>
        /// 命令
        /// </summary>
        byte[] commandarray;
        /// <summary>
        /// 附件
        /// </summary>
        byte[] filearray;
        /// <summary>
        /// 合成指令
        /// </summary>
        byte[] commandarray4096;
        private void button44_Click(object sender, EventArgs e)
        {
            string sourceFilePath = JXFastPath.GetDeskFilePath("v.jpg");
            filearray = JXFileUtil.FileToByteArray(sourceFilePath);
        }

        private void button45_Click(object sender, EventArgs e)
        {


            string 命令 = "命令开始请接收文件到D:\\n.jpg命令终止";

            commandarray = JXStringUtil.StringToByteArray(命令);
            byte[] 补齐命令 = new byte[4096- commandarray.Length];
            commandarray = commandarray.Concat(补齐命令).ToArray();

            commandarray4096 = commandarray.Concat(filearray).ToArray();

            byte[] commandarray1111111 = JXFileProtocol.SynthesisCommand(JXStringUtil.StringToByteArray(命令), filearray);

            commandarray4096 = commandarray1111111;
        }

        private void button46_Click(object sender, EventArgs e)
        {
            byte[] 接收到命令 = commandarray4096;


            byte[] 命令部分 = JXFileProtocol.GetCommand(接收到命令);
            byte[] 附件部分 = JXFileProtocol.GetAnnex(接收到命令);

            string commandStr = JXStringUtil.ByteArrayToString(接收到命令);
            JXFileUtil.ByteArrayToFile("D:\\n.jpg",附件部分);
        }

        private void button47_Click(object sender, EventArgs e)
        {
            //1、读取图片
            Bitmap bitmap = JXImageProtocol.GetDesktopImage();
            //2、展示看图片
            //panel1.BackgroundImage = Image.FromHbitmap(bitmap.GetHbitmap());
            //JXImageUtil.PrintImg(bitmap, JXFastPath.GetDeskFilePath("xx.jpg"));
            //3、图片转字节数组
            byte[] barr = JXImageProtocol.ImgToByteArr(bitmap);


            //4、字节数组转图片
            bitmap = JXImageProtocol.ByteArrToImage(barr);

            panel1.BackgroundImage = Image.FromHbitmap(bitmap.GetHbitmap());
        }

        private void button50_Click(object sender, EventArgs e)
        {
            PONITAPI p = new PONITAPI();
            GetCursorPos(ref p);
            JXMessageBox.Show(p.x+","+p.y);
        }

        private void button51_Click(object sender, EventArgs e)
        {
            PONITAPI p = new PONITAPI();
            p.x = (new Random()).Next(Screen.PrimaryScreen.Bounds.Width);
            p.y = (new Random()).Next(Screen.PrimaryScreen.Bounds.Height);
            SetCursorPos(p.x, p.y);
        }

        private void button52_Click(object sender, EventArgs e)
        {
            PONITAPI p = new PONITAPI();
            //Console.WriteLine("在X:{0}, Y:{1} 按下鼠标左键", p.x, p.y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, p.x, p.y, 0, 0);
            //Console.WriteLine("Sleep 1 sec...");
            //Thread.Sleep(1000);


            //Console.WriteLine("在X:{0}, Y:{1} 释放鼠标左键", p.x, p.y);
            mouse_event(MOUSEEVENTF_LEFTUP, p.x, p.y, 0, 0);
            //Console.WriteLine("程序结束，按任意键退出....");
            //Console.ReadKey();
        }

        private void button53_Click(object sender, EventArgs e)
        {
            //移动到 35，30
            JXMouseProtocol.MouseMove(new Point(35,30));JXDateUtil.Wait(1000);
            //右击
            JXMouseProtocol.MouseRightClick(); JXDateUtil.Wait(1000);
            //移动到 90，45
            JXMouseProtocol.MouseMove(new Point(90, 45)); JXDateUtil.Wait(1000);
            //移动到 90，90
            JXMouseProtocol.MouseMove(new Point(90, 90)); JXDateUtil.Wait(1000);
            //左击
            JXMouseProtocol.MouseLeftClick(); JXDateUtil.Wait(1000);

            for(int i = 0; i < 1000; i++)
            {
                JXMouseProtocol.MouseMove(new Point(90, 90));
                JXDateUtil.Wait(10);
            }
        }

        private void button54_Click(object sender, EventArgs e)
        {
            JXKeyProtocol.Test1();
        }

        KeyboardHook k_hook;
        private void button55_Click(object sender, EventArgs e)
        {
            
            k_hook = new KeyboardHook();
            k_hook.KeyDownEvent += new System.Windows.Forms.KeyEventHandler(hook_KeyDown);//钩住键按下 
            k_hook.KeyPressEvent += K_hook_KeyPressEvent;
            k_hook.Start();//安装键盘钩子
        }

        private void K_hook_KeyPressEvent(object sender, KeyPressEventArgs e)
        {
            //tb1.Text += e.KeyChar;
            int i = (int)e.KeyChar;
            //System.Windows.Forms.MessageBox.Show(i.ToString());
            label11.Text = i.ToString() +",\r\n"+ label11.Text;
        }

        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            //tb1.Text += (char)e.KeyData;
            label12.Text = "";
            string str = "";
            if ((int)Control.ModifierKeys == (int)Keys.Alt)
            {
                str = str + "[ALT]按下";
            }
            if ((int)Control.ModifierKeys == (int)Keys.Shift)
            {
                str = str + "[Shift]按下";
            }
            if ((int)Control.ModifierKeys == (int)Keys.Control)
            {
                str = str + "[CTRL]按下";
            }
            label12.Text =  str + "\r\n" + label12.Text;

            //判断按下的键（Alt + A） 
            //if (e.KeyValue == (int)Keys.A && (int)System.Windows.Forms.Control.ModifierKeys == (int)Keys.Alt)
            //{
            //    System.Windows.Forms.MessageBox.Show("ddd");
            //}
        }

        private void button56_Click(object sender, EventArgs e)
        {
            k_hook.Stop();
        }

        private void button57_Click(object sender, EventArgs e)
        {
            string str = @"Y:\$AI_beijing\相关资料\TestDEMO_倪工\826he9604.proj";
            string str1 = JXFilePathUtil.GetDesignatedValue(str, 1);
            string str2 = JXFilePathUtil.GetDesignatedValue(str, 2);
            string str3 = JXFilePathUtil.GetDesignatedValue(str, 3);

        }

        private void button49_Click(object sender, EventArgs e)
        {
            //JXFileUtil.GetFileList(@"Y:\$AI_beijing\相关资料\TestDEMO_倪工");
        }

        private void button58_Click(object sender, EventArgs e)
        {
            throw new JXMessageException("123");
            //DataTable dataTable = JXExcelUtil.ExcelToTable(JXFastPath.ChooseExcelPath("XXX"));
            // DataRow dr = JXDataSelectBox.Show("ssss", dataTable);
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        //private void Window_Unloaded(object sender, RoutedEventArgs e)
        //{
        //    //k_hook.Stop();
        //}
    }

}
