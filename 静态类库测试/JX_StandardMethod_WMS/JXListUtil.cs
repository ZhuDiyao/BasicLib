using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JX_StandardMethod_WMS
{
    /// <summary>
    /// List操作类
    /// </summary>
    public class JXListUtil
    {
        /// <summary>
        /// Dictionary 不允许key重复，特写此方法。
        /// </summary>
        /// <param name="表"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void 添加值(Dictionary<string, int> 表,string key,int value)
        {
            if (表.ContainsKey(key))
                表[key] = (表[key] + value);
            else
                表.Add(key,value);
        }
        /// <summary>
        /// 此方法一般用于零件对比
        /// 传入两个列表，将两个表中的相同项抵消。
        /// 返回值-1：左表有余，右表有余
        /// 返回值-2：左表有余，右表空
        /// 返回值-3：左表空，右表有余
        /// 返回值1：左表空，右表空
        /// 返回值0：未知情况（预计不存在）
        /// 返回值-4：传入参数有误，值只能为大于0的整数
        /// </summary>
        /// <param name="左表"></param>
        /// <param name="右表"></param>
        /// <returns></returns>
        public static int 列表值校对(Dictionary<string, int> 左表, Dictionary<string, int> 右表)
        {
            //检查参数
            for (int i = 0; i < 左表.Count; i++)
            {
                var item = 左表.ElementAt(i);
                int 值 = item.Value;
                if (值<1)
                    return -4;
            }
            for (int i = 0; i < 右表.Count; i++)
            {
                var item = 右表.ElementAt(i);
                int 值 = item.Value;
                if (值 < 1)
                    return -4;
            }


            //程序主体
            for (int i = 0; i < 左表.Count; i++)
            {
                var item = 左表.ElementAt(i);
                string 左表键 = item.Key;
                int 左表值 = item.Value;
                int k = -1;
                for (k = 左表值; k > 0; k--)
                {
                    bool flag = 查找指定表中是否存在某个键(右表, 左表键);
                    if (!flag)
                    {
                        break;
                    }
                }
                if (k==0)
                {
                    左表.Remove(左表键);
                    i--;
                }
                else
                {
                    左表[左表键] = k;
                }
            }

            //返回结果
            if (左表.Count>0&&右表.Count>0)
            {
                return -1;
            }
            else if(左表.Count > 0 && 右表.Count == 0)
            {
                return -2;
            }
            else if (左表.Count == 0 && 右表.Count > 0)
            {
                return -3;
            }
            else if (左表.Count == 0 && 右表.Count == 0)
            {
                return 1;
            }
            return 0;
        }
        /// <summary>
        /// 在 指定表 中查找 key
        /// 如果 找到，则该 key 的 value 自减1，返回true（自减完成后，若小于等于0，则移除这一行。）
        /// 如果 找不到，返回 false；
        /// </summary>
        /// <param name="指定表"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        private static bool 查找指定表中是否存在某个键(Dictionary<string, int> 指定表,string Key)
        {
            for (int i = 0; i < 指定表.Count; i++)
            {
                var item = 指定表.ElementAt(i);
                string 指定表键 = item.Key;
                int 指定表值 = item.Value;
                指定表值--;
                if (Key.Equals(指定表键))
                {
                    if (指定表值 == 0)
                    {
                        指定表.Remove(指定表键);
                    }
                    else
                    {
                        指定表[指定表键] = 指定表值;
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 将列表转为String，一般用于校对两个列表是否一致【快捷方法】
        /// </summary>
        /// <param name="列表"></param>
        /// <returns></returns>
        public static string ListToString(List<string> 列表)
        {
            string ReturnStr = "";
            try
            {
                for (int i = 0; i < 列表.Count; i++)
                {
                    ReturnStr = ReturnStr + 列表[i];
                }
            }
            catch
            {

            }

            return ReturnStr;
        }


        /// <summary>
        /// 将列表转为String，一般用于校对两个列表是否一致【快捷方法】
        /// </summary>
        /// <param name="列表"></param>
        /// <param name="分隔符号"></param>
        /// <returns></returns>
        public static string ListToString(List<string> 列表,string 分隔符号)
        {
            string ReturnStr = "";
            try
            {
                for (int i = 0; i < 列表.Count; i++)
                {
                    ReturnStr = ReturnStr + 列表[i] + 分隔符号;
                }
            }
            catch
            {

            }
            ReturnStr = ReturnStr.Substring(0, ReturnStr.Length- 分隔符号.Length);
            return ReturnStr;
        }
    }
}
