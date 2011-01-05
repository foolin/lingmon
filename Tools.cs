using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
//using Sxmobi.Common;

namespace Sxmobi.Tools
{
    /// <summary>
    /// 正则表达分析日志类
    /// Author:  Foolin
    /// Created on: 2010-08-06
    /// Updated on: 2010-08-08
    /// </summary>
    public class Tools
    {
        ///// <summary>
        ///// 匹配全部参数
        ///// </summary>
        ///// <param name="strContent"></param>
        ///// <returns></returns>
        //public static string MacthAllQS(string strContent)
        //{
        //    string strReturn = "";
        //    Match match = Regex.Match(strContent + "@End@", @"\s\d+\:(?<params>.+?)@End@", RegexOptions.IgnoreCase | RegexOptions.Compiled);     //正则表达式匹配tagName=value&中value并把该值读出来。
        //    //精确到小时
        //    if (match.Success)
        //    {
        //        strReturn = match.Groups["params"].Value;
        //    }
        //    return strReturn;
        //}

        ///// <summary>
        ///// 匹配全部参数，并将其转化为字典格式
        ///// </summary>
        ///// <param name="strContent"></param>
        ///// <returns></returns>
        //public static Dictionary<string, string> MacthAllQSToDic(string strContent)
        //{
        //    string strParams = MacthAllQS(strContent);
        //    return QSParamsToDic(strParams);
        //}


        public static string GetParams(string str)
        {
            string strReturn = "";
            Match match = Regex.Match(str, @"(?<params>\w+=(.+?))(\s|$)", RegexOptions.IgnoreCase | RegexOptions.Compiled);     //正则表达式匹配param=value&param2=value2取出来。
            if (match.Success)
            {
                strReturn = match.Groups["params"].Value;
            }
            return strReturn;
        }

        /// <summary>
        /// 参数转化成字典,Key=小写，Value不转
        /// </summary>
        /// <param name="strParams"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetDicParams(string str)
        {
            return GetDicParams(str, 1);
        }

        /// <summary>
        /// 参数转化成字典,Dictionary<Key,Value>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="caseType">0=不大小写转换；1=key小写，value不转；2=key转小写，value转小写</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetDicParams(string str, int caseType)
        {
            string strParams = strParams = GetParams(str); ;
            string[] arrParam = strParams.Split(new char[] { '&' });
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (string item in arrParam)
            {
                string[] arrItem = item.Split(new char[] { '=' });
                if (caseType == 1)  //只转Key
                {
                    if (arrItem.Length == 2 && !dic.ContainsKey(arrItem[0].ToLower()))
                        dic.Add(arrItem[0].ToLower(), arrItem[1]);
                }
                else if (caseType == 2) //Key和Value都转
                {
                    if (arrItem.Length == 2 && !dic.ContainsKey(arrItem[0].ToLower()))
                        dic.Add(arrItem[0].ToLower(), arrItem[1].ToLower());
                }
                else
                {
                    if (arrItem.Length == 2 && !dic.ContainsKey(arrItem[0]))
                        dic.Add(arrItem[0], arrItem[1]);
                }
            }
            return dic;
        }



        /// <summary>
        /// 匹配参数
        /// </summary>
        /// <param name="strParams"></param>
        /// <param name="strTagName"></param>
        /// <returns></returns>
        public static string MacthQSParam(string strParams, string strTagName)
        {
            string strReturn = "";
            string strContent = strParams + "&";
            Match match = Regex.Match(strContent, strTagName + @"=(?<value>.+?)(\s|&)",RegexOptions.IgnoreCase| RegexOptions.Compiled);     //正则表达式匹配tagName=value&中value并把该值读出来。
            //精确到小时
            if (match.Success)
            {
                strReturn = match.Groups["value"].Value;
            }
            return strReturn;
        }


        /// <summary>
        /// 获取int参数
        /// </summary>
        /// <param name="strParams"></param>
        /// <param name="strTagName"></param>
        /// <returns></returns>
        public static int MacthQSParamInt(string strParams, string strTagName)
        {
            int iReturn = 0;
            string strResult = MacthQSParam(strParams, strTagName);
            if (strResult != "")
            {
                int.TryParse(strResult, out iReturn);
            }
            return iReturn;
        }


        /// <summary>
        /// 获取日志时间
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public static DateTime MatchLogDate(string strContent)
        {
            DateTime dtReturn = new DateTime();
            //2010-07-30 16:00:10
            Match match = Regex.Match(strContent, @"(?<LogDate>\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2})", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            //精确到小时
            if (match.Success)
            {
                dtReturn = DateTime.Parse(match.Groups["LogDate"].Value);
            }
            return dtReturn;
        }

        /// <summary>
        /// 匹配aspx页面
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public static string MatchAspxPage(string strContent, bool isNeedExt)
        {
            string strReturn = "";

            //
            Match match = Regex.Match(strContent, @"/(?<Aspx>(?<Page>.+?).aspx)", RegexOptions.IgnoreCase | RegexOptions.Compiled);

            //精确到小时
            if (match.Success)
            {
                if (isNeedExt)
                {
                    strReturn = match.Groups["Aspx"].Value;
                }
                else
                {
                    strReturn = match.Groups["Page"].Value;
                }
            }

            return strReturn;
        }

        /// <summary>
        /// 匹配aspx页面
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public static string MatchAspxPage(string strContent)
        {
            return MatchAspxPage(strContent, true);
        }

        /// <summary>
        /// 匹配IP
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public static string MatchIP(string strContent)
        {
            string strReturn = "";

            Match match = Regex.Match(strContent, @"(?<ip>((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?))", RegexOptions.IgnoreCase | RegexOptions.Compiled);

            //精确到小时
            if (match.Success)
            {
                strReturn = match.Groups["ip"].Value;
            }

            return strReturn;
        }

        /// <summary>
        /// 返回一组IP
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public static string[] MatchAllIP(string strContent)
        {
            string strReturn = "";

            MatchCollection matchs = Regex.Matches(strContent, @"(?<ip>((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?))", RegexOptions.IgnoreCase | RegexOptions.Compiled);

            //精确到小时
            if(matchs.Count > 0)
            {
                for (int i = 0; i < matchs.Count && matchs[i].Success; i++)
                {
                    if (i > 0) strReturn += ",";
                    strReturn += matchs[i].Groups["ip"].Value;
                }
            }
            return strReturn.Split( new char[]{','});
        }

        /// <summary>
        /// 文件名：米号_年_月_日_时.log或者米号_年_月_日.log转换为时间
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="ext"></param>
        /// <returns></returns>
        public static DateTime FileNameToTime(string fileName, string ext)
        {
            DateTime dtReturn = new DateTime();

            Match match = Regex.Match(fileName, @"\d+_(?<year>\d{4})_(?<month>\d+)_(?<day>\d+)_(?<hour>\d+).", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            //精确到小时
            if (match.Success)
            {
                dtReturn = new DateTime(int.Parse("20" + match.Groups["year"].Value), int.Parse(match.Groups["month"].Value)
                                        , int.Parse(match.Groups["day"].Value)
                                        , int.Parse(match.Groups["hour"].Value), 0, 0);
            }
            else
            {   //精确到天
                match = Regex.Match(fileName, @"\d+_(?<year>\d{4})_(?<month>\d+)_(?<day>\d+).", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                if (match.Success)
                {
                    dtReturn = new DateTime(int.Parse(match.Groups["year"].Value), int.Parse(match.Groups["month"].Value)
                                            , int.Parse(match.Groups["day"].Value)
                                            , 0, 0, 0);
                }
            }
            return dtReturn;
            
        }

        /// <summary>
        /// 文件名：ex10080612.log或者ex100806.log转换为时间
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static DateTime FileNameToTime(string fileName)
        {
            return FileNameToTime(fileName, "log");
        }


        /// <summary>
        /// 是否存在字符串，忽略大小写
        /// </summary>
        /// <param name="source"></param>
        /// <param name="find"></param>
        /// <returns></returns>
        public static bool IsExistStr(string source, string find)
        {
            return IsExistStr(source, find, true);
        }

        /// <summary>
        /// 是否存在字符串
        /// </summary>
        /// <param name="source"></param>
        /// <param name="find"></param>
        /// <param name="ignoreCase">是否忽略大小写：true=是</param>
        /// <returns></returns>
        public static bool IsExistStr(string source, string find, bool ignoreCase)
        {
            bool blReturn = false;
            string strSrc = string.Empty;
            string strKey = string.Empty;
            if (ignoreCase)
            {
                strSrc = source.ToLower().Trim();
                strKey = find.ToLower().Trim();
            }
            else
            {
                strSrc = source.Trim();
                strKey = find.Trim();
            }
            //查找
            if (strSrc.IndexOf(strKey) != -1)
            {
                blReturn = true;   
            }
            return blReturn;
        }

    }
}
