using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KuaiLe.Us.Model;
using Utility.Web;
using KuaiLe.Us.BLL;
using KuaiLe.Us.Common;

public partial class Article_Article : PageBase
{
    public ArticleModel Article = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        int artID = QSInt("artid");
        if (artID == 0)
        {
            WebAgent.AlertAndGo("不存在该文章！", "../");
            return;
        }

        //读取Article
        ArticleBll bll = new ArticleBll();
        try
        {
            Article = bll.GetModel(artID);
        }
        catch (Exception ex)
        {
            WebLog.WriteErrLog("读取ArticleModel出错：" + ex.Message);
        }

        if (Article == null || Article.Status < 0)
        {
            WebAgent.AlertAndGo("不存在该文章！", "../");
            return;
        }
        else if (SysConfig.VerifyArticle && Article.Status == 0)
        {
            WebAgent.AlertAndGo("该文章尚未通过审核！", "../");
            return;
        }

    }


    /// <summary>
    /// 取标题
    /// </summary>
    /// <param name="title"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    public string GetTitle(string title, string content)
    {
        title = title + "";
        if (title == "" && !string.IsNullOrEmpty(content))
        {
            title = Helper.GetFirstLine(content, 20);
        }

        return title;
    }


    public string GetUserName(long userid)
    {
        return new UserBll().GetUserName(userid);
    }

}
