using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using KuaiLe.Us.Common;
using Utility.Web;

/// <summary>
///WapBase 的摘要说明
/// </summary>
public class WapBase : System.Web.UI.Page
{
	public WapBase()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}


    public void WritePage(string title,  string body)
    {

        StringBuilder strWapContent = new StringBuilder();
        strWapContent.Append("<div class=\"header\">");
        strWapContent.Append("" + WapUtil.WriteImage("images/mlogo.gif", "default.aspx", ""));
        strWapContent.Append("</div>");
        strWapContent.Append("<div class=\"nav\">");
        strWapContent.Append("" + WapUtil.WriteLink("首页","default.aspx") + " | ");
        strWapContent.Append("" + WapUtil.WriteLink("最热", "default.aspx?type=hot") + " | ");
        strWapContent.Append("" + WapUtil.WriteLink("最新", "default.aspx?type=new") + " | ");
        //strWapContent.Append("" + WapUtil.WriteLink("注册", "default.aspx?type=new") + " | ");
        //strWapContent.Append("" + WapUtil.WriteLink("登录", "default.aspx?type=new") + " | ");
        strWapContent.Append("" + WapUtil.WriteLink("关于", "about.aspx") + " ");
        strWapContent.Append("</div>");

        strWapContent.Append("<div class=\"container\">");
        strWapContent.Append(body);
        strWapContent.Append("</div>");

        strWapContent.Append("<div class=\"footer\">");
        strWapContent.Append("  &#169; " + DateTime.Now.Year + " 快乐网(www.kuaile.us) <br /> ");
        strWapContent.Append(" " + DateTime.Now.ToString("yyyy年M月d日 HH:mm:ss"));
        strWapContent.Append("</div>");

        if (title == "")
        {
            title = "我们一起分享";
        }

        string strHead = "<link rel=\"stylesheet\" href=\"images/wap.css\" type=\"text/css\"/> \r\n";
        string strWapPage = WapUtil.GetWap2Page("手机快乐网 - " + title, strHead, strWapContent.ToString());
        Response.Write(strWapPage);
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

}
