using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KuaiLe.Us.Model;
using KuaiLe.Us.BLL;
using Utility.Security;
using KuaiLe.Us.Common;
using Utility.Web;

public partial class User_ResetPassword : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            string strEmail = QS("email");
            string strCode = QS("code");

            if (strEmail == "" || strCode == "")
            {
                okFindPassword.Visible = false;
                errFindPassword.Visible = true;
                return;
            }

            try
            {
                UserModel user = null;
                UserBll bll = new UserBll();
                user = bll.GetModel(strEmail, true);
                if (user == null || user.FindPwdTime == null)
                {
                    if (strEmail == "" || strCode == "")
                    {
                        okFindPassword.Visible = false;
                        errFindPassword.Visible = true;
                        return;
                    }
                }

                string strReCode = MD5Util.ToMD5(user.FindPwdTime + "", 32);
                if (strReCode != strCode)
                {
                    okFindPassword.Visible = false;
                    errFindPassword.Visible = true;
                    return;
                }

                DateTime dtmFindPwdTime = Convert.ToDateTime(user.FindPwdTime);
                if (dtmFindPwdTime.AddHours(48) < DateTime.Now)
                {
                    okFindPassword.Visible = false;
                    errFindPassword.Visible = true;
                    return;
                }

                //更新时间，使其过期
                user.FindPwdTime = DateTime.Now;
                bll.Update(user);

                //缓存USERID
                Context.Cache.Insert("FindPwd_UserID", user.UserID, null, DateTime.Now.AddMinutes(20),System.Web.Caching.Cache.NoSlidingExpiration);

            }
            catch(Exception ex)
            {
                WebLog.WriteErrLog("重置密码异常：" + ex.Message + "，邮箱：" + strEmail);
                okFindPassword.Visible = false;
                errFindPassword.Visible = true;
                return;
            }
        }

    }




    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        long userID = 0;
        try
        {
            userID = (long)Context.Cache.Get("FindPwd_UserID");
        }
        catch
        {
        }

        if (userID <= 0)
        {
            WebAgent.AlertAndGo("对不起，您重置密码已经超时！", "../Default.aspx");
        }


        string strPassword = tbPassword.Text + "";
        string strRePassword = tbRePasword.Text + "";

        //判断密码长度
        if (strPassword.Length < 6 || strPassword.Length > 50)
        {
            WebAgent.AlertAndBack("密码长度必须在6-50个字符");
        }

        //判断密码是否相等
        if (strRePassword != strPassword)
        {
            WebAgent.AlertAndBack("两次密码不一致");
        }


        UserModel user = null;
        UserBll bll = new UserBll();
        
        //查找用户
        try
        {
            user = bll.GetModel(userID);
            if (user == null)
            {
                WebLog.WriteErrLog("重置密码时，找不到UserID");
                throw new Exception();
            }
        }
        catch (Exception ex)
        {
            WebLog.WriteErrLog("重置密码异常：" + ex.Message + "。" );
            WebAgent.AlertAndGo("对不起，您重置密码已经超时！", "../Default.aspx");
        }

        //更新密码
        try
        {
            user.Password = MD5Util.ToMD5(strPassword, 32);
            user.FindPwdTime = DateTime.Now;
            bll.Update(user);
            WebLog.WriteInfoLog("用户" + user.Email + "重置密码成功！");
        }
        catch (Exception ex)
        {
            WebLog.WriteErrLog("用户" + user.Email + "重置密码写入数据库失败：" + ex.Message);
        }

        //成功跳转
        WebAgent.AlertAndGo("重置密码成功！请重新登录！", "Login.aspx");


    }
}
