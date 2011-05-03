using System;
using System.Collections.Generic;
using System.Web;

namespace KuaiLe.Us.Common
{

    /// <summary>
    ///HelpTool 的摘要说明
    /// </summary>
    public class Helper
    {
        public Helper()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }


        /// <summary>
        /// 根据内容作为标题
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        public static string GetFirstLine(string content, int len)
        {
            string firstLine = "";

            if (content.IndexOf("<br") > 0) //查找Html换行
            {
                firstLine = content.Substring(0, content.IndexOf("<br"));
            }
            else if (content.IndexOf('\n') > 0)
            {
                firstLine = content.Substring(0, content.IndexOf('\n'));
            }
            else
            {
                firstLine = content;
            }

            if (firstLine.IndexOf('。') > 0)
            {
                firstLine = firstLine.Substring(0, firstLine.IndexOf('。'));
            }

            //截取字符串
            if (len > 0 && firstLine.Length > len)
            {
                firstLine = firstLine.Substring(0, len);
            }

            return firstLine;
        }


        /// <summary>
        /// 转Html
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public static string EnHtml(string strContent)
        {
            strContent = HttpUtility.HtmlEncode(strContent);
            strContent = strContent.Replace(" ", "&nbsp;");
            strContent = strContent.Replace("\n", "<br />");
            return strContent;
        }


        /// <summary>
        /// html转文本
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public static string DeHtml(string strContent)
        {
            strContent = strContent.Replace("&nbsp;", " ");
            strContent = strContent.Replace("<br />", "\n");
            return strContent;
        }


    }

}