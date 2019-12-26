using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JX_StandardMethod_WMS
{
    /// <summary>
    /// 可以实现设置密码，然后对字符串进行加密和解密。
    /// 20190730
    /// 诸迪耀：这个方法可以实现加密和解密，但不好用。主流使用【公钥】加密。使用【私钥】解密。
    /// </summary>
    public class JXCryptography4RSA_NoKey
    {
        /// <summary>
        /// RSA加密解密钥匙
        /// </summary>
        private static string RSAKey = "oa_erp_doworkoa_erp_doworkoa_erp_doworkoa_erp_doworkoa_erp_doworkoa_erp_doworkoa_erp_dowork";

        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        public static string Encryption(string express)
        {
            try
            {
                CspParameters param = new CspParameters();
                param.KeyContainerName = RSAKey;//密匙容器的名称，保持加密解密一致才能解密成功
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
                {
                    byte[] plaindata = Encoding.Default.GetBytes(express);//将要加密的字符串转换为字节数组
                    byte[] encryptdata = rsa.Encrypt(plaindata, false);//将加密后的字节数据转换为新的加密字节数组
                    return Convert.ToBase64String(encryptdata);//将加密后的字节数组转换为字符串
                }
            }
            catch
            {
                return "加密失败";
            }

        }

        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <returns></returns>
        public static string Decrypt(string ciphertext)
        {
            try
            {
                CspParameters param = new CspParameters();
                param.KeyContainerName = RSAKey;
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
                {
                    byte[] encryptdata = Convert.FromBase64String(ciphertext);
                    byte[] decryptdata = rsa.Decrypt(encryptdata, false);
                    return Encoding.Default.GetString(decryptdata);
                }
            }
            catch
            {
                return "解密失败";
            }

        }
    }
}
