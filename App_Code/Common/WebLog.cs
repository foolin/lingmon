using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Utility.IO;
using Utility.Web;



namespace KuaiLe.Us.Common
{
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
            if (!SysConfig.IsWriteLog)
            {
                return;
            }
            Log.WriteMessage(WebAgent.ToFullPath(SysConfig.LogPath + "\\Err"), "Msg:" + msg + ", URL:" + WebAgent.GetURL());
            //Log.WriteMessage("SiteLogs\\ErrLog", errMsg);
        }

        public static void WriteInfoLog(string msg)
        {
            if (!SysConfig.IsWriteLog)
            {
                return;
            }
            Log.WriteMessage(WebAgent.ToFullPath(SysConfig.LogPath + "\\Info"), "Msg:" + msg + ", URL:" + WebAgent.GetURL());
            //Log.WriteMessage("SiteLogs\\InfoLog", msg);
        }

    }

}
