using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;


namespace KuaiLe.Us.Common
{
    /// <summary>
    ///WapUitl 的摘要说明
    /// </summary>
    public class WapUtil
    {
        public WapUtil()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 生成页面
        /// </summary>
        /// <param name="FilePath">文件地址</param>
        /// <param name="Content">文件内容</param>
        public static void CreatePage(string FilePath, string Content)
        {
            StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(FilePath), false);
            sw.Write(Content);
            sw.Close();
        }

        /// <summary>
        /// 获取一个完整的Wap1.0(wml)页面
        /// </summary>
        /// <param name="title">页面标题</param>
        /// <param name="body">页面内容</param>
        /// <returns></returns>
        public static string GetWap1Page(string title, string body)
        {
            string page = "";
            page = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n";
            page += "<!DOCTYPE wml PUBLIC \"-//WAPFORUM//DTD WML 1.1//EN\" \"http://www.wapforum.org/DTD/wml_1.1.xml\">\r\n";
            page += "<wml>\r\n";
            page += "<head>\r\n";
            page += "<meta http-equiv=\"Cache-Control\" content=\"no-cache\"/>\r\n";
            page += "</head>\r\n";
            page += "<card id=\"card1\" title=\"" + title + "\">\r\n";
            page += body;
            page += "\r\n</card>\r\n";
            page += "</wml>";

            return page;
        }


        /// <summary>
        /// 获取一个完整的Wap2.0页面
        /// </summary>
        /// <param name="title">页面标题</param>
        /// <param name="body">页面内容</param>
        /// <returns></returns>
        public static string GetWap2Page(string title, string head, string body)
        {
            string page = "";
            page = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n";
            page += "<!DOCTYPE html PUBLIC \" -//WAPFORUM//DTD XHTML Mobile 1.0//EN\" \"http://www.wapforum.org/DTD/xhtml-mobile10.dtd\">\r\n";
            page += "<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n";
            page += "<head>\r\n";
            page += "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n";
            page += "<meta http-equiv=\"Cache-Control\" content=\"no-cache\"/>\r\n";
            page += "<title>" + title + "</title>\r\n";
            if (!string.IsNullOrEmpty(head))
            {
                page += head + "\r\n";
            }
            page += "</head>\r\n";
            page += "<body>\r\n";
            page += body;
            page += "\r\n</body>\r\n";
            page += "</html>";

            return page;
        }

        /// <summary>
        /// 写入文本,无格式
        /// </summary>
        /// <param name="str">文本内容</param>
        /// <returns></returns>
        public static string WriteText(string str)
        {
            return DealText(str);
        }

        /// <summary>
        /// 写入文本,带格式
        /// </summary>
        /// <param name="str">文本内容</param>
        /// <param name="align">left,right,center</param>
        /// <param name="b"></param>
        /// <param name="i"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static string WriteText(string str, string align, bool b, bool i, bool u)
        {
            str = DealText(str);
            str = b == true ? "<b>" + str + "</b>" : str;
            str = i == true ? "<i>" + str + "</i>" : str;
            str = u == true ? "<u>" + str + "</u>" : str;
            align = align.ToLower();
            if (align == "right" || align == "center")
            {
                str = "<p align=\"" + align + "\">" + str + "</p>";
            }
            return str;
        }

        /// <summary>
        /// 写入链接,无格式
        /// </summary>
        /// <param name="str">链接文本</param>
        /// <param name="url">链接地址</param>
        /// <returns></returns>
        public static string WriteLink(string str, string link)
        {
            return "<a href=\"" + DealLink(link) + "\">" + DealText(str) + "</a>";
        }

        /// <summary>
        /// 写入链接,带格式
        /// </summary>
        /// <param name="str">链接文本</param>
        /// <param name="url">链接地址</param>
        /// <param name="align">left,right,center</param>
        /// <param name="b"></param>
        /// <param name="i"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static string WriteLink(string str, string link, string align, bool b, bool i, bool u)
        {
            str = DealText(str);
            str = b == true ? "<b>" + str + "</b>" : str;
            str = i == true ? "<i>" + str + "</i>" : str;
            str = u == true ? "<u>" + str + "</u>" : str;
            align = align.ToLower();
            if (align == "right" || align == "center")
            {
                return "<p align=\"" + align + "\"><a href=\"" + DealLink(link) + "\">" + str + "</a></p>";
            }
            else
            {
                return "<a href=\"" + DealLink(link) + "\">" + str + "</a>";
            }
        }

        /// <summary>
        /// 写入Anchor,包括refresh,prev,go
        /// </summary>
        /// <param name="str">链接文本</param>
        /// <param name="url">链接地址</param>
        /// <param name="align">left,right,center</param>
        /// <returns></returns>
        public static string WriteAnchor(string str, string link, string align)
        {
            string sAnchor = "";

            str = DealText(str);
            link = link.ToLower();
            align = align.ToLower();
            if (align == "right" || align == "center")
            {
                sAnchor = "<p align=\"" + align + "\">";
                if (link.Equals("refresh"))
                {
                    sAnchor += "<anchor><refresh />" + str + "</anchor>";
                }
                else if (link.Equals("prev"))
                {
                    sAnchor += "<anchor><prev />" + str + "</anchor>";
                }
                else
                {
                    sAnchor += "<anchor><go href=\"" + link + "\" />" + str + "</anchor>";
                }
                sAnchor += "</p>";
            }
            else
            {
                if (link.Equals("refresh"))
                {
                    sAnchor += "<anchor><refresh />" + str + "</anchor>";
                }
                else if (link.Equals("prev"))
                {
                    sAnchor += "<anchor><prev />" + str + "</anchor>";
                }
                else
                {
                    sAnchor += "<anchor><go href=\"" + link + "\" />" + str + "</anchor>";
                }
            }

            return sAnchor;
        }

        /// <summary>
        /// 写入图片
        /// </summary>
        /// <param name="url">图片地址</param>
        /// <param name="link">图片链接</param>
        /// <param name="align">left,right,center</param>
        /// <returns></returns>
        public static string WriteImage(string imgsrc, string link, string align)
        {
            string str = "";
            align = align.ToLower();
            if (align == "right" || align == "center")
            {
                if (link == "")
                {
                    str = "<p align=\"" + align + "\"><img src=\"" + imgsrc + "\"/></p>";
                }
                else
                {
                    str = "<p align=\"" + align + "\"><a href=\"" + DealLink(link) + "\"><img src=\"" + imgsrc + "\"/></a></p>";
                }
            }
            else
            {
                if (link == "")
                {
                    str = "<img src=\"" + imgsrc + "\"/>";
                }
                else
                {
                    str = "<a href=\"" + DealLink(link) + "\"><img src=\"" + imgsrc + "\"/></a>";
                }
            }
            return str;
        }

        /// <summary>
        /// 写入空格
        /// </summary>
        /// <param name="num">空格数</param>
        /// <returns></returns>
        public static string WriteSpace(int num)
        {
            string Space = "";
            for (int i = 1; i <= num; i++)
            {
                Space += "&nbsp;";
            }

            return Space;
        }

        /// <summary>
        /// 写入换行
        /// </summary>
        /// <param name="num">换行数</param>
        /// <returns></returns>
        public static string WriteBreakLine(int num)
        {
            string BreakLine = "";
            for (int i = 1; i <= num; i++)
            {
                BreakLine += "<br/>";
            }

            return BreakLine;
        }

        /// <summary>
        /// 处理链接
        /// </summary>
        /// <param name="link">连接地址</param>
        /// <returns></returns>
        public static string DealLink(string link)
        {
            Regex oReg = new Regex("&(?!lt;|gt;|shy;|apos;|quot;|amp;|#38;|#160;)", RegexOptions.IgnoreCase);
            link = oReg.Replace(link, "&amp;");

            return link;
        }

        /// <summary>
        /// 处理文本
        /// </summary>
        /// <param name="str">文本内容</param>
        /// <returns></returns>
        public static string DealText(string str)
        {
            Regex oReg = new Regex("&(?!lt;|gt;|shy;|apos;|quot;|amp;|#38;|#160;)", RegexOptions.IgnoreCase);
            str = oReg.Replace(str, "&amp;");

            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace("$", "$$");
            //str = str.Replace("-", "&shy;");
            str = str.Replace("'", "&apos;");
            str = str.Replace("\"", "&quot;");

            return str;
        }


    }

}
