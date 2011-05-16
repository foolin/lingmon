using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace CengZai.Helper
{
    /// <summary>
    ///SysConfig 的摘要说明
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 网站名称
        /// </summary>
        public static string SiteName
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["SiteName"] + "";
            }
        }

        /// <summary>
        /// 网站域名，不要加www.，不要http://
        /// </summary>
        public static string SiteDomain
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["SiteDomain"] + "";
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
    }

}
