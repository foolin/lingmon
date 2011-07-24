using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using KuaiLe.Us.Common;
using System.Data;
using KuaiLe.Us.BLL;
using System.Text.RegularExpressions;

public partial class wap_default : WapBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string type = "";   //列表类型
        int userID = -1;

        type = QS("type").ToLower().Trim();
        userID = QSInt("userid");

        int page = QSInt("page");
        if (page == 0)
        {
            page = 1;
        }


        string strWhere = " (Status> 0 Or  (Status = 0 And CreateTime<='" + DateTime.Now.AddMinutes(-10) + "') )";
        string strOrder = "ArtID DESC";
        if (userID > 0)
        {
            strWhere += " And UserID=" + userID + " ";
        }

        if (type == "new")
        {
            strOrder = " CreateTime desc ";
        }
        else if (type == "hot")
        {
            strOrder = " (IsNull(DigUp,0) + IsNull(DigDown,0)) desc ";
        }
        else if (type == "up")
        {
            strOrder = " DigUp desc ";
        }
        else if (type == "down")
        {
            strOrder = " DigDown desc ";
        }
        else if (type == "comments")
        {
            strOrder = " Comments desc ";
        }

        int record = 0;
        int pageSize = 15;
        DataSet dsList = new ArticleBll().GetList(strWhere, strOrder, pageSize, page - 1, out record);

        StringBuilder sb = new StringBuilder();
        if (dsList != null && dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
        {
            sb.Append("<div class=\"artlist\">");
            foreach (DataRow dr in dsList.Tables[0].Rows)
            {
                if ((dr["Content"] + "").Length > 500)
                {
                    continue;
                }
                sb.Append("<div class=\"title\"> # " + dr["ArtID"] + "乐</div>");
                sb.Append("<div class=\"content\">" + dr["Content"] + "</div>");
                sb.Append("<div class=\"info\">" + dr["NickName"] + " 发布于 " + dr["CreateTime"] + "</div>");
            }
            sb.Append("</div>");

            MakePager(sb, page, pageSize, record);
        }

        WritePage("首页", sb.ToString());
    }



    /// <summary>
    /// 分页导航
    /// </summary>
    /// <param name="sb"></param>
    /// <param name="strPage"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="totalRecords"></param>
    protected string MakePager(StringBuilder sb, int pageIndex, int pageSize, int totalRecords)
    {
        //总页数
        int pageTotal = 0;

        if (pageSize > 0 && totalRecords > 0)
        {
            pageTotal = (int)(totalRecords / pageSize) + 1;
        }

        if (pageTotal <= 0)
        {
            pageTotal = 1;
        }

        //页数
        int pagePreNum = 0, pageCurrNum = 0, pageNextNum = 0;

        pagePreNum = pageIndex - 1;     //上一页
        pageCurrNum = pageIndex;        //当前页
        pageNextNum = pageIndex + 1;    //下一页

        if (pagePreNum < 1)
        {
            pagePreNum = 1;
        }
        if (pageNextNum < 1)
        {
            pageNextNum = 1;
        }

        if (pagePreNum > pageTotal)
        {
            pagePreNum = pageTotal;
        }
        if (pageNextNum > pageTotal)
        {
            pageNextNum = pageTotal;
        }


        sb.Append("<form name=\"form1\" action=\"" + GetPageUrl(0) + "\" method=\"get\">");

        sb.Append(WapUtil.WriteLink("[下一页]", GetPageUrl(pageNextNum)));
        sb.Append(WapUtil.WriteLink("[上一页]", GetPageUrl(pagePreNum)));
        sb.Append(WapUtil.WriteBreakLine(1));

        sb.Append("第" + pageIndex + "/" + pageTotal + "页");
        sb.Append(WapUtil.WriteSpace(1));
        
        sb.Append("<input type=\"text\" value=\"\" style=\"width:30px;\" name=\"page\" />");
        sb.Append("<input type=\"submit\" value=\"GO\" name=\"submit\" />");
        sb.Append("</form>");

        sb.Append(WapUtil.WriteBreakLine(1));


        return sb.ToString();
    }



    /// <summary>
    /// 获取当前网址前缀
    /// </summary>
    /// <returns></returns>
    private string GetPageUrl(int pageNum)
    {
        string url = HttpContext.Current.Request.Url.PathAndQuery;
        url = Regex.Replace(url, ("&{0,1}page=\\d*").ToString(), "", RegexOptions.IgnoreCase);

        if (pageNum >= 0)
        {
            if (url.IndexOf('?') != -1)
            {
                url += "&page=" + pageNum;
            }
            else
            {
                url += "?page=" + pageNum;
            }
        }
        return url;
    }



}
