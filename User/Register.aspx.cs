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
using LFL.Utility.Security;
using LFL.Utility.Web;
using System.Text;

public partial class Register : PageBase
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //验证码
        if (!IsPostBack)
        {
            string chkCode = (new Random()).Next(1000, 9999).ToString();
            imgVal.ImageUrl = "ImageVal.aspx?id=" + chkCode;
            imgVal.ImageAlign = ImageAlign.AbsBottom;
            hdValCode.Value = chkCode;

            regForm.Visible = true;
            regOk.Visible = false;
        }

    }



    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string chkCode = txtChkCode.Value + "";
        string valCode = hdValCode.Value + "";

        if (chkCode != "")
        {
            if (valCode == "")
                return;
            if (LFL.Utility.Security.MD5Util.ToMD5(valCode).Replace("-", "").Replace("A", "").Replace("B", "").Replace("C", "").Replace("D", "").Replace("E", "").Replace("F", "").Substring(0, 4) != chkCode)
            {
                AlertAndBack("验证码错误!");
            }
        }

        LFL.Favorite.Model.User user = new LFL.Favorite.Model.User();
        

        string strUsername, strPassword, strRePassword, strEmail;
        
        strUsername = txtUsername.Value.Trim();
        if (string.IsNullOrEmpty(strUsername) || strUsername.Length < 4 || strUsername.Length > 20)
        {
            AlertAndBack("用户名不能为空且长度于5-20之间！");
        }
        strPassword = txtPassword.Value.Trim();
        if (string.IsNullOrEmpty(strPassword) || strPassword.Length < 6 || strPassword.Length > 50)
        {
            AlertAndBack("密码不能为空且长度于6-50之间！");
        }
        strRePassword = txtRePassword.Value.Trim();
        if (string.IsNullOrEmpty(strRePassword) || !strPassword.Equals(strRePassword))
        {
            AlertAndBack("两次密码不一致！");
        }
        strEmail = txtEmail.Value.Trim();
        if (string.IsNullOrEmpty(strEmail))
        {
            AlertAndBack("邮箱不能为空！");
        }

        if (!chkAgreement.Checked)
        {
            AlertAndBack("请仔细阅读注册协议。");
        }

        LFL.Favorite.BLL.UserBll bll = new LFL.Favorite.BLL.UserBll();
        if (bll.Exists(strUsername, strEmail))
        {
            AlertAndBack("该用户名或邮箱已经被注册！");
        }


        DateTime dtmNow = DateTime.Now;
        string strActivateCode = MD5Util.ToMD5(dtmNow.ToString("yyyyss7MMddongmmHH"));

        user.Username = strUsername;
        user.Nickname = strUsername;
        user.Password = MD5Util.ToMD5(strPassword);
        user.Email = strEmail;
        user.Sex = "保密";
        user.ActivateCode = strActivateCode;
        user.RegTime = dtmNow;
        user.RegIP = WebAgent.GetIP();
        user.LoginCount = 0;
        user.Level = 0;
        user.Credit = 0;
        user.Status = 0;   //


        try
        {
            bll = new LFL.Favorite.BLL.UserBll();
            bll.Add(user);
        }
        catch (Exception ex)
        {
            WebLog.WriteErrLog("注册失败！原因：" + ex.Message);
            AlertAndBack("注册失败！原因：" + ex.Message);
        }

        try
        {
            SendActiveCodeEmail(strEmail, strUsername, strPassword, strActivateCode);
        }
        catch (Exception ex)
        {
            WebLog.WriteErrLog("发送注册邮件失败！原因：" + ex.Message);
            AlertAndBack("发送注册邮件失败！原因：" + ex.Message);
        }

        WebLog.WriteInfoLog("注册用户名：" + user.Username + ", Email：" + user.Email + "成功！");


        //成功
        lblUsername.Text = strUsername;
        lblPassword.Text = strPassword;
        hdRegTime.Value = dtmNow.ToString("yyyyss7MMddongmmHH");
        regForm.Visible = false;
        regOk.Visible = true;



    }



    protected void SendActiveCodeEmail(string toEmail, string strUserName, string strPassWord, string strActivateCode)
    {

        StringBuilder strContent = new StringBuilder();
        string strActivateCodeURL = WebAgent.GetDomainURL() + "/User/UserAtivate.aspx?UserName="+ strUserName +"&ActivateCode=" + strActivateCode;

        strContent.Append("<div style=\"font-size:14px; line-height:25px;\">");
        strContent.Append("尊敬的" + strUserName + "：");
        strContent.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;");

        strContent.Append("恭喜您在"+ SysConfig.Sys_SiteName +"（"+ SysConfig.Sys_Site +"）注册成功，您的用户名是：" + strUserName + "，密码是：" + strPassWord + "，请您妥善保管。畅游网络，从此启动（7dong）！");
        strContent.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;");

        strContent.Append("您注册的账号需要激活才能正常使用，请尽快激活您的账号。<a href=\"" + strActivateCodeURL + "\"  target=\"_blank\">点击这里</a>进行激活，或者点击下面链接激活：");
        strContent.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;");

        strContent.Append("<a href=\"" + strActivateCodeURL + "\"  target=\"_blank\">" + strActivateCodeURL + "</a>");
        strContent.Append("<br />");
        strContent.Append("<br />");

        strContent.Append("<a href=\"" + WebAgent.GetDomainURL()  + "\"  target=\"_blank\"><span style=\"font-weight:bold; color:#F00; text-decoration:none;\">"+ SysConfig.Sys_SiteName +"（"+ SysConfig.Sys_Site +")</span></a>");
        strContent.Append("<br />");
        strContent.Append(DateTime.Now.ToString("yyyy年MM月dd日"));
        strContent.Append("<hr />");
        strContent.Append("此邮件为自动发送，切勿回复。");
        strContent.Append("</div>");

        Email email = new Email();
        email.SendMail(toEmail, SysConfig.Sys_SiteName + "恭喜您：您注册成功，请激活账号！", strContent.ToString());


    }

    protected void btnReEmail_Click(object sender, EventArgs e)
    {

        string strEmail, strUsername, strPassword, strActivateCode;
        strEmail = txtEmail.Value;
        strUsername = lblUsername.Text;
        strPassword = lblPassword.Text;
        strActivateCode = hdRegTime.Value;
        try
        {
            SendActiveCodeEmail(strEmail, strUsername, strPassword, MD5Util.ToMD5(hdRegTime.Value));
        }
        catch (Exception ex)
        {
            WebLog.WriteErrLog("注册用户：" + strEmail + "重发邮件失败！原因：" + ex.Message);
            AlertAndBack("重发邮件失败！原因：" + ex.Message);
        }

        lblOKTitle.Text = "重新发送邮件成功";
        AlertAndBack("重新发送成功！");

    }




}
