using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using LFL.Utility.Web;

/// <summary>
///PageBase 的摘要说明
/// </summary>
public class PageBase : System.Web.UI.Page
{
    public PageBase()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    protected string QS(string key)
    {
        return (Request.QueryString[key] + "").Trim();
    }


    protected void Alert(string msg)
    {
        WebAgent.Alert(msg);
    }


    protected void AlertAndBack(string msg)
    {
        WebAgent.AlertAndBack(msg);
    }


    protected void AlertAndGo(string msg, string url)
    {
        WebAgent.SuccAndGo(msg, url);
    }

    protected string GetIndexURL()
    {
        return WebAgent.GetDomainURL() + "/Default.aspx";
    }

}
