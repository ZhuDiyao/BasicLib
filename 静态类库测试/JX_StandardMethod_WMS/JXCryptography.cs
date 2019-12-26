using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JX_StandardMethod_WMS
{
    /// <summary>
    /// 密码类
    /// </summary>
    public class JXCryptography
    {
        /// <summary>
        /// 传入一个字符串，将传入字符串进行MD5加密后返回。返回结果是32位大写的字符串，包含数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMD5(string str)
        {
            byte[] result = Encoding.UTF8.GetBytes(str);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string returnStr = BitConverter.ToString(output).Replace("-", "");
            return returnStr;
        }

        /// <summary>
        /// 获取U码。长度固定50位。
        /// 一般用于生成订单号之类的。
        /// 每次调用，返回的值都是不一样的（随时间改变）。
        /// 返回的格式为 【U】【重要内容的MD5值32位】【当前时间yyyyMMddHHmmssfff】
        /// 传入参数【重要内容】，返回系统唯一码。
        /// 示例：UBEFF61979BF761D186ADC6FAF412D4E620190512084735489
        /// </summary>
        /// <param name="Significantcontent"></param>
        /// <returns></returns>
        public static string GetSystemUniqueCode(string Significantcontent)
        {
            string TimeStr = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            return "U" + GetMD5(Significantcontent + TimeStr + "#JXWMS") + TimeStr;
        }
        /// <summary>
        /// 获取简版U码。长度固定25位。
        /// </summary>
        /// <param name="Significantcontent"></param>
        /// <returns></returns>
        public static string GetSystemUniqueCode_Simple(string Significantcontent)
        {
            string TimeStr = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            return ("U" + TimeStr + GetMD5(Significantcontent + TimeStr + "#JXWMS").Substring(0, 7)).Replace("4","G");
        }


    }
}
