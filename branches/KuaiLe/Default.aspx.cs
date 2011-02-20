using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using KuaiLe.Us.BLL;

public partial class _Default : PageBase
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (!IsPostBack)
        {
            InitDataBind();
            
            if (GB_LoginUser != null)
            {
                idDefaultSiderLogin.Visible = false;
                idDefaultSiderRegister.Visible = false;
            }
        }
    }


    protected void InitDataBind()
    {
        string type = "";   //列表类型
        int userID = -1;

        type = QS("type").ToLower().Trim();
        userID = QSInt("userid");

        
        string strWhere = " (Status> 0 Or  (Status = 0 And CreateTime<='" + DateTime.Now.AddMinutes(-10) + "') )";
        string strOrder = "ArtID DESC";
        if (userID > 0)
        {
            strWhere += " And UserID=" + userID + " ";
        }

        if (type == "new")
        {
            strOrder = " CreateTime desc ";
        }
        else if (type == "hot")
        {
            strOrder = " (IsNull(DigUp,0) + IsNull(DigDown,0)) desc ";
        }
        else if (type == "up")
        {
            strOrder = " DigUp desc ";
        }
        else if (type == "down")
        {
            strOrder = " DigDown desc ";
        }
        else if (type == "comments")
        {
            strOrder = " Comments desc ";
        }

        int record = 0;
        DataSet dsList = new ArticleBll().GetList(strWhere, strOrder, Paging1.PageSize, Paging1.PageIndex - 1, out record);
        if (dsList != null && dsList.Tables.Count > 0)
        {
            repDataList.DataSource = dsList;
            repDataList.DataBind();
            Paging1.InitPage(record);
        }
    }

}
