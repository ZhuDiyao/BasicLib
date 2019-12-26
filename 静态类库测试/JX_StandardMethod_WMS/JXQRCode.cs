using JX_StandardLibrary_WMS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThoughtWorks.QRCode.Codec;

namespace JX_StandardMethod_WMS
{
    /// <summary>
    /// 佳轩生成二维码解决方案
    /// </summary>
    public class JXQRCode
    {
        #region 生成二维码
        /// <summary>
        /// 传入参数，文本本信息。生成对应的二维码。
        /// 返回类型为图片；System.Drawing.Bitmap。调用Save方法可以保存为图片。
        /// </summary>
        /// <param name="CodeText"></param>
        /// <returns></returns>
        public static Bitmap GetQRCode(string CodeText)
        {
            System.Drawing.Bitmap bt;
            string enCodeString = CodeText;

            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;//编码方式(注意：BYTE能支持中文，ALPHA_NUMERIC扫描出来的都是数字)
            qrCodeEncoder.QRCodeScale = 4;//大小(值越大生成的二维码图片像素越高)
            qrCodeEncoder.QRCodeVersion = 0;//版本(注意：设置为0主要是防止编码的字符串太长时发生错误)
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;//错误效验、错误更正(有4个等级)
            qrCodeEncoder.QRCodeBackgroundColor = Color.White;//背景色
            qrCodeEncoder.QRCodeForegroundColor = Color.Black;//前景色
            bt = qrCodeEncoder.Encode(enCodeString, Encoding.UTF8);
            return bt;
        }
        #endregion
    }
}
