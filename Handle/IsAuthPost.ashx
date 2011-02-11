<%@ WebHandler Language="C#" Class="IsAuthPost" %>

using System;
using System.Web;
using KuaiLe.Us.Model;

public class IsAuthPost : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.StatusCode = 200;

        if (context.Session["KL_LoginUser"] == null || context.Session["KL_LoginOK"] == null)
        {
            context.Response.StatusCode = 400;
            context.Response.Write("你尚未<a href='User/Login.aspx'>登录</a>！请先<a href='User/Login.aspx'>登录</a>或者<a href='User/Register.aspx'>注册</a>！");
            return;
        }
        
        //判断用户是否存在
        UserModel user = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(context.Session["KL_LoginUser"].ToString());
        if (user == null)
        {
            context.Response.StatusCode = 400;
            context.Response.Write("你尚未<a href='User/Login.aspx'>登录</a>！请先<a href='User/Login.aspx'>登录</a>或者<a href='User/Register.aspx'>注册</a>！");
            return;
        }
    
        
        //判断用户当天能提交文章数
        KuaiLe.Us.BLL.ArticleBll artBll = new KuaiLe.Us.BLL.ArticleBll();
        //判断最大提交数，防止乱发广告或者灌贴
        System.Data.DataSet dsList = artBll.GetList("UserID=" + user.UserID + " And Convert(varchar(20), CreateTime, 112)=" + DateTime.Now.ToString("yyyyMMdd"));
        int iTodayArticleCount = 0;
        int maxArticleCountOneDay = KuaiLe.Us.Common.SysConfig.UserMaxArticleCount;
        if (dsList != null && dsList.Tables[0] != null)
        {
            iTodayArticleCount = dsList.Tables[0].Rows.Count;
        }

        if (iTodayArticleCount >= maxArticleCountOneDay)
        {
            context.Response.StatusCode = 400;
            context.Response.Write("您今天已经提交" + iTodayArticleCount + "条内容，已经超过每天限制" + maxArticleCountOneDay + "条！为了防止广告贴，请明天再提交。你可以继续欣赏别人的快乐...");
            return;
        }
                
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}