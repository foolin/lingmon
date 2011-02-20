<%@ WebHandler Language="C#" Class="ArticleAdd" %>

using System;
using System.Web;
using KuaiLe.Us.Model;

public class ArticleAdd : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        try
        {
            if (context.Session["KL_LoginUser"] == null || context.Session["KL_LoginOK"] == null)
            {
                context.Response.StatusCode = 400;
                context.Response.Write("你尚未<a href='User/Login.aspx'>登录</a>！请先<a href='User/Login.aspx'>登录</a>或者<a href='User/Register.aspx'>注册</a>！");
                return;
            }

            UserModel user = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(context.Session["KL_LoginUser"].ToString());
            if (user == null)
            {
                context.Response.StatusCode = 400;
                context.Response.Write("你尚未<a href='User/Login.aspx'>登录</a>！请先<a href='User/Login.aspx'>登录</a>或者<a href='User/Register.aspx'>注册</a>！");
                return;
            }

            string strContent = context.Request["Content"] + "";
            string strChkCode = context.Request["ChkCode"] + "";
            string strReChkCode = context.Session["KL_ChkCode"] + "";

            //检查验证码
            if (strChkCode != strReChkCode)
            {
                context.Response.StatusCode = 400;
                context.Response.Write("验证码错误！输入验证码：" + strChkCode);
                //context.Response.Write("验证码错误！输入验证码：" + strChkCode + "，正确：" + strReChkCode);
                return;
            }


            //检查内容
            if (strContent.Trim().Length < 5)
            {
                context.Response.StatusCode = 400;
                context.Response.Write("内容长度不能小于5个字符！");
                return;
            }


            if (strContent.Trim().Length > 1000)
            {
                context.Response.StatusCode = 400;
                context.Response.Write("内容长度不能超过1000个字符！");
                return;
            }

            try
            {
                KuaiLe.Us.BLL.ArticleBll artBll = new KuaiLe.Us.BLL.ArticleBll();
                
                
                //判断最大提交数，防止乱发广告或者灌贴
                System.Data.DataSet dsList = artBll.GetList("UserID=" + user.UserID + " And Convert(varchar(20), CreateTime, 112)=" + DateTime.Now.ToString("yyyyMMdd"));
                int iTodayArticleCount = 0;
                int maxArticleCountOneDay = KuaiLe.Us.Common.SysConfig.PostMaxArticles;
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
                
                
                //提交内容
                strContent = HttpUtility.HtmlEncode(strContent);
                strContent = strContent.Replace(" ", "&nbsp;");
                strContent = strContent.Replace("\n", "<br />");
                
                KuaiLe.Us.Model.ArticleModel artModel = new KuaiLe.Us.Model.ArticleModel();
                artModel.Comments = 0;
                artModel.Content = strContent;
                artModel.CreateTime = DateTime.Now;
                artModel.DigDown = 0;
                artModel.DigUp = 0;
                artModel.Hits = 0;
                artModel.IsAnonym = 0;
                artModel.Reports = 0;
                artModel.Status = 0;
                artModel.Tags = "";
                artModel.Title = "";
                artModel.UserID = user.UserID;
                artModel.UserIP = Utility.Web.WebAgent.GetIP();

                
                artBll.Add(artModel);

                KuaiLe.Us.Common.WebLog.WriteInfoLog("用户[" + user.UserID + ":" + user.UserName + "]发表文章成功！");

                context.Response.StatusCode = 200;
                context.Response.Write("恭喜，发表成功！您的内容需要审核才能发布，请确定您的内容符合本站规定，否则会造成审核不通过！谢谢！");
                return;
            }
            catch (Exception ex)
            {

                KuaiLe.Us.Common.WebLog.WriteErrLog("用户[" + user.UserID + ":" + user.UserName + "]发表文章异常：" + ex.Message);
                KuaiLe.Us.Common.WebLog.WriteErrLog("----- 文章内容Begin -----------");
                KuaiLe.Us.Common.WebLog.WriteErrLog(strContent);
                KuaiLe.Us.Common.WebLog.WriteErrLog("----- 文章内容End -----------");

                context.Response.StatusCode = 400;
                context.Response.Write("发表失败！未知错误，请检查是否存在非法字符！");
                return;
            }
        }
        catch (Exception ex)
        {
            KuaiLe.Us.Common.WebLog.WriteErrLog("用户发表文章导致异常：" + ex.Message);
            KuaiLe.Us.Common.WebLog.WriteErrLog("----- 文章内容Begin -----------");
            KuaiLe.Us.Common.WebLog.WriteErrLog(context.Request["Content"]);
            KuaiLe.Us.Common.WebLog.WriteErrLog("----- 文章内容End -----------");

            context.Response.StatusCode = 400;
            context.Response.Write("发表失败！未知错误，请检查是否存在非法字符！");
            return;
        }
       
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}