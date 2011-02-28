using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility.Web;
using KuaiLe.Us.Model;
using KuaiLe.Us.BLL;
using KuaiLe.Us.Common;
using Utility.Security;

public partial class User_FindPassword : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string strFindValue = tbFpFindValue.Text + "";
        string strChkCode = tbFpChkCode.Text + "";
        string strReChkCode = Session["KL_ChkCode"] + "";

        
        if (strFindValue.Trim() == "")
        {
            WebAgent.AlertAndBack("用户名/邮箱不能为空！");
            return;
        }

        if (strChkCode.Trim() == "")
        {
            WebAgent.AlertAndBack("验证码不能为空");
            return;
        }

        //检查验证码
        if (strChkCode != strReChkCode)
        {
            WebAgent.AlertAndBack("验证码不正确");
            return;
        }

        //判断是否邮箱
        bool isEmail = false;
        if (WebAgent.IsEmail(strFindValue))
        {
            isEmail = true;
        }

        UserModel user = null;
        UserBll userBll = new UserBll();
        try
        {
            user = userBll.GetModel(strFindValue, isEmail);
        }
        catch (Exception ex)
        {
            WebLog.WriteErrLog("找回密码异常，用户输入值：" + strFindValue + "，异常：" + ex.Message);
            WebAgent.AlertAndBack("找回密码失败，您的操作已记录，切勿非法操作！");
            return;
        }

        if (user == null)
        {
            if (isEmail)
            {
                WebAgent.AlertAndRefresh("您的邮箱不存在，请检查");
                return;
            }
            else
            {
                WebAgent.AlertAndRefresh("您的用户名不存在，请检查");
                return;
            }
        }


        try
        {
            //更新
            user.FindPwdTime = DateTime.Now;
            userBll.Update(user);

            //Email模板
            MailTemplate mailTpl = new MailTemplate();
            MailUtil mail = new MailUtil();
            string mailConent = mailTpl.GetFindPasswordInfo(user, MD5Util.ToMD5(user.FindPwdTime + "", 32));
            mail.Send(user.Email, "快乐网(www.kuaile.us) — 找回密码",  mailConent);
            WebLog.WriteErrLog("发送找回密码成功，用户输入：" + strFindValue );
        }
        catch (Exception ex)
        {
            WebLog.WriteErrLog("发送找回密码异常，用户输入：" + strFindValue + "，异常：" + ex.Message);
            WebAgent.AlertAndBack("找回密码失败，请稍后再试！");
            return;
        }

        if (isEmail)
        {
            WebAgent.AlertAndGo("我们已经发送邮件到您注册的邮箱" + strFindValue + "，请及时重置密码！", "../Default.aspx");
        }
        else
        {
            WebAgent.AlertAndGo("我们已经发送邮件到您注册的邮箱" + GetHideEmail(user.Email) + "，请及时重置密码！", "../Default.aspx");
        }

    }



    
    /// <summary>
    /// 隐藏Email方法
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public string GetHideEmail(string email)
    {
        int atIndex = email.IndexOf("@");
        int dotIndex = email.LastIndexOf(".");

        if (atIndex == -1 || dotIndex == -1)
        {
            return email;
        }

        char[] ncEmail = email.ToCharArray();

        int hideCount = 0;  //隐藏个数
        for (int i = atIndex - 1; i > 1 ; i--)
        {
            ncEmail[i] = '*';
            hideCount++;

            //如果大于3则退出
            if (hideCount >= 3)
            {
                break;
            }
        }

        hideCount = 0;  //重置0
        for (int i = atIndex + 1;  i < dotIndex ; i++)
        {
            ncEmail[i] = '*';
            hideCount++;

            //如果大于2，则退出，即最多隐藏两个
            if (hideCount >= 2)
            {
                break;
            }
        }

        return new String(ncEmail);
    }

}
