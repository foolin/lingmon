<%@ WebHandler Language="C#" Class="CheckEmail" %>

using System;
using System.Web;

public class CheckEmail : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //string email = 
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}