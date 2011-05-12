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
    }

}
