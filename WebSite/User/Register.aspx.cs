using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CengZai.Helper;
using CengZai.BLL;
using CengZai.Model;

public partial class User_Register : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void ibRegister_Click(object sender, ImageClickEventArgs e)
    {
        string strEmail = tbEmail.Text;
        string strPassword = tbPassword.Text;
        string strRePassword = tbRePassword.Text;
        string strNickName = tbNickName.Text;
        string strVerifyCode = tbVerifyCode.Text;
        int iSex = 0;

        if (!WebAgent.IsEmail(strEmail))
        {
            AjaxJscript.Alert("邮箱不合法！");
            return;
        }

        if (strPassword.Length < 6 || strPassword.Length > 16)
        {
            AjaxJscript.Alert("密码长度6-16位之间");
            return;
        }

        if (strPassword != strRePassword)
        {
            AjaxJscript.Alert("两次密码不一致");
            return;
        }

        if (strNickName.Length < 2 || strNickName.Length > 10)
        {
            AjaxJscript.Alert("昵称不符合规范！");
            return;
        }

        string strReVerifyCode = Session["VerifyCode"] + "";
        if (strReVerifyCode != strVerifyCode)
        {
            AjaxJscript.Alert("验证码不正确，请重新输入！");
            return;
        }

        try
        {
            iSex = Convert.ToInt32(ddlSex.SelectedValue);
        }
        catch { }

        UserBll bll = new UserBll();
        if (bll.Exists(strEmail))
        {
            AjaxJscript.Alert("对不起，该用户已经注册");
            return;
        }

        UserModel user = new UserModel();
        user.Email = strEmail;
        user.NickName = strNickName;
        user.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strPassword, "MD5");
        user.ActivateCode = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(DateTime.Now.ToLongTimeString(), "MD5");
        user.RegIP = WebAgent.GetIP();
        user.RegTime = DateTime.Now;
        user.Sex = 0;
        user.Status = 0;
        user.Birth = null;
        user.Credit = 0;
        user.Face = "";
        user.FindPwdTime = null;
        user.LastLoginIP = "";
        user.LastLoginTime = null;
        user.Level = 0;
        user.LoginCount = 0;
        user.Motto = "曾在，让爱情走得更远！";

        try
        {
            bll.Add(user);
        }
        catch (Exception ex)
        {
            Log.Add("用户注册[" + strEmail + "]异常：" + ex.Message);
            AjaxJscript.Alert("注册失败！");
            return;
        }


        try
        {
            MailUtil mail = new MailUtil();
            string mailTitle = MailTemplate.GetRegisterTitle(user.NickName);
            string mailContent = MailTemplate.GetRegisterInfo(user.NickName, user.Email, user.ActivateCode);
            mail.Send(user.Email, mailTitle, mailContent, true);
        }
        catch (Exception ex)
        {
            Log.Add("无法发送注册邮箱：" + strEmail + "，异常：" + ex.Message);
            AjaxJscript.Alert("尊敬的" + strNickName + "，您已经注册成功！您的邮箱" + strEmail + "不存在，您的帐号无法激活！");
            return;
        }

        AjaxJscript.AlertAndRedirect("恭喜，您注册成功！已发送一封激活邮件到您的邮箱，请及时激活！", "Login.aspx");
    }
}
