using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace CengZai.Helper
{

    /// <summary>
    ///Log 的摘要说明
    /// </summary>
    public class Log
    {
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="msg"></param>
        public static bool Add(string msg)
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory + "\\Log";
            try
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                string file = dir + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                
                return Add(file, msg);
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 写入文件方法
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="append"></param>
        /// <param name="msg"></param>
        /// <param name="newLine"></param>
        private static bool Add(string filePath, string msg)
        {
            bool flag = false;
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true, System.Text.Encoding.GetEncoding("gb2312")))
                {
                    sw.WriteLine(System.DateTime.Now.ToString() + " " + msg);
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
