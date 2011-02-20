using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using KuaiLe.Us.Model;
using System.Text;
using Utility.Web;


namespace KuaiLe.Us.Common
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
        public string GetRegisterTitle(string strUsername)
        {
            return "快乐网(www.kuaile.us)恭喜您注册" + strUsername + "成功！";
        }


        /// <summary>
        /// 取注册信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string GetRegisterInfo(UserModel user)
        {
            StringBuilder strContent = new StringBuilder();
            string strActivateCodeURL = WebAgent.GetDomainURL() + "/User/UserAtivate.aspx?UserName=" + user.UserName + "&ActivateCode=" + user.ActivateCode;

            strContent.Append("<div style=\"font-size:14px; line-height:25px;\">");
            strContent.Append("尊敬的" + user.UserName + "：");
            strContent.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;");

            strContent.Append("恭喜您在<b>快乐网(www.kuaile.us)</b>注册成功，您的用户名是：" + user.UserName + "，请您妥善保管您的密码，如果忘记密码，请<a href=\"" + WebAgent.GetDomainURL() + "/User/FindPassword.aspx?UserName=" + user.UserName + "\">点击这里找回密码</a>。快乐网（www.kuaile.us），我们一起分享！");
            strContent.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;");

            strContent.Append("您注册的账号需要激活才能正常使用，请尽快激活您的账号。<a href=\"" + strActivateCodeURL + "\"  target=\"_blank\">点击这里</a>进行激活，或者点击下面链接激活：");
            strContent.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;");

            strContent.Append("<a href=\"" + strActivateCodeURL + "\"  target=\"_blank\">" + strActivateCodeURL + "</a>");
            strContent.Append("<br />");
            strContent.Append("<br />");

            strContent.Append("<a href=\"" + WebAgent.GetDomainURL() + "\"  target=\"_blank\"><span style=\"font-weight:bold; color:#F00; text-decoration:none;\">快乐网（www.kuaile.us)</span></a>");
            strContent.Append("<br />");
            strContent.Append(DateTime.Now.ToString("yyyy年MM月dd日"));
            strContent.Append("<hr />");
            strContent.Append("此邮件为自动发送，切勿回复。");
            strContent.Append("</div>");

            return strContent.ToString();
        }

    }

}
