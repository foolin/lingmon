using System;
using System.Web;
using CengZai.Helper;
using CengZai.Model;

/// <summary>
///PageBase 的摘要说明
/// </summary>
public class PageBase : System.Web.UI.Page
{
    private UserModel userInfo = null;    //用户ID
    

	public PageBase()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}


    protected override void OnPreLoad(EventArgs e)
    {
        string siteName = (CengZai.Helper.Config.SiteName + "").ToLower();
        if (this.Title == null || this.Title.Trim() == "")
        {
            this.Title += Config.SiteName + "_" + Config.SiteDomain;
        }
        else if(this.Title.ToLower().IndexOf(siteName) == -1)
        {
            this.Title += "-" + Config.SiteName;
        }


        base.OnPreLoad(e);
    }

    /// <summary>
    /// 检查是否登录
    /// </summary>
    /// <returns></returns>
    public bool CheckLogin()
    {
        if (Session["LoginUserInfo"] == null || (Session["LoginOK"] + "") != "OK")
        {
            return false;
        }

        //验证是否存在Session
        bool isLogin = false;
        try
        {
            userInfo = (UserModel)Session["LoginUserInfo"];
        }
        catch { }

        //如果User用户信息不为空，则存在用户信息
        if (userInfo != null)
        {
            isLogin = true;
        }


        return isLogin;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string QS(string key)
    {
        return this.Page.Request[key] + "";
    }


    /// <summary>
    /// 弹出信息
    /// </summary>
    /// <param name="msg"></param>
    public void Alert(string msg)
    {
        WebAgent.Alert(msg);
    }


    /// <summary>
    /// 弹出信息并返回
    /// </summary>
    /// <param name="msg"></param>
    public void AlertAndBack(string msg)
    {
        WebAgent.AlertAndBack(msg);
    }


    /// <summary>
    /// 弹出信息并跳转
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="url"></param>
    public void AlertAndGo(string msg, string url)
    {
        WebAgent.AlertAndGo(msg, url);
    }

    
    /// <summary>
    /// 弹出信息并返回刷新
    /// </summary>
    /// <param name="msg"></param>
    public void AlertAndRefresh(string msg)
    {
        WebAgent.AlertAndRefresh(msg);
    }

}
