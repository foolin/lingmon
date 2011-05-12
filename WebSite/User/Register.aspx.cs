using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CengZai.Helper;

public partial class User_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ibRegister_Click(object sender, ImageClickEventArgs e)
    {
        AjaxJscript.Alert("注册成功！");
        return;
    }
}
