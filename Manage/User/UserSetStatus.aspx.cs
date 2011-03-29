using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KuaiLe.Us.Model;
using KuaiLe.Us.BLL;
using KuaiLe.Us.Common;

public partial class Manage_User_UserSetStatus : AdminBase
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hfPreUrl.Value = Request.UrlReferrer.AbsoluteUri;
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        long userid = 0;
        int status = -9999;

        try
        {
            userid = Convert.ToInt64(QS("userid"));
        }
        catch
        {
            userid = 0;
        }
        try
        {
            status = Convert.ToInt32(ddlStatusList.SelectedValue);
        }
        catch
        {
            status = -9999;
        }

        if (userid <= 0)
        {
            AlertAndBack("userid不正确");
        }

        if (status == -9999)
        {
            AlertAndBack("status参数错误！");
        }


        try
        {
            UserModel userModel = null;
            UserBll bll = new UserBll();
            userModel = bll.GetModel(userid);
            if (userModel == null)
            {
                AlertAndBack("用户不存在");
            }

            userModel.Status = status;
            bll.Update(userModel);


        }
        catch (Exception ex)
        {
            WebLog.WriteErrLog("更新用户Status出错：" + ex.Message);
            AlertAndBack("操作失败！" + ex.Message);
        }

        string preUrl = hfPreUrl.Value + "";
        if (preUrl == "")
        {
            preUrl = "UserList.aspx";
        }
        Response.Redirect(preUrl);
    }
}
