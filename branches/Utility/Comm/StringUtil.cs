using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Drawing;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

namespace Utility.Comm
{
    /// <summary>
    /// 对一些字符串进行操作的类
    /// 创建时间：2006-8-3
    /// 创建者：gi
    /// </summary>
    public class StringUtil
    {
        private static string passWord;	//加密字符串

        /// <summary>
        /// 判断输入是否数字
        /// </summary>
        /// <param name="num">要判断的字符串</param>
        /// <returns></returns>
        static public bool VldInt(string num)
        {
            #region
            try
            {
                Convert.ToInt32(num);
                return true;
            }
            catch { return false; }
            #endregion
        }

        /// <summary>
        /// 返回文本编辑器替换后的字符串
        /// </summary>
        /// <param name="str">要替换的字符串</param>
        /// <returns></returns>
        static public string GetHtmlEditReplace(string str)
        {
            #region
            //return str.Replace("'", "''").Replace("&nbsp;", " ").Replace(",", "，").Replace("%", "％").Replace("script","").Replace(".js","");
            string[] strReplace = { "script", ".js" };
            string strTemp = str.ToLower();
            for (int i = 0; i < strReplace.Length; i++)
            {
                while (strTemp.IndexOf(strReplace[i]) > 0)
                {
                    str = str.Remove(strTemp.IndexOf(strReplace[i]), strReplace[i].Length);
                    strTemp = str.ToLower();
                }
            }
            return str;
            #endregion
        }

        /// <summary>
        /// 过滤SQL语句所需参数
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public static string FilterSQLParam(string strParam)
        {
            if (strParam == null | strParam.Length == 0)
                return "";
            else
                return strParam.Replace("'", "''");
        }

        /// <summary>
        /// 把字符串转换成符合javascript的样式
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static string ProcessStr(string Str)
        {
            if (Str + "" != "")
            {
                Str = Str.ToLower().Replace("<p>?</p>", "<p>&nbsp;</p>");
                Str = Str.Replace("\\", "\\\\");
                Str = Str.Replace("'", "\\'");
                Str = Str.Replace("\"", "\\\"");
                Str = Regex.Replace(Str, "(\\r\\n)", "\\n");
            }
            return Str;
        }

        /// <summary>
        /// 截取字符串函数
        /// </summary>
        /// <param name="str">所要截取的字符串</param>
        /// <param name="num">截取字符串的长度</param>
        /// <returns></returns>
        static public string GetSubString(string str, int num)
        {
            #region
            return (str.Length > num) ? str.Substring(0, num) + "..." : str;
            #endregion
        }

        /// <summary>
        /// 根据字节数截取字符串
        /// </summary>
        /// <param name="str">所要截取的字符串</param>
        /// <param name="num">截取的字节数</param>
        /// <param name="point">是否显示"..."</param>
        /// <returns></returns>
        static public string SubStringByByte(string str, int num, bool point)
        {
            #region
            int length = Encoding.Default.GetByteCount(str);
            if (num >= length) return str;

            int i = 0, j = 0;
            for (int x = 0; x < str.Length; x++)
            {
                j += Encoding.Default.GetByteCount(str.Substring(x, 1));
                i += 1;
                if (j > num)
                {
                    str = str.Substring(0, i - 1);
                    break;
                }
                if (j == num)
                {
                    str = str.Substring(0, i);
                    break;
                }
            }

            if (point)
                str += "...";
            return str;
            #endregion
        }

        /// <summary>
        /// 根据字节数截取字符串
        /// </summary>
        /// <param name="str">所要截取的字符串</param>
        /// <param name="num">截取的字节数</param>
        /// <returns></returns>
        static public string SubStringByByte(string str, int num)
        {
            #region
            return StringUtil.SubStringByByte(str, num, false);
            #endregion
        }

        /// <summary>
        /// 对字符串进行HTML编码
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>编码后的字符串</returns>
        static public string HtmlEncode(string str)
        {
            if (str + "" != "")
                return System.Web.HttpContext.Current.Server.HtmlEncode(str);
            else
                return str;
        }

        /// <summary>
        /// 过滤输入信息
        /// </summary>
        /// <param name="text">内容</param>
        /// <param name="maxLength">最大长度</param>
        /// <returns></returns>
        public static string InputText(string text, int maxLength)
        {
            #region
            text = text.Trim();
            try
            {

                if (string.IsNullOrEmpty(text))
                    return string.Empty;
                if (text.Length > maxLength)
                    text = text.Substring(0, maxLength);
                text = Regex.Replace(text, "[\\s]{2,}", " ");	//two or more spaces
                text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");	//<br>
                text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");	//&nbsp;
                text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty);	//any other tags
                text = text.Replace("'", "''");
            }
            catch (Exception)
            {
                throw;
            }
            return text;
            #endregion
        }

        /// <summary>
        /// 过滤搜索输入的信息
        /// </summary>
        /// <param name="text">内容</param>
        /// <returns></returns>
        public static string InputTextForSearch(string text)
        {
            #region
            text = text.Trim();
            try
            {
                if (string.IsNullOrEmpty(text))
                    return string.Empty;
                text = Regex.Replace(text, "[\\s]{2,}", " ");	//two or more spaces
                text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");	//<br>
                text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");	//&nbsp;
                text = Regex.Replace(text, "[<|(|.|。|,|，|\\||\\n|)|*|?|？|>]", string.Empty);	//any other tags---ming add
                text = text.Replace("'", "''");
            }
            catch (Exception)
            {
                throw;
            }
            return text;
            #endregion
        }

        /// <summary>
        /// 检验输入信息
        /// </summary>
        /// <param name="text">内容</param>
        /// <returns></returns>
        public static bool CheckInput(string text)
        {
            #region
            try
            {
                text = text.Trim();
                if (Regex.IsMatch(text, "[\\s]{2,}"))
                    return false;//two or more spaces
                if (Regex.IsMatch(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)"))
                    return false;//<br>
                if (Regex.IsMatch(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+"))
                    return false;//&nbsp;
                if (Regex.IsMatch(text, "<(.|\\n)*?>"))
                    return false;//any other tags
            }
            catch (Exception)
            {
                return false; ;
            }
            return true;
            #endregion
        }

        /// <summary>
        /// 生成随机数
        /// </summary>
        /// <param name="Length">随机数长度</param>
        /// <returns></returns>
        public static string GenerateCode(int Length)
        {
            #region
            int number;
            char code;
            string checkCode = String.Empty;

            System.Random random = new Random();

            for (int i = 0; i < Length; i++)
            {
                number = random.Next();

                if (number % 2 == 0)
                    code = (char)('0' + (char)(number % 10));
                else
                    code = (char)('A' + (char)(number % 26));

                checkCode += code.ToString();
            }

            return checkCode;
            #endregion
        }



        
        /// <summary>
        /// 获取汉字转换成拼音
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ConvertToSpell(string chrstr)
        {
            #region
            byte[] array = new byte[2];
            string returnstr = "";
            int chrasc = 0;
            int i1 = 0;
            int i2 = 0;
            char[] nowchar = chrstr.ToCharArray();
            for (int j = 0; j < nowchar.Length; j++)
            {
                array = System.Text.Encoding.Default.GetBytes(nowchar[j].ToString());
                i1 = (short)(array[0]);
                i2 = (short)(array[1]);

                chrasc = i1 * 256 + i2 - 65536;
                if (chrasc > 0 && chrasc < 160)
                {
                    returnstr += nowchar[j];
                }
                else
                {
                    for (int i = (pyvalue.Length - 1); i >= 0; i--)
                    {
                        if (pyvalue[i] <= chrasc)
                        {
                            returnstr += pystr[i];
                            break;
                        }
                    }
                }
            }
            return returnstr;
            #endregion
        }


        /// <summary>
        /// 半角转全角
        /// </summary>
        /// <param name="BJstr"></param>
        /// <returns></returns>
        static public string GetQuanJiao(string BJstr)
        {
            #region
            char[] c = BJstr.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                byte[] b = System.Text.Encoding.Unicode.GetBytes(c, i, 1);
                if (b.Length == 2)
                {
                    if (b[1] == 0)
                    {
                        b[0] = (byte)(b[0] - 32);
                        b[1] = 255;
                        c[i] = System.Text.Encoding.Unicode.GetChars(b)[0];
                    }
                }
            }

            string strNew = new string(c);
            return strNew;

            #endregion
        }

        /// <summary>
        /// 全角转半角
        /// </summary>
        /// <param name="QJstr"></param>
        /// <returns></returns>
        static public string GetBanJiao(string QJstr)
        {
            #region
            char[] c = QJstr.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                byte[] b = System.Text.Encoding.Unicode.GetBytes(c, i, 1);
                if (b.Length == 2)
                {
                    if (b[1] == 255)
                    {
                        b[0] = (byte)(b[0] + 32);
                        b[1] = 0;
                        c[i] = System.Text.Encoding.Unicode.GetChars(b)[0];
                    }
                }
            }
            string strNew = new string(c);
            return strNew;
            #endregion
        }

        #region 加密的类型
        /// <summary>
        /// 加密的类型
        /// </summary>
        public enum PasswordType
        {
            SHA1,
            MD5
        }
        #endregion


        /// <summary>
        /// 字符串加密
        /// </summary>
        /// <param name="PasswordString">要加密的字符串</param>
        /// <param name="PasswordFormat">要加密的类别</param>
        /// <returns></returns>
        static public string EncryptPassword(string PasswordString, string PasswordFormat)
        {
            #region
            switch (PasswordFormat)
            {
                case "SHA1":
                    {
                        passWord = FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordString, "SHA1");
                        break;
                    }
                case "MD5":
                    {
                        passWord = FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordString, "MD5");
                        break;
                    }
                default:
                    {
                        passWord = string.Empty;
                        break;
                    }
            }
            return passWord;
            #endregion
        }

        /// <summary>
        /// 获取CheckBox控键的值
        /// </summary>
        /// <param name="chk">CheckBox控键</param>
        /// <returns>CheckBox控键的值</returns>
        public static int GetCheckBoxValue(CheckBox chk)
        {
            if (chk.Checked == true)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// 设置CheckBox控键的选择状态
        /// </summary>
        /// <param name="chk">CheckBox控键</param>
        /// <param name="IsChecked">是否选择</param>
        public static void SetCheckBoxChecked(CheckBox chk, int IsChecked)
        {
            if (IsChecked == 0)
                chk.Checked = false;
            else
                chk.Checked = true;
        }

        /// <summary> 
        /// 利用DES加密一个字符串 
        /// </summary> 
        /// <param name="pToEncrypt">要加密的字符串</param> 
        /// <param name="sKey">密钥</param> 
        /// <returns>密文</returns> 
        public static string DESEncrypt(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            //将字符串转化为一个byte数组 
            byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);

            //Create the crypto objects, with the key, as passed in 
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(),
            CryptoStreamMode.Write);
            //Write the byte array into the crypto stream 
            //(It will end up in the memory stream) 
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            //Get the data back from the memory stream, and into a string 
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                //Format as hex 
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        /// <summary> 
        /// 解密一个字符串 
        /// </summary> 
        /// <param name="pToDecrypt">密文</param> 
        /// <param name="sKey">密钥</param> 
        /// <returns>明文</returns> 
        public static string DESDecrypt(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            //Put the input string into the byte array 
            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            //Create the crypto objects 
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(),
            CryptoStreamMode.Write);
            //Flush the data through the crypto stream into the memory stream 
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            //Get the decrypted data back from the memory stream 
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.Append((char)b);
            }
            return ret.ToString();
        }

        /// <summary>
        /// 判断用户名是否符合要求
        /// </summary>
        /// <param name="strUserName">测试字符串</param>
        /// <returns></returns>
        public static int IsRightUserName(string strUserName)
        {
            if (!Regex.IsMatch(strUserName, "^[a-zA-Z0-9]") || !Regex.IsMatch(strUserName, "[a-zA-Z0-9]$"))
                return 1;//begin and end with number or letter
            else if (!Regex.IsMatch(strUserName, "^([0-9a-zA-Z]+[_.0-9a-zA-Z-]*[0-9a-zA-Z_.]+)$"))
                return 2;//the string must be number, letter or signal that ".-_"
            else
                return 0;
        }

        /// <summary>
        /// 判断字符串是否包含中文
        /// </summary>
        /// <param name="CString">测试字符串</param>
        /// <returns></returns>
        public static bool IsChina(string CString)
        {
            bool BoolValue = false;
            for (int i = 0; i < CString.Length; i++)
            {
                if (Convert.ToInt32(Convert.ToChar(CString.Substring(i, 1))) < Convert.ToInt32(Convert.ToChar(128)))
                {
                    BoolValue = false;
                }
                else
                {
                    return BoolValue = true;
                }
            }
            return BoolValue;
        }

        /// <summary>
        /// 验证EMAIL地址
        /// </summary>
        /// <param name="email">email地址</param>
        /// <returns></returns>
        public static bool IsEmail(string email)
        {
            if (email.Length > 100)
            {
                return false;
            }
            string Mails = "^(([0-9a-zA-Z_.]+)|([0-9a-zA-Z]+[_.0-9a-zA-Z-]*[0-9a-zA-Z_.]+))@([a-zA-Z0-9-]+[.])+([a-zA-Z]{2}|net|NET|com|COM|gov|GOV|mil|MIL|org|ORG|edu|EDU|int|INT)$";
            return Regex.IsMatch(email, Mails);
        }


        /// <summary>
        /// 去掉HTML标签
        /// </summary>
        /// <param name="Htmlstring">带HTML标签的字符串</param>
        /// <returns>无HTML标签的字符串</returns>
        public static string ClearHTML(string Htmlstring)
        {
            //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML   
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring = Htmlstring.Replace("<", "");
            Htmlstring = Htmlstring.Replace(">", "");


            return Htmlstring;
        }


        /// <summary>
        /// 将字节数组转换为进六制显示的字符串
        /// </summary>
        /// <param name="InBytes"></param>
        /// <returns></returns>
        public static string ByteToString(byte[] InBytes)
        {
            string StringOut = "";
            foreach (byte InByte in InBytes)
            {
                StringOut = StringOut + String.Format("\\x{0:X2}", InByte) + " ";
            }

            return StringOut.Trim().Replace(" ", "");
        }


        /// <summary>
        /// 判断ip地址格式是否正确
        /// </summary>
        /// <param name="ip">ip地址</param>
        /// <returns></returns>
        public bool IsIPAddress(string ip)
        {
            if (ip == null || ip == string.Empty || ip.Length < 7 || ip.Length > 15) return false;

            string regformat = @"^\d{1,3}[\.]\d{1,3}[\.]\d{1,3}[\.]\d{1,3}$";

            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);
            return regex.IsMatch(ip);

        }


        /// <summary>
        /// 字符串转整型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int StrToInt(string str, int num)
        {
            if (string.IsNullOrEmpty(str))
            {
                return num;
            }
            else
            {
                return int.Parse(str);
            }
        }

        /// <summary>
        /// 字符串转长整型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static long StrToLong(string str, long num)
        {
            if (string.IsNullOrEmpty(str))
            {
                return num;
            }
            else
            {
                return long.Parse(str);
            }
        }

        /// <summary>
        /// 处理字符串,过滤SQL注入危险
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string DealStr(string str, int length)
        {
            if (!string.IsNullOrEmpty(str))
            {
                if (str.Length > length)
                {
                    str = str.Substring(0, length);
                }
                str = str.Replace("'", "''");
                return str.Trim();
            }
            else
            {
                return "";
            }
        }


        #region 中文转拼音对应表
        private static int[] pyvalue = new int[]{-20319,-20317,-20304,-20295,-20292,-20283,-20265,-20257,-20242,-20230,-20051,-20036,-20032,-20026,
    -20002,-19990,-19986,-19982,-19976,-19805,-19784,-19775,-19774,-19763,-19756,-19751,-19746,-19741,-19739,-19728,
    -19725,-19715,-19540,-19531,-19525,-19515,-19500,-19484,-19479,-19467,-19289,-19288,-19281,-19275,-19270,-19263,
    -19261,-19249,-19243,-19242,-19238,-19235,-19227,-19224,-19218,-19212,-19038,-19023,-19018,-19006,-19003,-18996,
    -18977,-18961,-18952,-18783,-18774,-18773,-18763,-18756,-18741,-18735,-18731,-18722,-18710,-18697,-18696,-18526,
    -18518,-18501,-18490,-18478,-18463,-18448,-18447,-18446,-18239,-18237,-18231,-18220,-18211,-18201,-18184,-18183,
    -18181,-18012,-17997,-17988,-17970,-17964,-17961,-17950,-17947,-17931,-17928,-17922,-17759,-17752,-17733,-17730,
    -17721,-17703,-17701,-17697,-17692,-17683,-17676,-17496,-17487,-17482,-17468,-17454,-17433,-17427,-17417,-17202,
    -17185,-16983,-16970,-16942,-16915,-16733,-16708,-16706,-16689,-16664,-16657,-16647,-16474,-16470,-16465,-16459,
    -16452,-16448,-16433,-16429,-16427,-16423,-16419,-16412,-16407,-16403,-16401,-16393,-16220,-16216,-16212,-16205,
    -16202,-16187,-16180,-16171,-16169,-16158,-16155,-15959,-15958,-15944,-15933,-15920,-15915,-15903,-15889,-15878,
    -15707,-15701,-15681,-15667,-15661,-15659,-15652,-15640,-15631,-15625,-15454,-15448,-15436,-15435,-15419,-15416,
    -15408,-15394,-15385,-15377,-15375,-15369,-15363,-15362,-15183,-15180,-15165,-15158,-15153,-15150,-15149,-15144,
    -15143,-15141,-15140,-15139,-15128,-15121,-15119,-15117,-15110,-15109,-14941,-14937,-14933,-14930,-14929,-14928,
    -14926,-14922,-14921,-14914,-14908,-14902,-14894,-14889,-14882,-14873,-14871,-14857,-14678,-14674,-14670,-14668,
    -14663,-14654,-14645,-14630,-14594,-14429,-14407,-14399,-14384,-14379,-14368,-14355,-14353,-14345,-14170,-14159,
    -14151,-14149,-14145,-14140,-14137,-14135,-14125,-14123,-14122,-14112,-14109,-14099,-14097,-14094,-14092,-14090,
    -14087,-14083,-13917,-13914,-13910,-13907,-13906,-13905,-13896,-13894,-13878,-13870,-13859,-13847,-13831,-13658,
    -13611,-13601,-13406,-13404,-13400,-13398,-13395,-13391,-13387,-13383,-13367,-13359,-13356,-13343,-13340,-13329,
    -13326,-13318,-13147,-13138,-13120,-13107,-13096,-13095,-13091,-13076,-13068,-13063,-13060,-12888,-12875,-12871,
    -12860,-12858,-12852,-12849,-12838,-12831,-12829,-12812,-12802,-12607,-12597,-12594,-12585,-12556,-12359,-12346,
    -12320,-12300,-12120,-12099,-12089,-12074,-12067,-12058,-12039,-11867,-11861,-11847,-11831,-11798,-11781,-11604,
    -11589,-11536,-11358,-11340,-11339,-11324,-11303,-11097,-11077,-11067,-11055,-11052,-11045,-11041,-11038,-11024,
    -11020,-11019,-11018,-11014,-10838,-10832,-10815,-10800,-10790,-10780,-10764,-10587,-10544,-10533,-10519,-10331,
    -10329,-10328,-10322,-10315,-10309,-10307,-10296,-10281,-10274,-10270,-10262,-10260,-10256,-10254};
        private static string[] pystr = new string[]{"a","ai","an","ang","ao","ba","bai","ban","bang","bao","bei","ben","beng","bi","bian","biao",
   "bie","bin","bing","bo","bu","ca","cai","can","cang","cao","ce","ceng","cha","chai","chan","chang","chao","che","chen",
   "cheng","chi","chong","chou","chu","chuai","chuan","chuang","chui","chun","chuo","ci","cong","cou","cu","cuan","cui",
   "cun","cuo","da","dai","dan","dang","dao","de","deng","di","dian","diao","die","ding","diu","dong","dou","du","duan",
   "dui","dun","duo","e","en","er","fa","fan","fang","fei","fen","feng","fo","fou","fu","ga","gai","gan","gang","gao",
   "ge","gei","gen","geng","gong","gou","gu","gua","guai","guan","guang","gui","gun","guo","ha","hai","han","hang",
   "hao","he","hei","hen","heng","hong","hou","hu","hua","huai","huan","huang","hui","hun","huo","ji","jia","jian",
   "jiang","jiao","jie","jin","jing","jiong","jiu","ju","juan","jue","jun","ka","kai","kan","kang","kao","ke","ken",
   "keng","kong","kou","ku","kua","kuai","kuan","kuang","kui","kun","kuo","la","lai","lan","lang","lao","le","lei",
   "leng","li","lia","lian","liang","liao","lie","lin","ling","liu","long","lou","lu","lv","luan","lue","lun","luo",
   "ma","mai","man","mang","mao","me","mei","men","meng","mi","mian","miao","mie","min","ming","miu","mo","mou","mu",
   "na","nai","nan","nang","nao","ne","nei","nen","neng","ni","nian","niang","niao","nie","nin","ning","niu","nong",
   "nu","nv","nuan","nue","nuo","o","ou","pa","pai","pan","pang","pao","pei","pen","peng","pi","pian","piao","pie",
   "pin","ping","po","pu","qi","qia","qian","qiang","qiao","qie","qin","qing","qiong","qiu","qu","quan","que","qun",
   "ran","rang","rao","re","ren","reng","ri","rong","rou","ru","ruan","rui","run","ruo","sa","sai","san","sang",
   "sao","se","sen","seng","sha","shai","shan","shang","shao","she","shen","sheng","shi","shou","shu","shua",
   "shuai","shuan","shuang","shui","shun","shuo","si","song","sou","su","suan","sui","sun","suo","ta","tai",
   "tan","tang","tao","te","teng","ti","tian","tiao","tie","ting","tong","tou","tu","tuan","tui","tun","tuo",
   "wa","wai","wan","wang","wei","wen","weng","wo","wu","xi","xia","xian","xiang","xiao","xie","xin","xing",
   "xiong","xiu","xu","xuan","xue","xun","ya","yan","yang","yao","ye","yi","yin","ying","yo","yong","you",
   "yu","yuan","yue","yun","za","zai","zan","zang","zao","ze","zei","zen","zeng","zha","zhai","zhan","zhang",
   "zhao","zhe","zhen","zheng","zhi","zhong","zhou","zhu","zhua","zhuai","zhuan","zhuang","zhui","zhun","zhuo",
   "zi","zong","zou","zu","zuan","zui","zun","zuo"};
        #endregion
    }
}

