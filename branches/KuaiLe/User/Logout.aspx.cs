using System;
using System.Web;


public partial class User_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["KL_LoginUser"] = null;
        Session["KL_LoginOK"] = null;
        Response.Redirect("../Default.aspx");
    }
}
