using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using KuaiLe.Us.BLL;

public partial class Manage_Noticle_NoticeList : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int records = 0;
        DataSet dsList = new NoticeBll().GetList("", "PostTime DESC", Paging1.PageSize, Paging1.PageIndex - 1, out records);
        if (dsList != null && dsList.Tables.Count > 0)
        {
            repDataList.DataSource = dsList.Tables[0];
            repDataList.DataBind();
        }
        Paging1.InitPage(records);
    }
}
