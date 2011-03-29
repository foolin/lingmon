using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using KuaiLe.Us.Common;
using Utility.Web;

/// <summary>
///AdminBase 的摘要说明
/// </summary>
public class AdminBase : System.Web.UI.Page
{
    public readonly string WebPath = WebAgent.GetDomainURL();

	public AdminBase()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}



    protected override void OnPreLoad(EventArgs e)
    {
        //if (Session["LoginUserName"] == null || Session["LoginOK"] == null || Session["LoginOK"] != "OK")
        //{
        //    Response.Redirect(WebPath + "/Manage/Login.aspx");
        //}

    }

    /// <summary>
    /// 获取Request.QueryString参数
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    protected string QS(string key)
    {
        return Request[key] + "";
    }


    /// <summary>
    /// 获取Request.QueryString参数(整型)
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    protected int QSInt(string key)
    {
        return WebAgent.IsNumeric(QS(key)) ? Convert.ToInt32(QS(key)) : 0;
    }

    protected void AlertAndBack(string msg)
    {
        WebAgent.AlertAndBack(msg);
    }


    protected void AlertAndGo(string msg, string url)
    {
        WebAgent.AlertAndGo(msg, url);
    }


    protected void AlertAndRefresh(string msg, string url)
    {
        WebAgent.AlertAndRefresh(msg);
    }

}
