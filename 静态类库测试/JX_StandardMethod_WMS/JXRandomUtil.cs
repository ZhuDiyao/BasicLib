using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JX_StandardMethod_WMS
{
    /// <summary>
    /// 佳轩随机数工具类
    /// </summary>
    public class JXRandomUtil
    {
        /// <summary>
        /// 请注意，连续无延时调用，得到的随机数会相同。
        /// 获取一个随机正整数 [0,MaxNumber)
        /// </summary>
        /// <param name="MaxNumber">得到的随机数不会超过该值</param>
        /// <returns></returns>
        public static int GetRandomNumber(int MaxNumber)
        {
            Random rd = new Random();
            int i = rd.Next();
            return i% MaxNumber;
        }

        /// <summary>
        /// 请注意【RandomList】中，每个字符后面都要加空格，并且只能加1个空格
        /// 
        /// 获取一个随机字符串
        /// </summary>
        /// <param name="RandomList">【随机字符串列表,以空格区分（随机得到的来源于此）】</param>
        /// <param name="Length">需要一个多长的字符串</param>
        /// <returns></returns>
        public static string GetRandomString(string RandomList,int Length)
        {
            RandomList = RandomList.Trim();
            string[] sArray = RandomList.Split(' ');
            string rstr = "";
            string lsstr = "";
            for (int i=0;i< Length;i++)
            {
                string nowstr = sArray[GetRandomNumber(sArray.Length)];
                if (lsstr.Equals(nowstr))
                {
                    i--;
                }
                else
                {
                    rstr = rstr + nowstr;
                    lsstr = nowstr;
                }
            }
            return rstr;
        }
    }
}
