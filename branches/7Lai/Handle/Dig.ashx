<%@ WebHandler Language="C#" Class="Dig" %>

using System;
using System.Web;

public class Dig : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        long iSrcID = 0;
        int iDigType = 0;
        string strSrcType = context.Request["SrcType"] + "";
        try
        {
            iSrcID = Convert.ToInt64(context.Request["SrcID"]);
            iDigType = Convert.ToInt32(context.Request["DigType"]);
        }
        catch
        {
            context.Response.StatusCode = 400;
            context.Response.Write("对不起，id参数错误！");
            return;
        }

        if (iSrcID <= 0 || iDigType < 0 || iDigType > 2)
        {
            context.Response.StatusCode = 400;
            context.Response.Write("对不起，参数错误！");
            return;
        }

        bool isComment = false;
        if (strSrcType.Trim().ToLower() == KuaiLe.Us.Model.SrcType.Comment.ToString().ToLower())
        {
            isComment = true;
        }
        else if (strSrcType.Trim().ToLower() == KuaiLe.Us.Model.SrcType.Article.ToString().ToLower())
        {
            isComment = false;
        }
        else
        {
            strSrcType = KuaiLe.Us.Model.SrcType.Article.ToString();
            isComment = false;
        }


        try
        {
            string strUserIP = Utility.Web.WebAgent.GetIP();
            KuaiLe.Us.BLL.DigBll digBll = new KuaiLe.Us.BLL.DigBll();
            System.Data.DataSet dsDigList = null;
            string strWhere = "SrcID=" + iSrcID + " And SrcType='" + strSrcType + "' And UserIP='" + strUserIP + "' And DigTime>='" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            //如果是举报
            if (iDigType == 2)
            {
                strWhere += " And DigType=2";
            }
            dsDigList = digBll.GetList(strWhere);
            if (dsDigList != null && dsDigList.Tables[0].Rows.Count > 0)
            {
                context.Response.StatusCode = 400;
                context.Response.Write("对不起，您已经操作过，切勿重复操作！");
                return;
            }


            if (isComment)
            {
                KuaiLe.Us.Model.CommentModel commentModel = null;
                KuaiLe.Us.BLL.CommentBll commentBll = new KuaiLe.Us.BLL.CommentBll();
                commentModel = commentBll.GetModel(iSrcID);
                if (commentModel == null)
                {
                    KuaiLe.Us.Common.WebLog.WriteErrLog("不存在ID" + iSrcID + "的评论。");
                    context.Response.StatusCode = 400;
                    context.Response.Write("对不起，不存在该评论！");
                    return;
                }
                if (iDigType == 1)  //踩
                {
                    commentModel.DigDown = commentModel.DigDown + 1;
                }
                else if (iDigType == 2) //举报
                {
                    commentModel.Reports = commentModel.Reports + 1;
                }
                else //顶
                {
                    commentModel.DigUp = commentModel.DigUp + 1;
                }
                commentBll.Update(commentModel);
                //KuaiLe.Us.Common.WebLog.WriteInfoLog("更新评论踩、顶、举报成功！");
            }
            else
            {
                KuaiLe.Us.Model.ArticleModel artModel = null;
                KuaiLe.Us.BLL.ArticleBll artBll = new KuaiLe.Us.BLL.ArticleBll();
                artModel = artBll.GetModel(iSrcID);
                if (artModel == null)
                {
                    KuaiLe.Us.Common.WebLog.WriteErrLog("不存在ID" + iSrcID + "的文章。");
                    context.Response.StatusCode = 400;
                    context.Response.Write("对不起，不存在该文章！");
                    return;
                }
                if (iDigType == 1)  //踩
                {
                    artModel.DigDown = artModel.DigDown + 1;
                }
                else if (iDigType == 2) //举报
                {
                    artModel.Reports = artModel.Reports + 1;
                }
                else //顶
                {
                    artModel.DigUp = artModel.DigUp + 1;
                }
                artBll.Update(artModel);
                //KuaiLe.Us.Common.WebLog.WriteInfoLog("更新文章踩、顶、举报成功！");
            }
            
            
            KuaiLe.Us.Model.DigModel digModel = new KuaiLe.Us.Model.DigModel();
            digModel.DigID = 0;
            digModel.DigType = iDigType;
            digModel.SrcID = iSrcID;
            digModel.SrcType = strSrcType;
            digModel.UserID = 0;
            digModel.UserIP = strUserIP;
            digModel.DigTime = DateTime.Now;
            digBll.Add(digModel);

            //KuaiLe.Us.Common.WebLog.WriteInfoLog("插入踩、顶、举报成功！");
            context.Response.StatusCode = 200;
            context.Response.Write("恭喜，您的操作已经成功！");
            return;
            
        }
        catch (Exception ex)
        {
            KuaiLe.Us.Common.WebLog.WriteErrLog("操作顶/踩/举报异常：" + ex.Message);
            context.Response.StatusCode = 400;
            context.Response.Write("对不起，系统出现错误，请稍后重试！");
            return;
        }
        
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}