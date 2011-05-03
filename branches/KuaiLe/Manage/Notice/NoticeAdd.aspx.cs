using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KuaiLe.Us.Model;
using KuaiLe.Us.BLL;
using Utility.Web;
using KuaiLe.Us.Common;

public partial class Manage_Noticle_NoticeAdd : AdminBase
{
    private int id = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Request["id"] + "") != "")
        {
            try
            {
                id = Convert.ToInt32(Request["id"]);
            }
            catch { }
        }

        if (!IsPostBack)
        {
            if (id > 0)
            {
                NoticeModel model = new NoticeBll().GetModel(id);
                if (model == null)
                {
                    WebAgent.AlertAndBack("该公告不存在！");
                    return;
                }

                tbTitle.Text = model.Title;
                tbContent.Text = Helper.DeHtml(model.Content);
                tbAuthor.Text = model.Author;
            }
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        NoticeModel model = null;
        NoticeBll bll = new NoticeBll();
        if (id > 0)
        {
            model = bll.GetModel(id);
        }
        else
        {
            model = new NoticeModel();
        }

        model.Title = tbTitle.Text;
        model.Content = Helper.EnHtml(tbContent.Text);
        model.Author = tbAuthor.Text;
        model.PostIP = WebAgent.GetIP();
        model.PostTime = DateTime.Now;

        try
        {
            if (id > 0)
            {
                bll.Update(model);
            }
            else
            {
                bll.Add(model);
            }
        }
        catch (Exception ex)
        {
            WebAgent.AlertAndBack("操作失败，异常：" + ex.Message);
        }

        WebAgent.AlertAndGo("操作成功！", "NoticeList.aspx");
    }
}
