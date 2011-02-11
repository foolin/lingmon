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
        int record = 0;
        DataSet dsList = new ArticleBll().GetList("", "ArtID DESC", Paging1.PageSize, Paging1.PageIndex - 1, out record);
        if (dsList != null && dsList.Tables.Count > 0)
        {
            repDataList.DataSource = dsList;
            repDataList.DataBind();
            Paging1.InitPage(record);
        }
    }

}
