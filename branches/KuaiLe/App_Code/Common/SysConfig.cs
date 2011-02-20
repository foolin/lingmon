using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


namespace KuaiLe.Us.Common
{

    /// <summary>
    ///SysConfig 的摘要说明
    /// </summary>
    public class SysConfig
    {
        public SysConfig()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
            //this.ConnectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
        }

        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            }
        }


        /// <summary>
        /// 是否写日志
        /// </summary>
        public static bool IsWriteLog
        {
            get
            {
                bool isWriteLog = false;
                try
                {
                    isWriteLog = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IsWriteLog"]);
                }
                catch
                {
                    isWriteLog = false;
                }
                return isWriteLog;
            }
        }

        /// <summary>
        /// 写日志的路径
        /// </summary>
        public static string LogPath
        {
            get
            {
                string strLogPath = System.Configuration.ConfigurationManager.AppSettings["LogPath"].Trim();
                if (string.IsNullOrEmpty(strLogPath))
                {
                    strLogPath = "Logs";
                }
                return strLogPath;
            }
        }



        /************ 邮箱相关配置 ***********/

        //From
        public static string MailFrom
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["MailFrom"] + "";
            }
        }



        //MailUserName
        public static string MailUserName
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["MailUserName"] + "";
            }
        }


        //MailPassword
        public static string MailPassword
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["MailPassword"] + "";
            }
        }



        //MailSmtpServer
        public static string MailSmtpServer
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["MailSmtpServer"] + "";
            }
        }

        /// <summary>
        /// 联系方式
        /// </summary>
        public static string Contact
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["Contact"] + "";
            }
        }


        //
        public static string LoginOkString
        {
            get
            {
                string strLoginOK = System.Configuration.ConfigurationManager.AppSettings["Contact"] + "";
                if (string.IsNullOrEmpty(strLoginOK))
                {
                    strLoginOK = "LiuFuLing_KuaiLe_Us";
                }
                return strLoginOK;
            }
        }


        /// <summary>
        /// 用户当天能提交最大数
        /// </summary>
        public static int PostMaxArticles
        {
            get
            {
                int count = 5;
                try
                {
                    count = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PostMaxArticles"]);
                }
                catch
                {
                    count = 5;
                }
                return count;
            }
        }


        /// <summary>
        /// 提交时间间隔
        /// </summary>
        public static int PostCommentInterval
        {
            get
            {
                int reslut = 5;
                try
                {
                    reslut = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PostCommentInterval"]);
                }
                catch
                {
                    reslut = 5;
                }
                return reslut;
            }
        }

    }

}
