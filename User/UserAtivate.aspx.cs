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
using KuaiLe.Us.BLL;
using KuaiLe.Us.Model;
using KuaiLe.Us.Common;
using Utility.Security;

public partial class User_UserAtivate : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strUsername = QS("Username");
        string strActivateCode = QS("ActivateCode");
        if (string.IsNullOrEmpty(strUsername) || string.IsNullOrEmpty(strActivateCode))
        {
            lbDesc.Text = " 激活失败，URL不合法！o(╯□╰)o";
            return;
        }


        UserBll bll = new UserBll();

        UserModel user = bll.GetModel(strUsername);
        if (user == null)
        {
            lbDesc.Text = " 不存在用户名<font color='red'>"+ strUsername +"</font>！<br /> o(╯□╰)o";
            return;
        }

        if (user.Status != null && user.Status > 0)
        {
            lbDesc.Text = " 您的帐号已经激活，无须再激活o(*^__^*) ";
            return;
        }

        if (user.Status != null && user.Status < 0)
        {
            lbDesc.Text = " 您的帐号已经被冻结，请联系管理员，并说明理由o(╯□╰)o";
            return;
        }

        string strCheckAtivateCode = MD5Util.ToMD5(user.Email, 32);
        if (strActivateCode != strCheckAtivateCode)
        {
            lbDesc.Text = " 激活码错误，请检查是否合法o(╯□╰)o";
            return;
        }


        try
        {
            user.Status = 1;
            bll.Update(user);
            WebLog.WriteInfoLog("激活用户：" + strUsername + "成功。");
            lbDesc.Text = " 恭喜，您的帐号已经激活成功！";
            return;
        }
        catch (Exception ex)
        {
            WebLog.WriteErrLog("激活用户：" + strUsername + "异常：" + ex.Message);
            lbDesc.Text = " 激活失败，激活出现异常，请稍后再试或者联系管理员o(╯□╰)o";
            return;
        }
        
    }
}
