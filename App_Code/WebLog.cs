using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using LFL.Utility.IO;
using LFL.Utility.Web;

/// <summary>
///WebLog 的摘要说明
/// </summary>
public class WebLog
{
    public WebLog()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public static void WriteErrLog(string msg)
    {
        Log.WriteMessage("Logs\\ErrLog", "Msg:" + msg + ", User:Admin" + ", URL:" + WebAgent.GetURL());
        //Log.WriteMessage("SiteLogs\\ErrLog", errMsg);
    }

    public static void WriteInfoLog(string msg)
    {
        Log.WriteMessage("Logs\\InfoLog", "Msg:" + msg + ", User：Admin" + ", URL:" + WebAgent.GetURL());
        //Log.WriteMessage("SiteLogs\\InfoLog", msg);
    }

}
