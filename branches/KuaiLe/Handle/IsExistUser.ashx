<%@ WebHandler Language="C#" Class="IsExistUser" %>

using System;
using System.Web;

public class IsExistUser : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.StatusCode = 200;
        
        string strUserName = context.Request["UserName"];

        if (string.IsNullOrEmpty(strUserName))
        {
            context.Response.Write("用户名为空！");
            return;
        }
        bool isHasUser = new KuaiLe.Us.BLL.UserBll().Exists(strUserName);
        if (isHasUser)
        {
            context.Response.Write("用户名已经存在！");
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