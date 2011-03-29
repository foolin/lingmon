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
using KuaiLe.Us.Model;
using Utility.Security;
using KuaiLe.Us.Common;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        UserModel user = new UserModel();
        user.UserName = "liufuling";
        user.Email = "ling@liufu.org";
        user.ActivateCode = MD5Util.ToMD5(user.Email, 32);

        MailUtil mail = new MailUtil();
        MailTemplate tpl = new MailTemplate();
        mail.Send("ling@liufu.org;foolin@7dong.net", "", "快乐网(www.kuaile.us)恭喜您注册成功！", tpl.GetRegisterInfo(user), true);
        Response.Write("成功发送邮件");
        */

        Response.Write(HttpUtility.HtmlEncode("<html>"));

        HttpUtility.HtmlEncode("");
    }
}
