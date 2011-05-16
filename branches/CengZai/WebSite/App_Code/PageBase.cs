using System;
using System.Web;
using CengZai.Helper;

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

}
