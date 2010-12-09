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
using LFL.Favorite.BLL;

public partial class User_ChkHasUser : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write(new UserBll().Exists(QS("username"), QS("email")));
    }
}
