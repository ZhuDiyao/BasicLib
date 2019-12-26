using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace JX_StandardMethod_WMS
{
    /// <summary>
    /// Json字符串转对象方法
    /// </summary>
    public class JXJsonToObjetc
    {
        /// <summary>
        /// 将JSON格式的字符串传入，返回的结果为对象。请注意：如果JSON格式字符串不符合标准，将发生异常。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T JsonToObjetc<T>(string jsonString)
        {
            JavaScriptSerializer json = new JavaScriptSerializer();
            return json.Deserialize<T>(jsonString);
        }

        /// <summary>
        /// 把对象转换为JSON字符串
        /// </summary>
        /// <param name="o">对象</param>
        /// <returns>JSON字符串</returns>
        public static string ToJSON(object o)
        {
            if (o == null)
            {
                return null;
            }
            return JsonConvert.SerializeObject(o);
        }
        /// <summary>
        /// 把Json文本转为实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T FromJSON<T>(string input)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(input);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
