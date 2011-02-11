using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
///WucBase 的摘要说明
/// </summary>
public class WucBase : System.Web.UI.UserControl
{
    public string GB_SitePath = Utility.Web.WebAgent.GetDomainURL();


    public WucBase()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
}
