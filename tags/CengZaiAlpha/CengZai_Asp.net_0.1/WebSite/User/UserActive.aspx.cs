using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CengZai.BLL;
using CengZai.Model;
using CengZai.Helper;

public partial class User_UserActive : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strEmail = QS("email");
        string strActivateCode = QS("activecode");
        if (string.IsNullOrEmpty(strEmail) || string.IsNullOrEmpty(strActivateCode))
        {
            lbDesc.Text = " 激活失败，URL不合法！o(╯□╰)o";
            return;
        }


        UserBll bll = new UserBll();

        UserModel user = null;
        try
        {
            user = bll.GetModel(strEmail);
        }
        catch (Exception ex)
        {
            Log.Add("取用户异常[" + strEmail + "]数据异常：" + ex.Message);
        }
        if (user == null)
        {
            lbDesc.Text = " 不存在用户名<font color='red'>" + strEmail + "</font>！<br /> o(╯□╰)o";
            return;
        }

        if (user.Status != null && user.Status > 0)
        {
            lbDesc.Text = " 您的帐号[" + strEmail + "]已经激活，无须再激活o(*^__^*) ";
            return;
        }

        if (user.Status != null && user.Status < 0)
        {
            lbDesc.Text = " 您的帐号[" + strEmail + "]已经被冻结，请联系管理员，并说明理由o(╯□╰)o";
            return;
        }

        if (strActivateCode != user.ActivateCode)
        {
            lbDesc.Text = " 激活码错误，请检查是否合法o(╯□╰)o";
            return;
        }


        try
        {
            user.Status = 1;
            bll.Update(user);
            Log.Add("激活用户：" + strEmail + "成功。");
            lbDesc.Text = " 亲爱的" + user.NickName + "，您的帐号已经激活成功！现在可以正常<a href='Login.aspx'>登录</a>了";
            return;
        }
        catch (Exception ex)
        {
            Log.Add("激活用户：" + strEmail + "异常：" + ex.Message);
            lbDesc.Text = " 激活出现异常，请稍后重试，或者联系管理员o(╯□╰)o";
            return;
        }
    }
}
