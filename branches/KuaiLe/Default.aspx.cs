using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using KuaiLe.Us.BLL;
using Utility.Web;
using KuaiLe.Us.Common;

public partial class _Default : PageBase
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        

        #region 解析是否手机版或者kuaileus.com版，然后进行跳转
        //取主机头
        string httpHost = (Request.ServerVariables["HTTP_HOST"] + "").ToLower();
        //如果手机头
        if (httpHost.Contains("m.kuaile.us")
            || httpHost.Contains("m.kuaileus.com"))
        {
            Response.Redirect("http://m.kuaile.us/wap");
            return;
        }
        else if (httpHost == "www.kuaileus.com" || httpHost == "kuaileus.com")  //如果输入是www.kuaileus.com或kuaileus.com，则跳www.kuaile.us
        {
            Response.Redirect("http://www.kuaile.us");
            return;
        }
        else if (httpHost == "foolin.guli.cc")  //如果输入是foolin.guli.cc，则跳到管理登录页面
        {
            Response.Redirect("Manage/Login.aspx");
            return;
        }
        else if (httpHost == "www.guli.cc" || httpHost == "guli.cc")  //如果输入是www.guli.cc或guli.cc，则跳www.kuaile.us
        {
            Response.Redirect("http://www.kuaile.us");
            return;
        }
        #endregion
		
		if(httpHost.Contains("cengzai.com"))
		{
			this.Page.Title = "曾在(CengZai.com)—让有情人幸福！年轻人最爱分享情感的网站";
		}
		else if(httpHost.Contains("jiaowho.com"))
		{
			this.Page.Title = "交互(JiaoWho.com)—互动分享，快乐你我。";
		}
		else if(httpHost.Contains("7lai.cn"))
		{
			this.Page.Title = "齐来(7lai.cn)—分享生活，分享快乐。";
		}

        //第一次提交
        if (!IsPostBack)
        {
            InitDataBind();
            
            if (GB_LoginUser != null)
            {
                idDefaultSiderLogin.Visible = false;
                idDefaultSiderRegister.Visible = false;
            }
        }
    }


    protected void InitDataBind()
    {
        string type = "";   //列表类型
        int userID = -1;

        type = QS("type").ToLower().Trim();
        userID = QSInt("userid");


        string strWhere = "";
        if (SysConfig.VerifyArticle)
        {
            strWhere += " Status> 0 ";
        }
        else
        {
            strWhere += " (Status> 0 Or  (Status = 0 And CreateTime<='" + DateTime.Now.AddMinutes(-10) + "') )";
        }
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
        DataSet dsList = new ArticleBll().GetList(strWhere, strOrder, Paging1.PageSize, Paging1.PageIndex - 1, out record);
        if (dsList != null && dsList.Tables.Count > 0)
        {
            repDataList.DataSource = dsList;
            repDataList.DataBind();
            Paging1.InitPage(record);
        }



        //通知
        DataSet dsNoticeList = new NoticeBll().GetList(5,"", "PostTime DESC");
        if (dsNoticeList != null && dsNoticeList.Tables.Count > 0 && dsNoticeList.Tables[0].Rows.Count > 0)
        {
            repNoticeList.DataSource = dsNoticeList;
            repNoticeList.DataBind();
        }

    }

}
