<%@ WebHandler Language="C#" Class="SavePassword" %>

using System;
using System.Web;
using System.Web;
using KuaiLe.Us.Model;
using KuaiLe.Us.DAL;
using KuaiLe.Us.BLL;
using KuaiLe.Us.Common;
using Utility.Security;

public class SavePassword : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        if (context.Session["KL_LoginUser"] == null || context.Session["KL_LoginOK"] == null)
        {
            context.Response.StatusCode = 400;
            context.Response.Write("你尚未<a href='Login.aspx' target='_blank'>登录</a>！请先<a href='Login.aspx'  target='_blank'>登录</a>或者<a href='Register.aspx'  target='_blank'>注册</a>！");
            return;
        }

        UserModel user = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(context.Session["KL_LoginUser"].ToString());
        if (user == null)
        {
            context.Response.StatusCode = 400;
            context.Response.Write("你尚未<a href='Login.aspx'  target='_blank'>登录</a>！请先<a href='Login.aspx'  target='_blank'>登录</a>或者<a href='Register.aspx'  target='_blank'>注册</a>！");
            return;
        }
        
        //取值
        string strOldPassword = context.Request["oldpwd"] + "";
        string strNewPassword = context.Request["newpwd"] + "";
        string strNewRePassword = context.Request["newrepwd"] + "";

        if (strOldPassword.Length > 6 || strOldPassword.Length > 20)
        {
            context.Response.StatusCode = 400;
            context.Response.Write("旧密码不正确！");
            return;
        }

        if (strNewPassword.Length > 6 || strNewPassword.Length > 20)
        {
            context.Response.StatusCode = 400;
            context.Response.Write("新密码长度不对，密码长度在6-20个字符之间！");
            return;
        }

        if (strNewPassword != strNewRePassword)
        {
            context.Response.StatusCode = 400;
            context.Response.Write("两次密码不一致！");
            return;
        }

        
        //转成加密类型密码
        strOldPassword = MD5Util.ToMD5(strOldPassword, 32);
        strNewPassword = MD5Util.ToMD5(strNewPassword, 32);
        
        
        UserBll bll = new UserBll();

        //取最新的User
        user = bll.GetModel(user.UserID);   
        
        if (user == null)
        {
            context.Response.StatusCode = 400;
            context.Response.Write("你尚未<a href='Login.aspx'  target='_blank'>登录</a>！请先<a href='Login.aspx'  target='_blank'>登录</a>或者<a href='Register.aspx'  target='_blank'>注册</a>！");
            return;
        }
        
        //验证密码
        if (strOldPassword != user.Password)
        {
            context.Response.StatusCode = 400;
            context.Response.Write("旧密码不正确，无法修改密码！");
            return;
        }

        

        try
        {
            //修改密码
            user.Password = strNewPassword;
            bll.Update(user);
            WebLog.WriteInfoLog("用户" + user.UserName + "修改密码成功！");
        }
        catch (Exception ex)
        {
            WebLog.WriteErrLog("用户" + user.UserName + "更新修改密码异常：" + ex.Message);
            context.Response.StatusCode = 400;
            context.Response.Write("修改密码失败，请检查输入或者稍后再试！");
            return;
        }


        context.Response.StatusCode = 200;
        context.Response.Write("修改密码成功！");
        context.Session["KL_LoginUser"] = Newtonsoft.Json.JsonConvert.SerializeObject(user);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}