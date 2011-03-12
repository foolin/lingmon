<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="About_AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
     .title
     {
     	font-size:16px; font-weight:bold; border-bottom:dashed 1px #ccc; padding:5px;
     }
     .content
     {
     	line-height:25px; padding:10px;
     }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphMain" Runat="Server">

      <div style="padding:20px;">
        <div class="title"> 关于快乐网--kuaile.us </div>
        <div class="content">
            &nbsp;&nbsp;&nbsp;&nbsp;  欢迎光临快乐网(www.kuaile.us)，我们的口号是“快乐，我们一起分享！”。<br />
            &nbsp;&nbsp;&nbsp;&nbsp; 本站定位于一个以分享快乐为主题网站，网站内容趋向于简、乐、精，面向群体为白领、学生及一些较为年轻一代的群体，在忙碌的学习、工作、生活中，利用一些零碎空余时间与我们一起分享，汇集快乐，放松自己，凝聚笑声，为己减压。本站致力于打造一个互动分享平台。 
        </div>
        <div class="title"> 联系我们 </div>
        <div class="content">
            &nbsp;&nbsp;&nbsp;&nbsp;  <%--我们是一支有抱负有梦想的团队，一支富有活力、年轻的80后军队。卓越是我们的追求，创新是我们使命，年轻是我们的财富，技术是我们革命的本钱！快乐网(www.kuaile.us)致力打造中国最大的互动分享平台！--%>如果有意加入我们或商业合作，请发送邮件到：Contact#kuaile.us  (#换成@) 
        </div>
      </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CphSider" Runat="Server">
</asp:Content>

