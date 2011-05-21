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
using System.Collections.Generic;
using Newtonsoft.Json;
using Utility.Web;
using KuaiLe.Us.Common;

public partial class Manage_Login : System.Web.UI.Page
{
    private readonly string _USERNAME = "ivy";
    private readonly string _PASSWORD = "lu3227728";

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string strUsername = txbUserName.Text + "";
        string strPassword = txbPassWord.Text + "";

        if (strUsername.ToLower() == _USERNAME && strPassword == _PASSWORD)
        {
            Session["LoginUserName"] = "Foolin@KuaiLe.Us";
            Session["LoginOK"] = "OK";
            WebLog.WriteInfoLog("登录成功！");

            Response.Redirect("Admin.aspx");
        }
        else
        {
            WebLog.WriteErrLog("登录UserName:" + txbUserName.Text + "失败！");
            WebAgent.AlertAndBack("登录失败！");
        }

    }
}
