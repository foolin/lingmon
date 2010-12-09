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
using System.Text;

public partial class User_UserAtivate : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string strUsername = QS("Username");
        string strActivateCode = QS("ActivateCode");
        if(string.IsNullOrEmpty(strUsername) || string.IsNullOrEmpty(strActivateCode))
        {
            AlertAndGo(" 激活失败，URL不合法！o(╯□╰)o", GetIndexURL());
        }

  
        LFL.Favorite.BLL.UserBll bll = new LFL.Favorite.BLL.UserBll();
        LFL.Favorite.Model.User model = null;

        model = bll.GetModel(strUsername);
        if(model == null)
        {
            AlertAndGo(" 不存在该用户！o(╯□╰)o", GetIndexURL());
        }

        int iResult = -1;
        try
        {
            iResult = bll.UserAcivate(strUsername, strActivateCode);
        }
        catch (Exception ex)
        {
            WebLog.WriteErrLog("激活用户名：" + strUsername + "，验证码：" + strActivateCode + "失败，原因：" + ex.Message);
            AlertAndGo("对不起激活失败！原因：" + ex.Message, GetIndexURL());
        }
        //判断是否成功
        if (iResult == 1)
        {
            try
            {
                Email email = new Email();
                email.SendMail(model.Email, "您的帐户" + model.Username + "已激活", GetActivateOKConent(model.Username, model.Email));
            }
            catch (Exception ex)
            {
                WebLog.WriteErrLog("发送已经激活用户" + strUsername + "邮件失败：" + ex.Message);
            }
            AlertAndGo("恭喜，您的账号：" + strUsername + "激活成功！", GetIndexURL());
        }
        else if (iResult == 2)
        {
            AlertAndGo("您的账号：" + strUsername + "已激活，无需重复激活！", GetIndexURL());
        }
        else if (iResult == 0)
        {
            AlertAndGo("对不起，激活失败！用户不存在或者激活码错误！", GetIndexURL());
        }
        else
        {
            AlertAndGo("对不起，激活失败！", GetIndexURL());
        }
        
    }



    public string GetActivateOKConent(string strUsername, string strEmail)
    {
        StringBuilder strContent = new StringBuilder();
        strContent.Append("<div style=\"font-size:14px; line-height:25px;\">");
        strContent.Append("尊敬的" + strUsername + "：");
        strContent.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;");
        strContent.Append("欢迎您使用启动网，您的帐号已激活，以下是帐户信息，请妥善保管。");
        strContent.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;");
        strContent.Append("账号：<b>" + strUsername + "</b>");
        strContent.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;");
        strContent.Append("邮箱：<b>" + strEmail + "</b>&nbsp;(用于找回密码)");
        strContent.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;");
        strContent.Append("登录地址：<a href=\"" + SysConfig.Sys_SiteURL + "\">" + SysConfig.Sys_SiteURL + "</a><br/>");
        strContent.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;");

        strContent.Append("<br />");
        strContent.Append("    " + SysConfig.Sys_Team + " ");
        strContent.Append("<br />");
        strContent.Append("    " + SysConfig.Sys_TeamSite + " ");
        strContent.Append("<br />");
        strContent.Append("    " + DateTime.Now.ToString("yyyy-MM-dd") + " ");
        strContent.Append("</div> ");

        strContent.Append("<div style=\"border-top:1px solid #ccc;padding:6px 0;font-size:12px;margin:6px 0 20px;\" >");
        strContent.Append("" + SysConfig.Sys_SiteName + "：<a href=\"" + SysConfig.Sys_SiteURL + "\">" + SysConfig.Sys_SiteURL + "</a><br/> ");
        strContent.Append("</div> ");

        return strContent.ToString();

    }
}
