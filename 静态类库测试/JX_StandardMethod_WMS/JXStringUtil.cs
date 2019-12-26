using NPinyin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JX_StandardMethod_WMS
{
    /// <summary>
    /// 字符串补充操作（对C#已有的字符串操作工具类进行补充）工具类
    /// </summary>
    public class JXStringUtil
    {
        /// <summary>
        /// 字符串转字节数组UTF-8格式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] StringToByteArray(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        /// <summary>
        /// 字节数组转stringUTF-8格式
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ByteArrayToString(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes).Trim();
        }

        /// <summary>
        /// 清理字符串
        /// 请注意，此方法可能删除数据中的有效信息。
        /// 字符串中的
        /// 【\b】【\f】【\n】【\r】【\t】【\v】【\0】
        /// 将会被删除
        /// </summary>
        /// <param name="NeedClearString"></param>
        /// <returns></returns>
        public static string InvalidClear(string NeedClearString)
        {
            return NeedClearString
                    .Replace("\b", "")
                    .Replace("\f", "")
                    .Replace("\n", "")
                    .Replace("\r", "")
                    .Replace("\t", "")
                    .Replace("\v", "")
                    .Replace("\0", "")
                ;
        }
        /// <summary>
        /// 传入字符串，判断字符串的最后一位是否未数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool LastCharIsNumber(string str)
        {

            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] byteeee = ascii.GetBytes(str);
            if (byteeee[byteeee.Length-1] <48 || byteeee[byteeee.Length - 1] >57)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        /// <summary>
        /// 判断这个字符串是不是纯数字，如果是（返回true）,如果不是（返回false）
        /// 传入一个字符串，返回对这个字符串的判断。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumer(string str)
        {
            if (str == null || str.Length == 0)    //验证这个参数是否为空
                return false;                           //是，就返回False
            ASCIIEncoding ascii = new ASCIIEncoding();//new ASCIIEncoding 的实例
            byte[] bytestr = ascii.GetBytes(str);         //把string类型的参数保存到数组里
            foreach (byte c in bytestr)                   //遍历这个数组里的内容
            {
                if (c < 48 || c > 57)                          //判断是否为数字
                {
                    return false;                              //不是，就返回False
                }
            }
            return true;
        }
        /// <summary>
        /// 将 
        /// 传入 的字符串 转换为 int类型的值.
        /// 传入 字符串必须是 正整数，否则返回0.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToNumber(string str)
        {
            if (IsNumer(str))return int.Parse(str);return 0;
        }

        /// <summary>
        /// 将中文字符转换为汉语拼音的基础方法
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string To(string str) => Pinyin.GetPinyin(str);

        /// <summary>
        /// 在【转换等级】为【0】时，【诸迪耀】的返回值为【zhu di yao】
        /// 在【转换等级】为【1】时，【诸迪耀】的返回值为【zhudiyao】
        /// 在【转换等级】为【2】时，【诸迪耀】的返回值为【zdy】
        /// 在【转换等级】为【3】时，【诸迪耀】的返回值为【ZDY】 暂时没有实现
        /// 在【转换等级】为【4】时，【诸迪耀】的返回值为【Zhu Di Yao】暂时没有实现
        /// 在【转换等级】为【5】时，【诸迪耀】的返回值为【ZhuDiYao】暂时没有实现
        /// 在【转换等级】为【6】时，【诸迪耀】的返回值为【ZhuDiyao】暂时没有实现
        /// 在【转换等级】为【7】时，【诸迪耀】的返回值为【Zdy】暂时没有实现
        /// </summary>
        /// <param name="Chinese">需要转换为汉语拼音的中文</param>
        /// <param name="level">转换等级</param>
        /// <returns></returns>
        public static string ChineseToChinesePinyin(string Chinese,int level)
        {
            switch (level)
            {
                case 0:
                    {
                        string RETRURNSTR = Pinyin.GetPinyin(Chinese);
                        return RETRURNSTR;
                    }
                case 1:
                    {
                        string RETRURNSTR = Pinyin.GetPinyin(Chinese);
                        return RETRURNSTR.Replace(" ", "");
                    }
                case 2:
                    {
                        string RETRURNSTR = Pinyin.GetPinyin(Chinese);
                        string str = RETRURNSTR;
                        string returnStr = "";
                        while (str.IndexOf(" ") != -1)
                        {
                            str = str.Trim();
                            returnStr += str.Substring(0, 1);
                            int spacePonit = str.IndexOf(" ");
                            if (spacePonit == -1) spacePonit = 0;
                            str = str.Substring(spacePonit, str.Length - spacePonit);
                        }
                        return returnStr;
                    }
                default:
                    {
                        return "error";
                    }

            }
        }

        /// <summary>
        /// 截取字符串【源字符串】【起始标记】【结束标记】，返回内容为：从【源字符串】中截取【起始标记】到【结束标记】中间的字符串。
        /// 如果截取不到，则返回null
        /// </summary>
        /// <param name="SourceStr"></param>
        /// <param name="StartStr"></param>
        /// <param name="EndStr"></param>
        /// <returns></returns>
        public static string SubStringSenior(string SourceStr,string StartStr,string EndStr)
        {
            if (SourceStr == null || StartStr == null || EndStr == null)
            {
                return null;
            }
            int StartStrIndex = SourceStr.IndexOf(StartStr);
            int EndStrIndex = SourceStr.IndexOf(EndStr);
            if (StartStrIndex == -1)
            {
                return null;
            }
            if (EndStrIndex == -1)
            {
                return null;
            }
            if (StartStrIndex> EndStrIndex)
            {
                return null;
            }
            try
            {
                return SourceStr.Substring(StartStrIndex + StartStr.Length, EndStrIndex - StartStrIndex - StartStr.Length);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 截取字符串【源字符串】【起始标记】【结束标记】，返回内容为：
        /// 先从【源字符串】中截取【起始标记】开始的字符串。赋值给【源字符串】
        /// 再从【源字符串】中截取【结束标记】开始的字符串。
        /// </summary>
        /// <param name="SourceStr"></param>
        /// <param name="StartStr"></param>
        /// <param name="EndStr"></param>
        /// <returns></returns>
        public static string SubStringSeniorBody(string SourceStr, string StartStr, string EndStr)
        {
            if (SourceStr == null || StartStr == null || EndStr == null)
            {
                return null;
            }
            int StartStrIndex = SourceStr.IndexOf(StartStr);
            int EndStrIndex = SourceStr.IndexOf(EndStr);
            if (StartStrIndex == -1)
            {
                return null;
            }
            if (EndStrIndex == -1)
            {
                return null;
            }
            if (StartStrIndex > EndStrIndex)
            {
                return null;
            }
            try
            {
                SourceStr = SourceStr.Substring(SourceStr.IndexOf(StartStr) + StartStr.Length);
                SourceStr = SourceStr.Substring(SourceStr.IndexOf(EndStr) + EndStr.Length);
            }
            catch
            {
                return null;
            }
            return SourceStr;
        }

        /// <summary>
        /// 在源字符串中从后向前找，截取目标开始到字符串结束的内容。
        /// </summary>
        /// <param name="SourceStr"></param>
        /// <param name="StringSign"></param>
        /// <returns></returns>
        public static string SubStringSenior(string SourceStr,string StringSign)
        {

            try
            {
                int lastindex = SourceStr.LastIndexOf(StringSign);
                string returnstr = SourceStr.Substring(lastindex + StringSign.Length);
                return returnstr.Trim();
            }
            catch
            {
                return SourceStr.Trim();
            }
        }
        /// <summary>
        /// 示例参数 【AAAAAAA】【2】
        /// 返回的结果 【A2A2A2A2A2A2A】
        /// </summary>
        /// <param name="SourceStr"></param>
        /// <param name="SonStr"></param>
        /// <returns></returns>
        public static string InsertSonString(string SourceStr,string SonStr)
        {
            int index = 1;
            index = index - SonStr.Length;
            while(true)
            {
                index = index + SonStr.Length;
                if (index >= SourceStr.Length)
                    break;
                SourceStr = SourceStr.Insert(index, SonStr);
                index = index + 1;
            }
            return SourceStr.Trim();
        }
    }
}
