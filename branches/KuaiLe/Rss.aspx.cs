using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility.Web;
using System.Collections;
using KuaiLe.Us.BLL;
using System.Data;
using KuaiLe.Us.Common;

public partial class Rss : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        RssBase rss = new RssBase();
        rss.RssItems = new ArrayList();
        rss.BoardID = 0;
        rss.Description = "快乐网，我们一起分享！";
        rss.Generator = "KuaiLe.Us v1.0";   //生成该频道的程序名称 MightyInHouse Content System v2.3
        rss.Link = "http://www.kuaile.us";
        rss.ManagingEditor = "Contact@kuaile.us";   //内容负责人的Email  
        rss.Title = "快乐网-分享冷笑话、糗事百科、雷人囧事";

        //循环读取列表
        try
        {
            ArticleBll bll = new ArticleBll();
            DataSet dsArtList = bll.GetList(50, "Status>0", "ArtID DESC, CreateTime Desc");
            if (dsArtList != null && dsArtList.Tables.Count > 0 && dsArtList.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsArtList.Tables[0].Rows)
                {
                    string strAuthor = dr["NickName"] + "";
                    string strTitle = dr["Title"] + "";
                    string strContent = dr["Content"] + "";
                    string strUrl = "http://www.kuaile.us/Article/Article.aspx?artid=" + dr["ArtID"];
                    DateTime dtmPubDate = DateTime.Now;
                    if (strTitle == "")
                    {
                        strTitle = Helper.GetFirstLine(strContent, 20);
                    }
                    try
                    {
                        dtmPubDate = Convert.ToDateTime(dr["CreateTime"]);
                    }
                    catch
                    {
                        dtmPubDate = DateTime.Now;
                    }
                    if (strContent.Length > 300)
                    {
                        //strContent = strContent.Substring(0, 300) + "... <a href=\"" + strUrl + "\" target=\"_blank\">点击查看更多>></a>";
                        strContent = strContent.Substring(0, 300) + "... ";
                    }

                    RssItemBase rssItem = new RssItemBase();
                    rssItem.Author = strAuthor;
                    rssItem.Comments = strUrl;
                    rssItem.Description = strContent;
                    rssItem.Guid = strUrl;
                    rssItem.Link = strUrl;
                    rssItem.PubDate  = dtmPubDate;
                    
                    rssItem.Title = "#" + dr["ArtID"] + "乐：" + strTitle;
                    rss.RssItems.Add(rssItem);
                }
            }
        }
        catch (Exception ex)
        {
            WebLog.WriteErrLog("Rss取列表出错：" + ex.Message);
        }

        string strItemContent = "";
        strItemContent = rss.ToXML("utf-8");


        Response.Write(strItemContent);
        Response.End();
    }


    

}
