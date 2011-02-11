using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Newtonsoft.Json;
using KuaiLe.Us.Model;

public partial class WebUserControl_WucTopbarLink : WucBase
{

    public UserModel GB_LoginUser = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["KL_LoginUser"] != null && Session["KL_LoginOK"] != null)
        {
            GB_LoginUser = JsonConvert.DeserializeObject<UserModel>(Session["KL_LoginUser"].ToString());
        }
        else
        {
            Session["KL_LoginUser"] = null;
            Session["KL_LoginOK"] = null;
        }
    }


    public string GetUserLoginInfo()
    {
        string strLink = "";
        if (GB_LoginUser != null)
        {
            strLink += GetLink(GB_SitePath + "/User/My.aspx", "欢迎" + GB_LoginUser.UserName);
            strLink += GetLink(GB_SitePath + "/User/Logout.aspx", "注销登录");
        }
        else
        {
            strLink += GetLink(GB_SitePath + "/User/Login.aspx", "登录");
            strLink += GetLink(GB_SitePath + "/User/Register.aspx", "注册");
        }
        return strLink;
    }


    private string GetLink(string link, string text)
    {
        return "<a href=" + link + ">" + text + "</a> &nbsp; | &nbsp;  ";
    }
}
