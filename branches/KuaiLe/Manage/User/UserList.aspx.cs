using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using KuaiLe.Us.BLL;
using KuaiLe.Us.Model;


public partial class Manage_User_UserList : AdminBase
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDataList();
        }
    }

    public void BindDataList()
    {

        DataSet dsList = null;
        int records = 0;
        string strWhere = "";
        string type = QS("type").ToLower().Trim();

        if (type == "notrash")
        {
            strWhere = " Status >= 0 "; //普通用户
        }
        else if( type == "trash")
        {
            strWhere = " Status < 0 ";  //冻结或者封号
        }
        else if (type == "vip")
        {
            strWhere = " Status >= 2 "; //vip
        }
        else if (type == "activate")
        {
            strWhere = " Status = 1 ";  //已激活
        }
        else if (type == "noactivate")
        {
            strWhere = " status = 0";   //未激活
        }

        try
        {
            dsList = new UserBll().GetList(strWhere, "UserID DESC", Paging1.PageSize, Paging1.PageIndex - 1, out records);
            if (dsList != null && dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
            {
                repDataList.DataSource = dsList.Tables[0];
                repDataList.DataBind();
            }
            Paging1.InitPage(records);
        }
        catch (Exception ex)
        {
            AlertAndBack("出错！异常：" + ex.Message);
        }
    }


    /// <summary>
    /// 取性别
    /// </summary>
    /// <param name="sex"></param>
    /// <returns></returns>
    public string GetSexName(object sex)
    {

        return UserModel.GetSexName(sex);

    }

    /// <summary>
    /// 取状态
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    public string GetStatusName(object status)
    {

        return UserModel.GetStatusName(status);

    }

}
