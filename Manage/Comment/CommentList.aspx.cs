using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using KuaiLe.Us.BLL;

public partial class Manage_Comment_CommentList : AdminBase
{
    public int ArtID = 0;
    public string type = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        ArtID = QSInt("ArtID");
        type = QS("type");
        if (!IsPostBack)
        {
            BindDataList();
        }
    }


    protected void BindDataList()
    {
        string sqlWhere = "";
        switch (type.ToLower().Trim())
        {
            case "uncheck":
                sqlWhere += " Status = 0 ";
                break;
            case "check":
                sqlWhere += " Status = 1 ";
                break;
            case "report":
                sqlWhere += " Reports>0 and Status>-1 ";
                break;
            case "trash":
                sqlWhere += " Status = -1 ";
                break;
            default:
                break;
        }

        if (ArtID != 0)
        {
            if (sqlWhere != "")
            {
                sqlWhere += " And ";
            }
            sqlWhere += " ArtID=" + ArtID + " ";
        }

        int records = 0;
        DataSet dsList = new CommentBll().GetList(sqlWhere, "CreateTime DESC", Paging1.PageSize, Paging1.PageIndex - 1, out records);
        if (dsList != null && dsList.Tables.Count > 0)
        {
            repDataList.DataSource = dsList.Tables[0];
            repDataList.DataBind();
        }
        Paging1.InitPage(records);

    }



    public string GetStatusDesc(object status, object cmmid)
    {

        int iStatus = -9999;
        try
        {
            iStatus = Convert.ToInt32(status);
        }
        catch
        {
            return "未知";
        }

        string strStatus = "未知";
        switch (iStatus)
        {
            case -1:
                strStatus = " <u><font color='gray'>已删除</font></u> |  "
                    + " <a href='CmmSetStatus.aspx?id=" + cmmid + "&status=0'>还原为未审核</a> | "
                    + " <a href='CmmSetStatus.aspx?id=" + cmmid + "&status=1'>还原为已审核</a> ";
                break;
            case 0:
                strStatus = " <font color='red'>未审核</font> |  "
                    + " <a href='CmmSetStatus.aspx?id=" + cmmid + "&status=1'>通过审核</a> | "
                    + " <a href='CmmSetStatus.aspx?id=" + cmmid + "&status=-1' onclick='return confirm(\"确定删除？\")'>删除</a> ";
                break;
            case 1:
                strStatus = " <font color='#090'>已审核 √</font> |  "
                    + " <a href='CmmSetStatus.aspx?id=" + cmmid + "&status=0'>取消审核</a> | "
                    + " <a href='CmmSetStatus.aspx?id=" + cmmid + "&status=-1' onclick='return confirm(\"确定删除？\")'>删除</a> ";
                break;
        }

        return strStatus;
    }


}
