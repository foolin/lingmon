<%@ WebHandler Language="C#" Class="CommentList" %>

using System;
using System.Web;
using System.Data;

public class CommentList : IHttpHandler
{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        int page = 0;
        int artid = 0;

        try
        {
            artid = Convert.ToInt32(context.Request["ArtID"]);
        }
        catch
        {
            KuaiLe.Us.Common.WebLog.WriteErrLog("获取评论列表错误,ArtID：" + context.Request["ArtID"]);
            context.Response.StatusCode = 200;
            context.Response.Write("对不起，参数错误！");
            return;
        }
        if (artid == 0)
        {
            context.Response.StatusCode = 200;
            context.Response.Write("对不起，参数错误！");
            return;
        }
        
        try
        {
            page = Convert.ToInt32(context.Request["Page"]);
        }
        catch
        {
            page = 0;
        }

        System.Text.StringBuilder contentList = new System.Text.StringBuilder();
        int listCount = 5;
        DataSet dsList = new KuaiLe.Us.BLL.CommentBll().GetList(listCount, " ArtID=" + artid + " And Status >= 0", " CreateTime Desc");
        if (dsList != null && dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
        {
            contentList.Append("<dl>");
            int n = 0;
            foreach (DataRow row in dsList.Tables[0].Rows)
            {
                string strUserName = row["UserName"] + "";
                if (strUserName.Trim() == "")
                {
                    strUserName = "匿名";
                }
                contentList.Append("<dt>第" + (++n) + "楼：" + strUserName + " 发布于" + row["CreateTime"] + "</dt>");
                contentList.Append("<dd>" + row["Comment"] + "</dd>");
            }
            contentList.Append("</dl>");
            if (dsList.Tables[0].Rows.Count >= listCount)
            {
                contentList.Append("<div> <a href=\"#\" onclick=\"window.top.location.href=KL_ROOT + '/Article/Article.aspx?ArtID=" + artid + "'\">更多评论>></a> </div>");
            }
        }
        else
        {
            contentList.Append(" 暂无评论！快快发表第一个评论吧！ ");
        }

        context.Response.StatusCode = 200;
        context.Response.Write(contentList.ToString());
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}