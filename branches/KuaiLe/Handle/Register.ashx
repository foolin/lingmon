<%@ WebHandler Language="C#" Class="Register" %>

using System;
using System.Web;
using System.Text.RegularExpressions;

public class Register : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context) {
        //输出页面头
        context.Response.ContentType = "text/plain";
        context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
        context.Response.Charset = "utf-8";
        
        //取用户名，密码，邮箱
        string strUsername = "", strPassword = "", strEmail = "";
        strUsername = context.Request["UserName"] + "";
        strPassword = context.Request["Password"] + "";
        strEmail = context.Request["Email"] + "";

        string strChkCode = context.Request["ChkCode"] + "";
        string strReChkCode = context.Session["KL_ChkCode"] + "";

        //检查验证码
        if (strChkCode != strReChkCode)
        {
            context.Response.StatusCode = 400;
            context.Response.Write("验证码错误！");
            return;
        }
        
        try
        {

            //检查用户名
            bool isValidateUsername = Regex.IsMatch(strUsername, @"^[a-zA-Z-_0-9]+$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            if (!isValidateUsername || strUsername.Length < 3 || strUsername.Length > 20)
            {
                context.Response.StatusCode = 400;
                context.Response.Write("用户名必须是字母、数字和下划线，且介于3~20个字符！");
                return;
            }
            //检查密码
            if (strPassword.Length < 6 || strPassword.Length > 20)
            {
                context.Response.StatusCode = 400;
                context.Response.Write("密码长度只能介于6~20个字符！");
                return;
            }

            if (!Utility.Web.WebAgent.IsEmail(strEmail))
            {
                context.Response.StatusCode = 400;
                context.Response.Write("邮箱不正确，请检查！");
                return;
            }

            //验证是否被使用
            KuaiLe.Us.BLL.UserBll bll = new KuaiLe.Us.BLL.UserBll();

            if (bll.Exists(strUsername))
            {
                context.Response.StatusCode = 400;
                context.Response.Write("该用户名" + strUsername + "已经被别人注册！");
                return;
            }

            if (bll.ChkEmail(strEmail))
            {
                context.Response.StatusCode = 400;
                context.Response.Write("该邮箱" + strEmail + "已经被别人使用！");
                return;
            }

            //声明用户实例，并赋值
            KuaiLe.Us.Model.UserModel model = new KuaiLe.Us.Model.UserModel();
            model.UserName = strUsername;
            model.Nickname = strUsername;
            model.Password = Utility.Security.MD5Util.ToMD5(strPassword, 32);
            model.Email = strEmail;
            model.Sex = 0;
            model.RegIP = Utility.Web.WebAgent.GetIP();
            model.RegTime = DateTime.Now;
            model.Status = 0;
            model.ActivateCode = Utility.Security.MD5Util.ToMD5(strEmail, 32);
            model.Credit = 0;
            model.Level = 0;
            model.LoginCount = 0;
            model.LastLoginIP = "";
            model.LastLoginTime = DateTime.Now;
            model.FindPwdTime = DateTime.Now;
            model.Birth = DateTime.Now;
            model.HomePage = "";
            model.ImagePath = "";
            model.Phone = "";
            model.Mobile = "";
            model.Address = "";
            model.Motto = "";
            model.Intro = "";
            
            //注册到数据库
            bll.Add(model);
            KuaiLe.Us.Common.WebLog.WriteInfoLog("用户：" + strUsername + "注册成功！");
            
            try
            {
                KuaiLe.Us.Common.MailUtil mail = new KuaiLe.Us.Common.MailUtil();
                KuaiLe.Us.Common.MailTemplate mailTpl = new KuaiLe.Us.Common.MailTemplate();
                string mailTitle = mailTpl.GetRegisterTitle(strUsername);
                string mailContent = mailTpl.GetRegisterInfo(model);
                mail.Send(strEmail, mailTitle, mailContent, true);
            }
            catch (Exception ex)
            {
                KuaiLe.Us.Common.WebLog.WriteErrLog("无法发送注册邮箱：" + strEmail + "，异常：" + ex.Message);
                context.Response.StatusCode = 200;
                context.Response.Write("尊敬的" + strUsername + "，您已经注册成功！<font color='red'>您的邮箱" + strEmail + "不存在，您的帐号无法激活！</font>");
                return;
            }
            
            //提示发送成功
            context.Response.StatusCode = 200;
            context.Response.Write("尊敬的" + strUsername + "，您已经注册成功！欢迎使用本站服务，我们已经发送一封激活邮件到您的邮箱，请注意查收！");
        }
        catch (Exception ex)
        {
            KuaiLe.Us.Common.WebLog.WriteErrLog("注册用户名：" + strUsername + "异常：" + ex.Message);
            context.Response.StatusCode = 400;
            context.Response.Write("注册出现未知错误！请联系客服" + KuaiLe.Us.Common.SysConfig.Contact + "或稍后重试！");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}