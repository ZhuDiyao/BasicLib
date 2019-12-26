using System;
using System.Security.Cryptography;
using System.Text;

namespace JX_StandardMethod_WMS
{
    /// <summary>
    /// 佳轩RSA密码类
    /// </summary>
    public class JXCryptography4RSA
    {
        /// <summary>
        /// 公钥，用于加密
        /// </summary>
        public static string PublicKey = "公钥，用于加密";
        /// <summary>
        /// 私钥，用于解密
        /// </summary>
        public static string PrivateKey = "私钥，用于解密";
        /// <summary>
        /// 用于生成RSA公私钥对。
        /// 用这种方式生成出来的公钥和私钥是 XML格式的。
        /// </summary>
        public static void GenerateRSASecretKey()
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024))
            {
                PublicKey = rsa.ToXmlString(false);
                PrivateKey = rsa.ToXmlString(true);
            }
        }
        /// <summary>
        /// 传入【XML公钥】【待加密内容】，返回加密后内容。
        /// </summary>
        /// <param name="xmlPublicKey"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RSAEncrypt(string xmlPublicKey, string content)
        {
            try
            {
                string encryptedContent = string.Empty;
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(xmlPublicKey);
                    byte[] encryptedData = rsa.Encrypt(Encoding.Default.GetBytes(content), false);
                    encryptedContent = Convert.ToBase64String(encryptedData);
                }
                return encryptedContent;
            }
            catch
            {
                return "加密失败";
            }
        }
        /// <summary>
        /// 传入【XML私钥】【待解密内容】，返回解密后内容。
        /// </summary>
        /// <param name="xmlPrivateKey"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RSADecrypt(string xmlPrivateKey, string content)
        {
            try
            {
                string decryptedContent = string.Empty;
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(xmlPrivateKey);
                    byte[] decryptedData = rsa.Decrypt(Convert.FromBase64String(content), false);
                    decryptedContent = Encoding.GetEncoding("utf-8").GetString(decryptedData);
                }
                return decryptedContent;
            }
            catch
            {
                return "解密失败";
            }
        }

        /// <summary>
        /// 传入【XML公钥】【待加密内容】，返回加密后内容。
        /// </summary>
        /// <param name="PublicKey"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RSAEncrypt4Base64(string PublicKey, string content)
        {
            try
            {
                string xmlPublicKey = "";
                xmlPublicKey = JXCryptography4RSA_XML_BASE64.ToXmlPublicKey(PublicKey);
                return RSAEncrypt(xmlPublicKey, content);
            }
            catch
            {
                return "公钥转换失败";
            }
        }

        /// <summary>
        /// 传入【Base64私钥】【待解密内容】，返回解密后内容。
        /// 一般用于 接收 java的密文
        /// </summary>
        /// <param name="PrivateKey"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RSADecrypt4Base64(string PrivateKey,string content)
        {
            try
            {
                string xmlPrivateKey = "";
                xmlPrivateKey = JXCryptography4RSA_XML_BASE64.ToXmlPrivateKey(PrivateKey);
                return RSADecrypt(xmlPrivateKey, content);
            }
            catch
            {
                return "私钥转换失败";
            }
        }
    }
}
