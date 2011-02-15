using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KuaiLe.Us.Model;
using KuaiLe.Us.BLL;
using KuaiLe.Us.Common;
using Utility.Web;

public partial class Manage_Article_ArtSetStatus : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        long id = 0;
        int status = -9999;

        try
        {
            id = Convert.ToInt64(QS("id"));
        }
        catch
        {
            id = 0;
        }
        try
        {
            status = Convert.ToInt32(QS("status"));
        }
        catch
        {
            status = -9999;
        }

        if (id <= 0)
        {
            AlertAndBack("id不正确");
        }

        if (status == -9999)
        {
            AlertAndBack("status参数错误！");
        }


        try
        {
            ArticleModel artModel = null;
            ArticleBll bll = new ArticleBll();
            artModel = bll.GetModel(id);
            if (artModel == null)
            {
                AlertAndBack("文章不存在");
            }

            artModel.Status = status;
            bll.Update(artModel);
            

        }
        catch (Exception ex)
        {
            WebLog.WriteErrLog("更新文章Status出错：" + ex.Message);
            AlertAndBack("操作失败！" + ex.Message);
        }

        Response.Redirect(Request.UrlReferrer.AbsoluteUri);

    }
}
