using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using KuaiLe.Us.Common;
using KuaiLe.Us.Model;
using Newtonsoft.Json;

/// <summary>
///PageBase 的摘要说明
/// </summary>
public class PageBase : System.Web.UI.Page
{

    public UserModel GB_LoginUser = null;

	public PageBase()
	{
		//
		//TODO: 在此处添加构造函数逻辑

        
	}


    protected override void OnPreLoad(EventArgs e)
    {
        if (Session["KL_LoginUser"] != null && Session["KL_LoginOK"] != null)
        {
            GB_LoginUser = JsonConvert.DeserializeObject<UserModel>(Session["KL_LoginUser"].ToString());
        }
        else
        {
            Session["KL_LoginUser"] = null;
            Session["KL_LoginOK"] = null;
        }
    }

    /// <summary>
    /// 获取Request.QueryString参数
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    protected string QS(string key)
    {
        return Request[key] + "";
    }

    /// <summary>
    /// 获取Request.QueryString参数
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    protected int QSInt(string key)
    {
        int iReturn = -1;
        try
        {
            iReturn = Convert.ToInt32(Request[key] + "");
        }
        catch
        {
            iReturn = -1;
        }

        return iReturn;
    }

    public string GetContactMail()
    {
        return SysConfig.Contact;
    }


    

}
