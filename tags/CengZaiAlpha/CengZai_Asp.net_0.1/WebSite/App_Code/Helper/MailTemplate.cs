using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;


namespace CengZai.Helper
{

    /// <summary>
    ///MailTemplate 的摘要说明
    /// </summary>
    public class MailTemplate
    {
        public MailTemplate()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }


        /// <summary>
        /// 取注册标题
        /// </summary>
        /// <param name="strUsername"></param>
        /// <returns></returns>
        public static string GetRegisterTitle(string nickName)
        {
            return Config.SiteName + "(www." + Config.SiteDomain + ")恭喜您注册成功！";
        }


        /// <summary>
        /// 取注册信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string GetRegisterInfo(string nickName, string email, string activeCode)
        {
            StringBuilder strContent = new StringBuilder();
            string strActivateCodeURL = WebAgent.GetDomainURL() + "/User/UserAtivate.aspx?UserName=" + nickName + "&ActivateCode=" + activeCode;

            strContent.Append("<div style=\"font-size:14px; line-height:25px;\">");
            strContent.Append("尊敬的<b>" + nickName + "</b>：");
            strContent.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;");

            strContent.Append("恭喜您在<b>" + Config.SiteName + "(www." + Config.SiteDomain + ")</b>注册成功，您的用户名是：" + nickName + "，请您妥善保管您的密码，如果忘记密码，请<a href=\"" + WebAgent.GetDomainURL() + "/User/FindPassword.aspx?email=" + email + "\">点击这里找回密码</a>。");
            strContent.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;");

            strContent.Append("您注册的账号需要激活才能正常使用，请尽快激活您的账号。<a href=\"" + strActivateCodeURL + "\"  target=\"_blank\">点击这里</a>进行激活，或者点击下面链接激活：");
            strContent.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;");

            strContent.Append("<a href=\"" + strActivateCodeURL + "\"  target=\"_blank\">" + strActivateCodeURL + "</a>");
            strContent.Append("<br />");
            strContent.Append("<br />");

            strContent.Append(Footer());

            return strContent.ToString();
        }


        /// <summary>
        /// 取找回密码信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string GetFindPasswordInfo(string nickName, string code)
        {
            StringBuilder strContent = new StringBuilder();
            string strActivateCodeURL = WebAgent.GetDomainURL() + "/User/ResetPassword.aspx?Email=" + nickName + "&Code=" + code;

            strContent.Append("<div style=\"font-size:14px; line-height:25px;\">");
            strContent.Append("尊敬的" + nickName + "：");
            strContent.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;");

            strContent.Append("欢迎您使用<b>" + Config.SiteName + "(www." + Config.SiteDomain + ")</b>找回密码功能，请在48小时内连重置您的密码。<a href=\"" + strActivateCodeURL + "\"  target=\"_blank\">点击这里</a>进行重置密码，或者点击下面链接重置密码：");
            strContent.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;");

            strContent.Append("<a href=\"" + strActivateCodeURL + "\"  target=\"_blank\">" + strActivateCodeURL + "</a>");
            strContent.Append("<br />");
            strContent.Append("<br />");

            strContent.Append(Footer());

            return strContent.ToString();
        }


        /// <summary>
        /// 底部模板
        /// </summary>
        /// <returns></returns>
        public static string Footer()
        {
            StringBuilder strContent = new StringBuilder();

            strContent.Append("<br />");
            strContent.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;");
            strContent.Append("如果您没有申请密码找回，请忽略此邮件。");
            


            strContent.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;");
            strContent.Append( Config.SiteName + "，一个挽救爱情和婚姻的情感网站，让爱情走得更远！");
            strContent.Append("<br />");
            strContent.Append("<br />");

            strContent.Append("<a href=\"" + WebAgent.GetDomainURL() + "\"  target=\"_blank\"><span style=\"font-weight:bold; color:#F00; text-decoration:none;\">"+ Config.SiteName + "(www." + Config.SiteDomain + ")</span></a>");
            strContent.Append("<br />");
            strContent.Append(DateTime.Now.ToString("yyyy年MM月dd日"));
            strContent.Append("<hr />");
            strContent.Append("此邮件为自动发送，切勿回复。");
            strContent.Append("</div>");

            return strContent.ToString();
        }

    }

}
