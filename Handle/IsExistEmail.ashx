<%@ WebHandler Language="C#" Class="IsExistEmail" %>

using System;
using System.Web;

public class IsExistEmail : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.StatusCode = 200;
        
        string strEmail = context.Request["Email"];
        if (string.IsNullOrEmpty(strEmail) ||  !Utility.Web.WebAgent.IsEmail(strEmail))
        {
            context.Response.Write("邮箱不合法！");
            return;
        }
        bool isHasEmail = new KuaiLe.Us.BLL.UserBll().ChkEmail(strEmail);
        if (isHasEmail)
        {
            context.Response.Write("邮箱已经注册！");
            return;
        }

        
        context.Response.Write("1");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}