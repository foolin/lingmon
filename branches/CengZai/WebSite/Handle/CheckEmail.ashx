<%@ WebHandler Language="C#" Class="CheckEmail" %>

using System;
using System.Web;
using CengZai.Helper;
using CengZai.BLL;

public class CheckEmail : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string preUrl = context.Request.UrlReferrer + "";
        if (string.IsNullOrEmpty(preUrl) || preUrl.ToLower().IndexOf(Config.SiteDomain.ToLower()) == -1)
        {
            context.Response.StatusCode = 400;
            context.Response.Write("网址非法！");
            return;
        }
        
        string email = context.Request["email"] + "";
        if (string.IsNullOrEmpty(email.Trim()))
        {
            context.Response.StatusCode = 400;
            context.Response.Write("邮箱不能为空");
            return;
        }
        
        bool isExist = false;
        try
        {
            UserBll bll = new UserBll();
            //isExist = bll.Exists(email);
        }
        catch(Exception ex)
        {
            Log.Add("检查用用异常：" + ex.Message);
            context.Response.StatusCode = 400;
            context.Response.Write("邮箱不合法，检查异常");
            return;
        }

        if (isExist)
        {
            context.Response.StatusCode = 400;
            context.Response.Write("该邮箱已注册，请使用其它邮箱");
            return;
        }

        context.Response.StatusCode = 200;
        context.Response.Write("该邮箱可以注册");
        return;
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}