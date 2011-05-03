using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KuaiLe.Us.BLL;

public partial class Manage_Noticle_NoticeDel : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if ((Request["id"] + "") != "")
        {
            try
            {
                id = Convert.ToInt32(Request["id"]);
            }
            catch { }
            if (id > 0)
            {
                try
                {
                    //删除
                    new NoticeBll().Delete(id);

                    string strUrl = Request.UrlReferrer + "";
                    if(string.IsNullOrEmpty(strUrl))
                    {
                        strUrl = "NoticeList.aspx";
                    }
                    AlertAndRefresh("删除成功！", strUrl);
                }
                catch (Exception ex)
                {
                    AlertAndBack("删除失败！异常：" + ex.Message);
                }
            }
            else
            {
                AlertAndBack("id不正确，无法删除");
            }
        }

    }
}
