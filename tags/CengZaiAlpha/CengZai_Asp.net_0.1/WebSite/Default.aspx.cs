using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CengZai.Helper;
using CengZai.Model;
using CengZai.BLL;

public partial class _Default : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string strEmail = tbEmail.Text;
        string strPassword = tbPassword.Text;
        string strVerifyCode = tbVerifyCode.Text;
        string strReVerifyCode = Session["VerifyCode"] + "";

        //
        if (string.IsNullOrEmpty(strEmail))
        {
            AjaxJscript.Alert("请输入邮箱！");
            return;
        }

        if (string.IsNullOrEmpty(strPassword))
        {
            AjaxJscript.Alert("请输入密码");
            return;
        }

        if (strVerifyCode != strReVerifyCode)
        {
            AjaxJscript.Alert("验证码不正确");
            return;
        }

        UserModel user = null;
        UserBll bll = new UserBll();
        try
        {
            int statusCode = 0;
            user = bll.GetModel(strEmail, strPassword, out statusCode);
            if (user == null)
            {
                if (statusCode == -1)
                {
                    AjaxJscript.Alert("邮箱不存在！");
                    return;
                }
                else if (statusCode == -2)
                {
                    AjaxJscript.Alert("密码不正确！");
                    return;
                }
                else
                {
                    AjaxJscript.Alert("邮箱或者密码不正确");
                    return;
                }
            }

            if (user.Status == 0)
            {
                AjaxJscript.Alert("您帐号尚未激活！请登录邮箱激活！");
                return;
            }
            if (user.Status == -1)
            {
                AjaxJscript.Alert("您的帐号已经被冻结，请联系管理员！");
                return;
            }

            //更新
            if (user.LoginCount == null)
            {
                user.LoginCount = 1;
            }
            else
            {
                user.LoginCount += 1;
            }
            //判断是否增加积分
            if (user.LastLoginTime == null
                || Convert.ToDateTime(user.LastLoginTime).ToString("yyyyMMdd") != DateTime.Now.ToString("yyyyMMdd")
                )
            {
                if (user.Level == null)
                {
                    user.Level = 1;
                }
                else
                {
                    user.Level += 1;
                }
            }
            user.LastLoginIP = WebAgent.GetIP();
            user.LastLoginTime = DateTime.Now;

            //更新信息
            bll.Update(user);
        }
        catch (Exception ex)
        {
            Log.Add(strEmail + "登录异常：" + ex.Message);
            AjaxJscript.Alert("暂时无法登录，请稍后重试！");
            return;
        }


        //Session保存用户信息
        Session["LoginUserInfo"] = user;
        Session["LoginOK"] = "OK";
        Session.Timeout = 120;

        if (user.LoginCount <= 1)
        {
            //如果是第一次登录，则跳转到完善信息
            Response.Redirect("~/User/Reg2_UpdateInfo.aspx");
        }
        else
        {
            //直接跳转到Home
            Response.Redirect("~/Home");
        }

    }
}
