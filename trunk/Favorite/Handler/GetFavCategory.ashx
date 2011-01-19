<%@ WebHandler Language="C#" Class="GetFavCategory" %>

using System;
using System.Web;

public class GetFavCategory : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {

        System.Text.StringBuilder content = new System.Text.StringBuilder();
        content.Append("[{'id':'1','text':'测试'}, {'id':'1','text':'测试'}]");
        
        context.Response.ContentType = "text/plain";
        context.Response.Write(content.ToString());
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}