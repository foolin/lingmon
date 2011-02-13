<%@ WebHandler Language="C#" Class="CommentAdd" %>

using System;
using System.Web;

public class CommentAdd : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";


        try
        {
            long artid = 0;
            string strComment = context.Request["Comment"] + "";


            try
            {
                artid = Convert.ToInt64(context.Request["ArtID"]);
            }
            catch (Exception ex)
            {
                KuaiLe.Us.Common.WebLog.WriteErrLog("添加评论异常：" + ex.Message);
                context.Response.StatusCode = 400;
                context.Response.Write("添加评论异常，请稍后重试！");
                return;
            }

            if (strComment.Trim() == "")
            {
                context.Response.StatusCode = 400;
                context.Response.Write("评论不能为空！");
                return;
            }

            KuaiLe.Us.BLL.ArticleBll artBll = new KuaiLe.Us.BLL.ArticleBll();
            if (!artBll.Exists(artid))
            {
                KuaiLe.Us.Common.WebLog.WriteErrLog("不存在文章ID：" + artid);
                context.Response.StatusCode = 400;
                context.Response.Write("对不起，评论失败！");
                return;
            }

            KuaiLe.Us.BLL.CommentBll commBll = new KuaiLe.Us.BLL.CommentBll();
            KuaiLe.Us.Model.CommentModel commentModel = new KuaiLe.Us.Model.CommentModel();
            commentModel.ArtID = artid;
            commentModel.Comment = strComment;
            //commentModel.CommentID = 0;
            commentModel.CreateTime = DateTime.Now;
            commentModel.DigDown = 0;
            commentModel.DigUp = 0;
            commentModel.Reports = 0;
            commentModel.Status = 0;
            commentModel.UserID = 0;
            commentModel.UserIP = Utility.Web.WebAgent.GetIP();
            commentModel.UserName = "";
            commBll.Add(commentModel);

            KuaiLe.Us.Common.WebLog.WriteInfoLog("用户发表评论成功！");
            context.Response.StatusCode = 200;
            context.Response.Write("恭喜，发表评论成功！");
            return;

        }
        catch (Exception ex)
        {
            KuaiLe.Us.Common.WebLog.WriteErrLog("发表评论异常：" + ex.Message);
            context.Response.StatusCode = 400;
            context.Response.Write("对不起，评论失败！");
            return;
        }
        
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}