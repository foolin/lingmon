<%@ WebHandler Language="C#" Class="Login" %>

using System;
using System.Web;

public class Login : IHttpHandler, System.Web.SessionState.IRequiresSessionState{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        string strUserName = context.Request["UserName"] + "";
        string strPassword = context.Request["Password"] + "";

        if (string.IsNullOrEmpty(strUserName.Trim()) || string.IsNullOrEmpty(strPassword))
        {
            context.Response.StatusCode = 400;
            context.Response.Write("用户名或密码不能为空！");
            return;
        }

        try
        {

            KuaiLe.Us.BLL.UserBll bll = new KuaiLe.Us.BLL.UserBll();
            KuaiLe.Us.Model.UserModel user = bll.GetModel(strUserName);

            if (user == null)
            {
                KuaiLe.Us.Common.WebLog.WriteErrLog("用户" + strUserName + "不存在！");
                context.Response.StatusCode = 400;
                context.Response.Write("用户名" + strUserName + "不存在！");
                return;
            }

            string md5Password = Utility.Security.MD5Util.ToMD5(strPassword, 32);
            if (user.Password != md5Password)
            {
                KuaiLe.Us.Common.WebLog.WriteErrLog("用户" + strUserName + "登录密码" + strPassword + "不正确！");
                context.Response.StatusCode = 400;
                context.Response.Write("密码不正确！");
                return;
            }
            
            //判断是否需要激活
            if (user.Status < 0)
            {
                KuaiLe.Us.Common.WebLog.WriteErrLog("用户" + strUserName + "已经被冻结，无法登录！");
                context.Response.StatusCode = 400;
                context.Response.Write("帐号" + strUserName + "已经被封，无法登录！");
                return;
            }


            //判断是否需要激活
            if (user.Status == 0 && KuaiLe.Us.Common.SysConfig.IsNeedActivate)
            {
                KuaiLe.Us.Common.WebLog.WriteErrLog("用户" + strUserName + "尚未激活，无法登录！");
                context.Response.StatusCode = 400;
                context.Response.Write("帐号" + strUserName + "尚未激活！请登录邮箱激活帐号。");
                return;
            }
            
            
            user.LastLoginIP = Utility.Web.WebAgent.GetIP();    
            user.LastLoginTime = DateTime.Now;
            //登录次数
            if (user.LoginCount != null)
            {
                user.LoginCount = (int)user.LoginCount + 1;
            }
            else
            {
                user.LoginCount = 1;
            }
            //每登录一次，积分+1
            if (user.Credit != null)
            {
                user.Credit = user.Credit + 1;
            }
            else
            {
                user.Credit = user.Credit + 1;
            }
            
            //更新登录信息
            try
            {
                bll.Update(user);   //更新登录
            }
            catch (Exception ex)
            {
                KuaiLe.Us.Common.WebLog.WriteErrLog("更新" + strUserName + "登录信息异常：" + ex.Message);
            }
            
            context.Session["KL_LoginUser"] = Newtonsoft.Json.JsonConvert.SerializeObject(user);
            context.Session["KL_LoginOK"] = Utility.Security.MD5Util.ToMD5(KuaiLe.Us.Common.SysConfig.LoginOkString,32);

            KuaiLe.Us.Common.WebLog.WriteInfoLog("用户" + strUserName + "登录成功！");
            
            context.Response.StatusCode = 200;
            context.Response.Write("用户"+ strUserName +"登录成功！");
            return;
            
        }
        catch (Exception ex)
        {
            KuaiLe.Us.Common.WebLog.WriteErrLog("用户" + strUserName + "登录异常：" + ex.Message);
            context.Response.StatusCode = 400;
            context.Response.Write("未知错误，请稍后重试！或者联系客服。");
            return;
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}