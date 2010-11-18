using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Text.RegularExpressions;
using System.Collections;

namespace Sxmobi.Utility.Web
{
    /// <summary>
    /// Name        :  分页控件（Paging Control v1.0.1）
    /// Description :  用来定制Repeater分页
    /// Author      :  刘付灵（Foolin）
    /// Created on  :  2010-4-26 12:05:38
    /// Updated on  :  2010-4-27 15:40:25 
    /// Updated log :  
    ///                修正FireFox或Chrome点击Go无法跳转的bug( 2010-4-28 8:58:40)
    /// Ver 1.0.1   :
    ///                ·增加语言选项，可控制输出某种语言。（v1.0.0.1 2010-4-30)
    ///                ·控件集成CSS样式，默认不用另外加样式。(v1.0.1 2010-4-30)
    /// </summary>
    [ToolboxData("<{0}:Paging runat=\"server\"></{0}:Paging>")]
    public class Paging : Control
    {
        private int pageSize;   //每页记录数
        private int pageIndex;  //当前页码
        private int pageTotal;  //总页数
        private int records;    //总记录数

        private string cssClass;    // Css样式
        private bool showPreNext;   //是否显示上一页下一页
        private bool showPageNum;   //是否显示页码连接
        private int pageSplitNum;   //页码隔多少数字
        private bool showPageTips;  //是否显示当前页、记录数等信息
        private bool showPageJump;  //是否显示下来框跳转
        private bool showPageGo;    //是否显示输入页码跳转

        private int showPageLan;   //显示风格： 0 - 默认， 1 - 中文， 2 - 英语 ， 其它默认
        //Lan   语言包
        private Hashtable Lan = new Hashtable();



        #region ________不可显示设置属性________
        /****************************************/
        /*                                      */
        /*         不可显示设置属性             */
        /*                                      */
        /****************************************/


        [Browsable(false)]
        [Category("Appearance")]
        [PersistenceMode(PersistenceMode.Attribute)]
        public int PageIndex
        {
            get
            {
                pageIndex = GetCurrentPageIndex(); ;
                return pageIndex;
            }
            set
            {
                pageIndex = value;
            }
        }

        [Browsable(false)]
        [Category("Appearance")]
        [PersistenceMode(PersistenceMode.Attribute)]
        public int PageTotal
        {
            get
            {
                double count = this.Records;
                pageTotal = int.Parse(Math.Ceiling(count / this.PageSize).ToString());
                if (pageTotal == 0 && this.Records > 0) pageTotal = 1;
                return pageTotal;
            }
        }

        [Browsable(false)]
        [Category("Appearance")]
        [PersistenceMode(PersistenceMode.Attribute)]
        public int Records
        {
            get
            {
                records = 0;
                if (this.ViewState["records"] != null)
                {
                    records = int.Parse(this.ViewState["records"].ToString());
                }
                return records;
            }
            set
            {
                this.ViewState["records"] = value;
                records = value;
            }
        }

        #endregion  //不可显示设置属性end



        #region ________可以显示设置属性________
        /****************************************/
        /*                                      */
        /*         可以显示设置属性             */
        /*                                      */
        /****************************************/

        [DefaultValue("page")]
        [Category("Appearance")]
        [PersistenceMode(PersistenceMode.Attribute)]
        public string CssClass
        {
            get
            {
                cssClass = "page";
                if (this.ViewState["cssClass"] != null)
                {
                    cssClass = this.ViewState["cssClass"].ToString();
                }
                return cssClass;
            }
            set
            {
                this.ViewState["cssClass"] = value;
                cssClass = value;
            }
        }


        [DefaultValue(20)]
        [Category("Appearance")]
        [PersistenceMode(PersistenceMode.Attribute)]
        public int PageSize
        {
            get
            {
                pageSize = 20;
                if (this.ViewState["pageSize"] != null)
                {
                    pageSize = int.Parse(this.ViewState["pageSize"].ToString());
                }
                return pageSize;
            }
            set
            {
                this.ViewState["pageSize"] = value;
                pageSize = value;
            }
        }

        [DefaultValue(false)]
        [Category("Appearance")]
        [PersistenceMode(PersistenceMode.Attribute)]
        public bool ShowPageTips
        {
            get
            {
                showPageTips = false;
                if (this.ViewState["showPageTips"] != null)
                {
                    showPageTips = bool.Parse(this.ViewState["showPageTips"].ToString());
                }
                return showPageTips;
            }
            set
            {
                this.ViewState["showPageTips"] = value;
                showPageTips = value;
            }
        }

        [DefaultValue(true)]
        [Category("Appearance")]
        [PersistenceMode(PersistenceMode.Attribute)]
        public bool ShowPageNum
        {
            get
            {
                showPageNum = true;
                if (this.ViewState["showPageNum"] != null)
                {
                    showPageNum = bool.Parse(this.ViewState["showPageNum"].ToString());
                }
                return showPageNum;
            }
            set
            {
                this.ViewState["showPageNum"] = value;
                showPageNum = value;
            }
        }

        [DefaultValue(5)]
        [Category("Appearance")]
        [PersistenceMode(PersistenceMode.Attribute)]
        public int PageSplitNum
        {
            get
            {
                pageSplitNum = 5;
                if (this.ViewState["pageSplitNum"] != null)
                {
                    pageSplitNum = int.Parse(this.ViewState["pageSplitNum"].ToString());
                }
                return pageSplitNum;
            }
            set
            {
                this.ViewState["pageSplitNum"] = value;
                pageSplitNum = value;
            }
        }

        [DefaultValue(true)]
        [Category("Appearance")]
        [PersistenceMode(PersistenceMode.Attribute)]
        public bool ShowPreNext
        {
            get
            {
                showPreNext = true;
                if (this.ViewState["showPreNext"] != null)
                {
                    showPreNext = bool.Parse(this.ViewState["showPreNext"].ToString());
                }
                return showPreNext;
            }
            set
            {
                this.ViewState["showPreNext"] = value;
                showPreNext = value;
            }
        }

        [DefaultValue(false)]
        [Category("Appearance")]
        [PersistenceMode(PersistenceMode.Attribute)]
        public bool ShowPageJump
        {
            get
            {
                showPageJump = false;
                if (this.ViewState["showPageJump"] != null)
                {
                    showPageJump = bool.Parse(this.ViewState["showPageJump"].ToString());
                }
                return showPageJump;
            }
            set
            {
                this.ViewState["showPageJump"] = value;
                showPageJump = value;
            }
        }

        [DefaultValue(false)]
        [Category("Appearance")]
        [PersistenceMode(PersistenceMode.Attribute)]
        public bool ShowPageGo
        {
            get
            {
                showPageGo = false;
                if (this.ViewState["showPageGo"] != null)
                {
                    showPageGo = bool.Parse(this.ViewState["showPageGo"].ToString());
                }
                return showPageGo;
            }
            set
            {
                this.ViewState["showPageGo"] = value;
                showPageGo = value;
            }
        }


        [DefaultValue(0)]
        [Category("Appearance")]
        [PersistenceMode(PersistenceMode.Attribute)]
        public int ShowPageLan
        {
            get
            {
                showPageLan = 0;
                if (this.ViewState["showPageLan"] != null)
                {
                    showPageLan = int.Parse(this.ViewState["showPageLan"].ToString());
                }
                return showPageLan;
            }
            set
            {
                this.ViewState["showPageLan"] = value;
                showPageLan = value;
            }
        }

        #endregion  //可显示设置属性end




        #region ________公有方法________
        /****************************************/
        /*                                      */
        /*               公有方法               */
        /*                                      */
        /****************************************/

        /// <summary>
        /// 初始化分页
        /// </summary>
        /// <param name="records"></param>
        public void InitPage(int records)
        {
            this.EnableViewState = this.Visible = records > this.PageSize;
            if (records <= this.PageSize)
            {
                return;
            }
            double count = records;
            this.Records = records;
            if (this.PageIndex > this.PageTotal) this.PageIndex = 1;
        }


        #endregion


        #region ________私有方法________
        /****************************************/
        /*                                      */
        /*               私有方法               */
        /*                                      */
        /****************************************/

        protected override void OnInit(EventArgs e)
        {
            //const string key = "PagingCssPage";
            //判断是否采用默认属性
            if (CssClass == "page")
            {
                //if (!this.Page.ClientScript.IsClientScriptBlockRegistered(key))
                //{
                //    string strCssFile = Page.ClientScript.GetWebResourceUrl(this.GetType(), "Sxmobi.Utility.Web.Paging.css");
                //    //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), key, "<link href='" + strCssFile + "' rel='stylesheet' type='text/css' />");
                //    LiteralControl include = new LiteralControl("<link href='" + strCssFile + "' rel='stylesheet' type='text/css' />");
                //    this.Page.Header.Controls.Add(include);
                //}
                
                //判断是否第一次添加CSS，避免重复添加
                if (Context.Items["IsHasCss"] == null)
                {
                    string strCssFile = Page.ClientScript.GetWebResourceUrl(this.GetType(), "Sxmobi.Utility.Web.Paging.css");
                    LiteralControl include = new LiteralControl("<link href=\"" + strCssFile + "\" rel=\"stylesheet\" type=\"text/css\" />");
                    this.Page.Header.Controls.Add(include);
                    Context.Items["IsHasCss"] = "true";
                }

            }
            base.OnInit(e);
        }



        /// <summary>
        /// 重写方法
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (Context != null)
            {
                InitLan();  //初始化语言
                //如果未设置ID或者ID开头为数字，则赋值默认ID
                if (string.IsNullOrEmpty(this.ID))
                {
                    writer.Write("<div style='height:20px;padding:5px;background:#ccc; border:solid 2px #00f; color:red;'>分页控件（Paging Control）出错啦，你未设置分页控件ID</div>");
                }
                else
                {
                    WritePager(writer);
                }
            }
            else
            {
                writer.Write("<div style='width:400px;height:20px;background:#ccc; border:solid 2px #00f;'>分页控件（Paging Control）: <u>首页</u> <u>上一页</u> <u>下一页</u> <u>尾页</u></div>");
            }
        }


        /// <summary>
        /// 分页导航条
        /// </summary>
        /// <param name="writer"></param>
        private void WritePager(HtmlTextWriter writer)
        {
            StringBuilder strPage = new StringBuilder();
            if (CssClass != "")
            {
                strPage.Append("<div class=\"" + CssClass + "\">");
            }
            else
            {
                strPage.Append("<div>");
            }
            
            //设置分页
            strPage.Append(PageStyle());

            strPage.Append("</div>");
            writer.Write(strPage);
        }


        /// <summary>
        /// 获取当前网址前缀
        /// </summary>
        /// <returns></returns>
        private string GetPageUrlPrefix()
        {
            string url = HttpContext.Current.Request.Url.PathAndQuery;
            return Regex.Replace(url, ("&{0,1}" + this.ID + "=\\d*").ToString(), "", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 规格化数字
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private int ParsePageNum(int num)
        {
            if (num < 1)
            {
                return 1;
            }
            else if (num > PageTotal)
            {
                return PageTotal;
            }
            return num;
        }

        /// <summary>
        /// 规格化网址
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageTitle"></param>
        /// <returns></returns>
        private string ParsePageUrl(int pageNum, string pageTitle)
        {
            string strUrlPrefix = GetPageUrlPrefix();
            //判断是否有参数
            if (strUrlPrefix.IndexOf('?') != -1)
            {
                return (" <a href=\"" + strUrlPrefix + "&" + this.ID + "=" + ParsePageNum(pageNum) + "\">" + pageTitle + "</a> ").Replace("?&","?");
            }

            return " <a href=\"" + strUrlPrefix + "?" + this.ID + "=" + ParsePageNum(pageNum) + "\">" + pageTitle + "</a> ";
        }


        /// <summary>
        /// 获取当前的索引页
        /// </summary>
        /// <returns></returns>
        private int GetCurrentPageIndex()
        {
            int index = 1;
            int.TryParse(HttpContext.Current.Request[this.ID], out index);
            if (index > 0)
            {
                return index;
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// 默认的分页样式
        /// </summary>
        /// <param name="strPage"></param>
        /// <returns></returns>
        private string PageStyle()
        {
            StringBuilder strPage = new StringBuilder();
            strPage.Append(Style_PageTips());
            strPage.Append(Style_PagePre());
            strPage.Append(Style_PageNum());
            strPage.Append(Style_PageNext());
            strPage.Append(Style_PageJump());
            strPage.Append(Style_PageGo());
            return strPage.ToString();
        }


        /// <summary>
        /// 显示当前页，总记录等
        /// </summary>
        /// <returns></returns>
        private string Style_PageTips()
        {
            if (ShowPageTips)
            {
                //return "第" + PageIndex + "页/共" + PageTotal + "页-共" + Records + "条记录 &nbsp ";
                return Lan["Tips"].ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 显示：首页 上一页
        /// </summary>
        /// <returns></returns>
        private string Style_PagePre()
        {
            StringBuilder strPage = new StringBuilder();
            if (ShowPreNext)
            {
                if (PageIndex > 1)
                {
                    //strPage.Append(ParsePageUrl(1, "首页 "));
                    //strPage.Append(ParsePageUrl(PageIndex - 1, " 上一页 "));
                    strPage.Append(ParsePageUrl(1, Lan["First"].ToString()));
                    strPage.Append(ParsePageUrl(PageIndex - 1, Lan["Pre"].ToString()));
                }
                else
                {
                    //strPage.Append(" 首页 ");
                    //strPage.Append(" 上一页 ");
                    strPage.Append( Lan["First"].ToString());
                    strPage.Append( Lan["Pre"].ToString());
                }
            }
            return strPage.ToString();
        }

        /// <summary>
        /// 显示：尾页 下一页
        /// </summary>
        /// <returns></returns>
        private string Style_PageNext()
        {
            StringBuilder strPage = new StringBuilder();
            if (ShowPreNext)
            {
                if (PageIndex < PageTotal)
                {
                    //strPage.Append(ParsePageUrl(PageIndex + 1, " 下一页 "));
                    //strPage.Append(ParsePageUrl(PageTotal, " 尾页 "));
                    strPage.Append(ParsePageUrl(PageIndex + 1, Lan["Next"].ToString() ));
                    strPage.Append(ParsePageUrl(PageTotal, Lan["Last"].ToString() ));
                }
                else
                {
                    //strPage.Append(" 下一页 ");
                    //strPage.Append(" 尾页 ");
                    strPage.Append( Lan["Next"].ToString() );
                    strPage.Append( Lan["Last"].ToString() );
                }
            }
            return strPage.ToString();
        }

        /// <summary>
        /// 显示页数字如： 1 2 3 4 ...6
        /// </summary>
        /// <returns></returns>
        private string Style_PageNum()
        {
            StringBuilder strPage = new StringBuilder();
            if (ShowPageNum)
            {
                int iSplitNum = (int)(PageSplitNum / 2) + 1;
                for (int i = PageIndex - 1; (i > 0) && ((PageIndex - i) < iSplitNum); i--)
                {
                    strPage.Insert(0, ParsePageUrl(i, i.ToString()));
                }
                if ( (PageIndex - iSplitNum) > 0)
                {
                    if ((PageIndex - iSplitNum) != 1)
                    {
                        strPage.Insert(0, " ... ");
                    }
                    strPage.Insert( 0, ParsePageUrl(1, "1"));
                }
                strPage.Append(" <b>" + PageIndex + "</b> ");
                for (int j = PageIndex + 1; (j <= PageTotal) && ((j - PageIndex) < iSplitNum); j++)
                {
                    strPage.Append(ParsePageUrl(j, j.ToString()));
                }
                if ((PageIndex + iSplitNum) <= PageTotal)
                {
                    if ((PageIndex + iSplitNum) != PageTotal)
                    {
                        strPage.Append(" ... ");
                    }
                    strPage.Append( ParsePageUrl( PageTotal, PageTotal.ToString()) );
                }
            }
            return strPage.ToString();
        }

        /// <summary>
        /// 显示：跳转操控
        /// </summary>
        /// <returns></returns>
        private string Style_PageJump()
        {
            string strUrlPrefix = GetPageUrlPrefix();
            StringBuilder strPage = new StringBuilder();
            if (ShowPageJump)
            {
                if (strUrlPrefix.IndexOf('?') != -1)
                {
                    strPage.Append(("<select name=\"sel" + this.ID + "\" onchange=\"self.location.href='"
                                    + strUrlPrefix + "&" + this.ID + "=' + this.options[this.selectedIndex].value;\">")).Replace("?&", "?");
                }
                else
                {
                    strPage.Append("<select name=\"sel" + this.ID + "\" onchange=\"self.location.href='"
                        + strUrlPrefix + "?" + this.ID + "=' + this.options[this.selectedIndex].value;\">");
                }
                for (int i = 1; i <= PageTotal; i++)
                {
                    if (i == PageIndex)
                    {
                        strPage.Append("<option value=\"" + i + "\" selected=\"selected\">" + i + "</option>");
                    }
                    else
                    {
                        strPage.Append("<option value=\"" + i + "\">" + i + "</option>");
                    }
                }
                strPage.Append("</select> ");
            }
            else
            {
                strPage.Append("");
            }
            return strPage.ToString();
        }

        /// <summary>
        /// 直接输入页数进行跳转
        /// </summary>
        /// <returns></returns>
        private string Style_PageGo()
        {
            string strUrlPrefix = GetPageUrlPrefix();
            StringBuilder strPage = new StringBuilder();
            if (ShowPageGo)
            {
                strPage.Append(" &nbsp " + "<input name=\"txt" + this.ID + "\"  id=\"txt" + this.ID + "\" type=\"text\" value=\"" + PageIndex + "\" style=\"width:35px;\" />");
                strPage.Append(" <input  name=\"btn" + this.ID + "\" type=\"button\" value=\"" + Lan["Go"].ToString() +"\" ");
                if (strUrlPrefix.IndexOf('?') != -1)
                {
                    strPage.Append((" onclick=\"self.location.href='" + strUrlPrefix
                        + "&" + this.ID + "=' + document.getElementById('txt" + this.ID + "').value;\" />").Replace("?&", "?"));
                }
                else
                {
                    strPage.Append(" onclick=\"self.location.href='" + strUrlPrefix
                        + "?" + this.ID + "=' + document.getElementById('txt" + this.ID + "').value;\" />");
                }
            }
            return strPage.ToString();
        }




        private void InitLan()
        {
            switch(ShowPageLan)
            {
                case 1:
                    Lan["Tips"] = " 第" + PageIndex + "页/共" + PageTotal + "页-共" + Records + "条记录 &nbsp "; ;
                    Lan["First"] = " 首页 ";
                    Lan["Pre"] = " 上一页 ";
                    Lan["Next"] = " 下一页 ";
                    Lan["Last"] = " 尾页 ";
                    Lan["Go"] = "跳转";
                    break;
                case 2:
                    Lan["Tips"] = " Page:" + PageIndex + "/Pages:" + PageTotal + "-Records:" + Records + " &nbsp "; ;
                    Lan["First"] = " First ";
                    Lan["Pre"] = " Pre ";
                    Lan["Next"] = " Next ";
                    Lan["Last"] = " Last ";
                    Lan["Go"] = "Go";
                    break;
                default:
                    Lan["Tips"] =  PageIndex + "/" + PageTotal + "-" + Records + " &nbsp "; ;
                    Lan["First"] = " |< ";
                    Lan["Pre"] = " < ";
                    Lan["Next"] = " > ";
                    Lan["Last"] = " >| ";
                    Lan["Go"] = "Go";
                    break;
            }

        }

        #endregion  //私有方法end



    }
}

