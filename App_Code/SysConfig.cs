using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

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

    public static string ConnectionString
    {
        get
        {
            return System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        }
    }


    public static string Sys_Team = "灵梦团队";

    public static string Sys_EnTeam = "Lingmon Team";

    public static string Sys_TeamSite = "Lingmon.com";

    public static string Sys_SiteName = "启动网";

    public static string Sys_Site = "7dong.net";

    public static string Sys_SiteURL = "http://www.7dong.net";

}
