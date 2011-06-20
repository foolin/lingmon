using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CengZai.Helper;

public partial class User_Reg2_UpdateInfo : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckLogin())
        {
            AlertAndGo("您尚未登录！", "Login.aspx?from=" + HttpUtility.UrlEncode(Request.Url + ""));
        }
    }
}
