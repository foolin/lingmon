using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Sxmobi.Utility.Web;

namespace Sxmobi.Utility.IO
{
    public class Log
    {

        
        ///// <summary>
        ///// 将日志写到文件中
        ///// </summary>
        ///// <param name="strLogPath"></param>
        ///// <param name="strMessage"></param>
        //public static void WriteErrMsg( string strLogPath,string strMessage)
        //{
        //    WriteFile( strLogPath, true, strMessage, false);
        //}

        ///// <summary>
        ///// 写入文本信息
        ///// </summary>
        ///// <param name="infoLogPath"></param>
        ///// <param name="msg"></param>
        //public static void WriteLogMsg( string strLogPath, string strMessage)
        //{
        //    WriteFile(strLogPath, true, strMessage, false);
        //}

        /// <summary>
        /// 将日志写入文件中
        /// </summary>
        /// <param name="strMessage"></param>
        /// <returns></returns>
        public static bool WriteMessage(string strMessage)
        {
            string strDir = System.Web.HttpContext.Current.Request.MapPath("~\\Log");
            if (!Directory.Exists(strDir))     //如果目录不存在 
            {
                try
                {
                    Directory.CreateDirectory(strDir);//创建日期目录
                }
                catch
                {
                    //没权限创建目录
                    return false;
                }
            }
            return WriteFile(strDir + "\\" + DateTime.Now.ToString("yyyyMMdd") +".txt", strMessage, true, false);
        }

        /// <summary>
        /// 将日志写入到文件中
        /// </summary>
        /// <param name="strLogPath">路径，默认全路径</param>
        /// <param name="strMessage"></param>
        /// <returns></returns>
        public static bool WriteMessage(string strLogPath, string strMessage)
        {
            bool blIsDir = true;
            //判断是否存在绝对路径
            if (strLogPath.Substring(1, 1) != ":")
            {
                blIsDir = false;
            }
            return WriteMessage(strLogPath, strMessage, blIsDir);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="strLogPath">路径</param>
        /// <param name="strMessage">信息</param>
        /// <param name="isDirPath">路径是否为目录</param>
        /// <returns></returns>
        public static bool WriteMessage(string strLogPath, string strMessage, bool isDirPath)
        {
            if (string.IsNullOrEmpty(strLogPath))
            {
                return false;
            }
            if (isDirPath)
            {
                strLogPath = WebAgent.ToFullPath(strLogPath);
                if (!Directory.Exists(strLogPath))     //如果目录不存在 
                {
                    Directory.CreateDirectory(strLogPath);//创建日期目录
                }
                strLogPath = strLogPath + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            }
            
            return WriteFile(strLogPath, strMessage, true, false);
        }




        /// <summary>
        /// 重载，将日志写入文件中
        /// </summary>
        /// <param name="strLogPath"></param>
        /// <param name="strMessage"></param>
        /// <param name="isAppend"></param>
        /// <param name="isNewLine"></param>
        /// <returns></returns>
        public static bool WriteMessage(string strLogPath, string strMessage, bool isAppend, bool isNewLine)
        {
            return WriteFile(strLogPath, strMessage, isAppend, isNewLine);
        }



        /// <summary>
        /// 写入文件方法
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="append"></param>
        /// <param name="msg"></param>
        /// <param name="newLine"></param>
        private static bool WriteFile(string filePath, string msg, bool append, bool newLine)
        {
            bool flag = false;
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, append, Encoding.GetEncoding("gb2312")))
                {
                    sw.WriteLine(System.DateTime.Now.ToString() + " " + msg);
                    if (newLine)
                    {
                        sw.WriteLine("");
                    }
                }
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }





    }
}
