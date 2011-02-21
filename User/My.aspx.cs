using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KuaiLe.Us.Model;

public partial class User_My : PageBase
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (GB_LoginUser == null)
        {
            Response.Redirect("../Default.aspx");
        }
    }



    public string GetSexName(object sex)
    {
        return UserModel.GetSexName(sex);
    }

    public string GetStatusName(object status)
    {
        return UserModel.GetStatusName(status);
    }

}
