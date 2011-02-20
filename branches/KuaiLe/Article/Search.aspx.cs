using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using KuaiLe.Us.BLL;

public partial class Article_Search : PageBase
{
    public string keyword = ""; //搜索关键词

    protected void Page_Load(object sender, EventArgs e)
    {
        keyword = QS("keyword").ToLower().Trim();

        if (!IsPostBack)
        {
            if (keyword == "")
            {
                return;
            }
            InitDataBind();
        }
    }



    protected void InitDataBind()
    {
        int userID = -1;

        
        userID = QSInt("userid");


        string strWhere = " (Status> 0 Or  (Status = 0 And CreateTime<='" + DateTime.Now.AddMinutes(-10) + "') )";
        string strOrder = "ArtID DESC";
        if (userID > 0)
        {
            strWhere += " And UserID=" + userID + " ";
        }

        if (keyword != "")
        {
            strWhere += " And Content like '%" + keyword + "%' ";
        }

        int record = 0;
        DataSet dsList = new ArticleBll().GetList(strWhere, strOrder, Paging1.PageSize, Paging1.PageIndex - 1, out record);
        if (dsList != null && dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
        {
            repDataList.DataSource = dsList;
            repDataList.DataBind();
            Paging1.InitPage(record);
        }
        else
        {
            Paging1.InitPage(0);
            divNoFound.Visible = true;
        }
    }

}
