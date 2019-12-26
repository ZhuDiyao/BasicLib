using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace JX_StandardMethod_WMS
{
    /// <summary>
    /// 佳轩邮件发送工具类
    /// </summary>
    public class JXEmailUtil
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <returns></returns>
        public static string Send(string 收件人)
        {
            return Send(收件人, "佳轩系统邮件自动发送接口", "调用佳轩系统邮件自动发送接口成功", null);
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <returns></returns>
        public static string Send(string 收件人, string 消息标题, string 消息内容)
        {
            return Send(收件人,消息标题,消息内容,null);
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <returns></returns>
        public static string Send(string 收件人, string 消息标题, string 消息内容, List<string> 附件文件路径)
        {
            try
            {
                MailAddress from = new MailAddress("jxhomesystem@163.com");
                MailMessage newMailMessage = new MailMessage();
                newMailMessage.From = from;
                newMailMessage.To.Add(new MailAddress(收件人));
                newMailMessage.Subject = 消息标题 + "_来自佳轩系统服务";
                newMailMessage.Body = 消息内容;
                SmtpClient newclient = new SmtpClient("smtp.163.com");
                newclient.UseDefaultCredentials = false;
                newclient.Credentials = new System.Net.NetworkCredential("jxhomesystem@163.com", "sqm123");
                newclient.DeliveryMethod = SmtpDeliveryMethod.Network;
                if (附件文件路径 != null) for (int i = 0; i < 附件文件路径.Count; i++) newMailMessage.Attachments.Add(new Attachment(附件文件路径[i]));
                newMailMessage.Priority = MailPriority.High; 
                newclient.Send(newMailMessage);
                return "success";
            }
            catch (Exception ex)
            {
                return "error:" + ex.ToString();
            }
        }
    }
}
