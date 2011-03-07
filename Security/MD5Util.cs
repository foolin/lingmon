using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Utility.Security
{
    /// <summary>
    /// MD5相关函数
    /// </summary>
    public class MD5Util
    {
        /// <summary>
        /// 取MD5加密字符
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetMd5Hash(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        /// <summary>
        //校验MD5
        /// </summary>
        /// <param name="input"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool VerifyMd5Hash(string input, string hash)
        {
            string hashOfInput = GetMd5Hash(input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// MD5加密,　code: 16位　或 32位
        /// </summary>
        /// <param name="str"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string ToMD5(string str, int code)
        {
            if (code == 16) //16位MD5加密（取32位加密的9~25字符） 
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower().Substring(8, 16);
            }
            else//32位加密 
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
            }
        }




        /// <summary>
        /// 生成HmacMD5。value=要生成字符串，password=密钥
        /// </summary>
        /// <param name="value">要生成字符串</param>
        /// <param name="password">密钥</param>
        /// <returns></returns>
        public static string HmacMD5(string value, string password)
        {
            byte[] b_tmp;
            byte[] b_tmp1;
            if (password == null)
            {
                return null;
            }
            byte[] digest = new byte[512];
            byte[] k_ipad = new byte[64];
            byte[] k_opad = new byte[64];
            byte[] source = System.Text.ASCIIEncoding.ASCII.GetBytes(password);
            System.Security.Cryptography.MD5 shainner = new MD5CryptoServiceProvider();
            for (int i = 0; i < 64; i++)
            {
                k_ipad[i] = 0 ^ 0x36;
                k_opad[i] = 0 ^ 0x5c;
            }

            try
            {
                if (source.Length > 64)
                {
                    shainner = new MD5CryptoServiceProvider();
                    source = shainner.ComputeHash(source);
                }
                for (int i = 0; i < source.Length; i++)
                {
                    k_ipad[i] = (byte)(source[i] ^ 0x36);
                    k_opad[i] = (byte)(source[i] ^ 0x5c);
                }
                b_tmp1 = System.Text.ASCIIEncoding.ASCII.GetBytes(value);
                b_tmp = Adding(k_ipad, b_tmp1);
                shainner = new MD5CryptoServiceProvider();
                digest = shainner.ComputeHash(b_tmp);
                b_tmp = Adding(k_opad, digest);
                shainner = new MD5CryptoServiceProvider();
                digest = shainner.ComputeHash(b_tmp);
                return ByteToString(digest);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <param name="buff"></param>
        /// <returns></returns>
        private static string ByteToString(byte[] buff)
        {
            string sbinary = "";

            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2"); // hex format
            }
            return (sbinary);
        }


        /**
        *
        *  填充byte
        * 
        */
        private static byte[] Adding(byte[] a, byte[] b)
        {
            byte[] c = new byte[a.Length + b.Length];
            a.CopyTo(c, 0);
            b.CopyTo(c, a.Length);
            return c;
        }


    }
}
