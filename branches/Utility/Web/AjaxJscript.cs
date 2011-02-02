using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Utility.Web
{
    public class AjaxJscript
    {
        #region old function
        /// <summary>
        /// 弹出JavaScript小窗口
        /// </summary>
        /// <param name="ctrl">Ajax页面传入UpdatePanel或者普通页面传入Page</param>
        /// <param name="message">窗口信息</param>
        public static void Alert(Control ctrl, string message)
        {
            #region
            ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), "updateScript", "alert('" + message + "');", true);
            #endregion
        }

        /// <summary>
        /// 弹出消息框并且转向到新的URL
        /// </summary>
        /// <param name="ctrl">Ajax页面传入UpdatePanel或者普通页面传入Page</param>
        /// <param name="message">消息内容</param>
        /// <param name="toURL">连接地址</param>
        public static void AlertAndRedirect(Control ctrl, string message, string toURL)
        {
            #region
            string js = "alert('{0}');window.location.replace('{1}');";
            ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), "updateScript", string.Format(js, message, toURL), true);
            #endregion
        }

        /// <summary>
        /// 回到历史页面
        /// </summary>
        /// <param name="ctrl">Ajax页面传入UpdatePanel或者普通页面传入Page</param>
        /// <param name="value">-1/1</param>
        public static void GoHistory(Control ctrl, int value)
        {
            #region
            string js = "history.go({0});";
            ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), "updateScript", string.Format(js, value), true);
            #endregion
        }

        /// <summary>
        /// 关闭当前窗口
        /// </summary>
        /// <param name="ctrl">Ajax页面传入UpdatePanel或者普通页面传入Page</param>
        public static void CloseWindow(Control ctrl)
        {
            #region
            string js = "parent.opener=null;window.close();";
            ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), "updateScript", js, true);
            #endregion
        }

        /// <summary>
        /// 刷新父窗口
        /// </summary>
        /// <param name="ctrl">Ajax页面传入UpdatePanel或者普通页面传入Page</param>
        public static void RefreshParent(Control ctrl, string url)
        {
            #region
            string js = "window.opener.location.href='" + url + "';window.close();";
            ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), "updateScript", js, true);
            #endregion
        }

        /// <summary>
        /// 刷新打开窗口
        /// </summary>
        /// <param name="ctrl">Ajax页面传入UpdatePanel或者普通页面传入Page</param>
        public static void RefreshOpener(Control ctrl)
        {
            #region
            string js = @"
                        var url=opener.location.href;
                        if(url.lastIndexOf('#')==url.length-1){
                            opener.location.href=url.substring(0,url.length-1);
                        }
                        else{
                            opener.location.href=url;
                        }";
            ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), "updateScript", js, true);
            #endregion
        }

        /// <summary>
        /// 打开指定大小的新窗体
        /// </summary>
        /// <param name="ctrl">Ajax页面传入UpdatePanel或者普通页面传入Page</param>
        /// <param name="url">地址</param>
        /// <param name="width">宽</param>
        /// <param name="heigth">高</param>
        /// <param name="top">头位置</param>
        /// <param name="left">左位置</param>
        public static void OpenWebFormSize(Control ctrl, string url, int width, int heigth, int top, int left)
        {
            #region
            string js = "window.open('" + url + @"','','height=" + heigth + ",width=" + width + ",top=" + top + ",left=" + left + ",location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');";
            ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), "updateScript", js, true);
            #endregion
        }

        /// <summary>
        /// 转向Url制定的页面
        /// </summary>
        /// <param name="ctrl">Ajax页面传入UpdatePanel或者普通页面传入Page</param>
        /// <param name="url">连接地址</param>
        public static void JavaScriptLocationHref(Control ctrl, string url)
        {
            #region
            string js = @"window.location.replace('{0}');";
            ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), "updateScript", string.Format(js, url), true);
            #endregion
        }

        /// <summary>
        /// 打开指定大小位置的模式对话框（just for IE）
        /// </summary>
        /// <param name="ctrl">Ajax页面传入UpdatePanel或者普通页面传入Page</param>
        /// <param name="webFormUrl">连接地址</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <param name="top">距离上位置</param>
        /// <param name="left">距离左位置</param>
        public static void ShowModalDialogWindow(Control ctrl, string webFormUrl, int width, int height, int top, int left)
        {
            #region
            string features = "dialogWidth:" + width.ToString() + "px"
                + ";dialogHeight:" + height.ToString() + "px"
                + ";dialogLeft:" + left.ToString() + "px"
                + ";dialogTop:" + top.ToString() + "px"
                + ";center:yes;help=no;resizable:no;status:no;scroll=yes";
            ShowModalDialogWindow(ctrl, webFormUrl, features);
            #endregion
        }

        /// <summary>
        /// 打开指定大小位置的模式对话框（just for IE）
        /// </summary>
        /// <param name="ctrl">Ajax页面传入UpdatePanel或者普通页面传入Page</param>
        /// <param name="webFormUrl">连接地址</param>
        /// <param name="features">参数</param>
        public static void ShowModalDialogWindow(Control ctrl, string webFormUrl, string features)
        {
            string js = ShowModalDialogJavascript(webFormUrl, features);
            ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), "updateScript", js, true);
        }

        /// <summary>
        /// run the JavaScript when object loaded(also suitable for AJAX)
        /// </summary>
        /// <param name="ctrl">object ctrl:Page or UpdatePanel</param>
        /// <param name="strScript">the script text or script function name for running</param>
        public static void RunScript(Control ctrl, string strScript)
        {
            ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), "runScript", strScript, true);
        }

        /// <summary>
        /// include a JavaScript file to a page
        /// </summary>
        /// <param name="page">the page class entity</param>
        /// <param name="strScriptURL">the url of script file</param>
        public static void IncludeScript(Page page, string strScriptURL)
        {
            ScriptManager.RegisterClientScriptInclude(page, page.GetType(), "includeScript", strScriptURL);
        }

        /// <summary>
        /// write a JavaScript to a page
        /// </summary>
        /// <param name="page">the page class entity</param>
        /// <param name="strScript">the script text to write</param>
        public static void WriteScript(Page page, string strScript)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "scriptBlock", strScript, true);
        }
        #endregion

        #region the function

        #region get object instance
        /// <summary>
        /// get the object System.Web.UI.Control that is converted from object System.Web.IHttpHandler which is in current process
        /// </summary>
        private static Control ctrl
        {
            get { return (Control)HttpContext.Current.CurrentHandler; }
        }

        /// <summary>
        /// get the object System.Web.UI.Page that is converted from object System.Web.IHttpHandler which is in current process
        /// </summary>
        private static Page page
        {
            get { return (Page)HttpContext.Current.CurrentHandler; }
        }
        #endregion

        /// <summary>
        /// pop up a info box
        /// </summary>
        /// <param name="message">the message for user</param>
        public static void Alert(string message)
        {
            #region
            ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), message.GetHashCode().ToString(), "alert('" + message.Replace("'", "\"") + "');", true);
            #endregion
        }

        /// <summary>
        /// pop up a info box and trun to a new page
        /// </summary>
        /// <param name="message">the message for user</param>
        /// <param name="toURL">the relocation url</param>
        public static void AlertAndRedirect(string message, string toURL)
        {
            #region
            string js = "alert('{0}');window.location.replace('{1}');";
            ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), message.GetHashCode().ToString(), string.Format(js, message.Replace("'", "\""), toURL), true);
            #endregion
        }

        /// <summary>
        /// go back to a page in histroy
        /// </summary>
        /// <param name="value">-1/1</param>
        public static void GoHistory(int value)
        {
            #region
            string js = "history.go({0});";
            ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), ctrl.ClientID.ToString(), string.Format(js, value), true);
            #endregion
        }

        /// <summary>
        /// close the current window
        /// </summary>
        public static void CloseWindow()
        {
            #region
            string js = "parent.opener=null;window.close();";
            ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), ctrl.ClientID.ToString(), js, true);
            #endregion
        }

        ///// <summary>
        ///// 执行JavaScript。
        ///// </summary>
        ///// <param name="js"></param>
        //public static void RunScript(string js)
        //{
        //    #region
        //    ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), ctrl.ClientID.ToString(), js, true);
        //    #endregion
        //}

        /// <summary>
        /// turn the page that open this page to a new url
        /// </summary>
        public static void RefreshParent(string url)
        {
            #region
            string js = "window.opener.location.href='" + url + "';window.close();";
            ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), url.GetHashCode().ToString(), js, true);
            #endregion
        }

        /// <summary>
        /// refresh the page that open this page
        /// </summary>
        public static void RefreshOpener()
        {
            #region
            string js = @"
                        var url=opener.location.href;
                        if(url.lastIndexOf('#')==url.length-1){
                            opener.location.href=url.substring(0,url.length-1);
                        }
                        else{
                            opener.location.href=url;
                        }";
            ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), ctrl.ClientID.ToString(), js, true);
            #endregion
        }

        /// <summary>
        /// open up a new window with fix size
        /// </summary>
        /// <param name="url">the url of the new window</param>
        /// <param name="width">the width for the new window</param>
        /// <param name="heigth">the height for the new window</param>
        /// <param name="top">position to top</param>
        /// <param name="left">position to left</param>
        public static void OpenWebFormSize(string url, int width, int heigth, int top, int left)
        {
            #region
            string js = "window.open('" + url + @"','','height=" + heigth + ",width=" + width + ",top=" + top + ",left=" + left + ",location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');";
            ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), url.GetHashCode().ToString(), js, true);
            #endregion
        }

        /// <summary>
        /// turn to the page of the url
        /// </summary>
        /// <param name="url">the next location url</param>
        public static void JavaScriptLocationHref(string url)
        {
            #region
            string js = @"window.location.replace('{0}');";
            ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), url.GetHashCode().ToString(), string.Format(js, url), true);
            #endregion
        }

        /// <summary>
        /// open up a dialog window with fix size（just for IE）
        /// </summary>
        /// <param name="webFormUrl">dialog content webform url</param>
        /// <param name="width">the width for the dialog window</param>
        /// <param name="height">the height for the dialog window</param>
        /// <param name="top">position to top</param>
        /// <param name="left">position to left</param>
        public static void ShowModalDialogWindow(string webFormUrl, int width, int height, int top, int left)
        {
            #region
            string features = "dialogWidth:" + width.ToString() + "px"
                + ";dialogHeight:" + height.ToString() + "px"
                + ";dialogLeft:" + left.ToString() + "px"
                + ";dialogTop:" + top.ToString() + "px"
                + ";center:yes;help=no;resizable:no;status:no;scroll=yes";
            ShowModalDialogWindow(webFormUrl, features);
            #endregion
        }

        /// <summary>
        /// open up a dialog window with fix size（just for IE）
        /// </summary>
        /// <param name="webFormUrl">dialog content webform url</param>
        /// <param name="features">the parameters to define the dialog</param>
        public static void ShowModalDialogWindow(string webFormUrl, string features)
        {
            string js = ShowModalDialogJavascript(webFormUrl, features);
            ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), webFormUrl.GetHashCode().ToString(), js, true);
        }

        /// <summary>
        /// return the javascript that show up the modal dialog with fix size（just for IE）
        /// </summary>
        /// <param name="webFormUrl">dialog content webform url</param>
        /// <param name="features">the parameters to define the dialog</param>
        /// <returns>the string of the javascript</returns>
        public static string ShowModalDialogJavascript(string webFormUrl, string features)
        {
            #region
            return "window.showModalDialog('" + webFormUrl + "','','" + features + "');";
            #endregion
        }

        /// <summary>
        /// run the JavaScript when object loaded(also suitable for AJAX)
        /// </summary>
        /// <param name="ctrl">object ctrl:Page or UpdatePanel</param>
        /// <param name="strScript">the script text or script function name for running</param>
        public static void RunScript(string strScript)
        {
            ScriptManager.RegisterStartupScript(ctrl, ctrl.GetType(), strScript.GetHashCode().ToString(), strScript, true);
        }

        /// <summary>
        /// include a JavaScript file to a page
        /// </summary>
        /// <param name="strScriptURL">the url of script file</param>
        public static void IncludeScript(string strScriptURL)
        {
            ScriptManager.RegisterClientScriptInclude(page, page.GetType(), strScriptURL.GetHashCode().ToString(), strScriptURL);
        }

        /// <summary>
        /// write a JavaScript to a page
        /// </summary>
        /// <param name="strScript">the script text to write</param>
        public static void WriteScript(string strScript)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), strScript.GetHashCode().ToString(), strScript, true);
        }
        #endregion
    }
}
