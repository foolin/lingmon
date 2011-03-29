<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="快乐网 - 我们一起分享 | 致力打造中国最大互动分享平台" %>
<%@ Register Assembly="Utility" Namespace="Utility.Web" TagPrefix="cc1" %>

<%@ Register src="WebUserControl/WucSiderContact.ascx" tagname="WucSiderContact" tagprefix="uc1" %>

<%@ Register src="WebUserControl/WucRegister.ascx" tagname="WucRegister" tagprefix="uc2" %>

<%@ Register src="WebUserControl/WucUserLogin.ascx" tagname="WucUserLogin" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"> 
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphMain" Runat="Server">

        	<div class="postArea">
            <div class="areaPadding">
            		<div class="title">来，与我们分享您的快乐：</div>
                    <div class="textareaBox">
                        <textarea name="artContent" id="artContent" maxlen="1000" style="height:80px; font-size:14px;" tip="请在这里输入你要分享的内容..."></textarea>
                    </div>
                	<div class="btnArea">
                	
                      	验证码：<input type="text" name="artChkCode" id="artChkCode" style="width:50px;" value="" />
                      	 <img id="imgChkCode" src="Handle/ChkCodeImage.ashx?t=<%=DateTime.Now %>" alt="刷新验证码" style="cursor:pointer;" onclick="refreshCode('#imgChkCode')" />
                      	 <a href="javascript:refreshCode('#imgChkCode')">看不清？</a>
                      	 
                      	<input type="button" id="btnPostArticle"  class="btn" value="发表"  />
                      	
                      	<span id="indicatorArticleWordCount">您可输入1000/1000个字符</span>
                      	
                      	<script type="text/javascript">

                      	    //检查是否登录
                      	    $("#artContent").focus(function() {
                      	        checkIsLogin();
                      	    });

                      	    //提交
                      	    $("#btnPostArticle").click(function() {
                      	        postArticle();
                      	        
                      	    });

                      	</script>
                      	
                    </div>
                    <div class="tips">您发表的内容我们会进行审核，正文中包含链接地址，广告，垃圾信息，政治相关或色情描写的内容将会被删除。<br />同时，为了大家提交的内容是高质量的内容，我们规定每个帐号每天最多只能提交<b>5条</b>内容。</div>
			</div>
          	</div>
            
            <div class="listArea">
            
                <asp:Repeater ID="repDataList" runat="server">
                    <ItemTemplate>
                    
                        <div class="item">
                        
                	        <div class="itemContent" style="height:auto;">
                                <%#Eval("Content") %>
                            </div>
                            <div  class="moreDetail" style="display:none"> <a href="#" onclick="moreDetail(this); return false;">展开全部>></a>  </div>
                            
                            <div class="itemCtrl">
                    	        <span class="left"> <span style="font-weight:bold;"><a href="Article/Article.aspx?artid=<%#Eval("ArtID") %>" class="green" target="_blank">#<%#Eval("ArtID") %>乐#</a></span> &nbsp;  <a href="?UserID=<%#Eval("UserID") %>"><%#Eval("NickName") %></a> 2011-02-01 00:38:56 发布 </span>
                     	        <span class="right">
                     	            <div id="digArt-<%#Eval("ArtID") %>">
                        	                <a href="javascript:dig(<%#Eval("ArtID") %>, 0);"><img src="images/digUp.gif" border="0" height="14" />顶</a>(<%#Eval("DigUp") %>) 
                                        &nbsp;&nbsp; 
                        	                <a href="javascript:dig(<%#Eval("ArtID") %>, 1);"><img src="images/digDown.gif" border="0" height="14" />踩</a>(<%#Eval("DigDown") %>) 
                                        &nbsp;&nbsp; 
                                            <a href="#comment" onclick="toggleComment(<%#Eval("ArtID") %>); return false;">
                                        评论</a>(<%#Eval("Comments") %>) &nbsp;&nbsp; 
                                            <a href="javascript:dig(<%#Eval("ArtID") %>, 2);">举报</a>
                                    </div>
                               </span>
                                    
                                <div class="clear"></div>
                            </div>
                            
                            <div class="itemInputComment" id="itemInputComment-<%#Eval("ArtID") %>" style="display:none;">
                    	        <div class="textareaBox">
                        	        <textarea name="comment" id="comment-<%#Eval("ArtID") %>"  style="height:40px;" maxlen="200" tip="我也说一句..."></textarea>
                       	        </div>
                                <div class="btnArea">
                                    用户名：<input type="text" name="commentUserName" id="commentUserName-<%#Eval("ArtID") %>" tip="匿名" value="" style="width:80px;" /> 
                                    验证码：<input type="text" name="commentChkCode" id="commentChkCode-<%#Eval("ArtID") %>"  style="width:50px;" value="" />
                      	             <img id="imgCommentChkCode-<%#Eval("ArtID") %>" src="Handle/ChkCodeImage.ashx?t=<%=DateTime.Now %>" alt="刷新验证码" style="cursor:pointer;" onclick="refreshCode('#imgCommentChkCode-<%#Eval("ArtID") %>')" />
                      	             <a href="javascript:refreshCode('#imgCommentChkCode-<%#Eval("ArtID") %>')">看不清？</a>
                      	             
                                    <input type="button" name="btnPostComment" value="确定" onclick="postComment(<%#Eval("ArtID") %>, this);" />
                                    
                                    <span class="tips">您可输入<span class="indicator">0/200</span>个字。</span>
                                    
                                </div>
                                <div class="commentList" id="commentList-<%#Eval("ArtID") %>">
                                        评论列表加载中...
                                </div>
                            </div>
                            
                        </div>
                        <!-- item -->    
                                        
                    </ItemTemplate>
                </asp:Repeater>
                

                
                <div class="page">
                	<cc1:Paging ID="Paging1" runat="server" ShowPageGo="True" PageSplitNum="10" PageSize="20">
                    </cc1:Paging>
                </div>
            </div>
            <!-- listArea -->

</asp:Content>
      
 <asp:Content ID="Content3" ContentPlaceHolderID="CphSider" Runat="Server">       
        
<%--        
        	<div class="search">
            	<input type="text" name="keyword" tip="请输入关键词..." value="" /> <input type="button" name="Search" value="搜索" />
            </div>
            --%>
            <div class="loginForm column">
            	<div class="title">公告区</div>
                <div class="content">
                	<div class="text">
                	    &nbsp;&nbsp;&nbsp;&nbsp;欢迎光临快乐网，我们的口号是“快乐，我们一起分享！”。<br />
                        &nbsp;&nbsp;&nbsp;&nbsp;或许你生活在忙碌之中，在学习、工作、生活业余之余，利用短短的5分钟时间，来与我们分享一下快乐。
                    <br /><br />
                        快乐网：www.kuaile.us
                    </div>
                </div>
            </div>
            
        	<div class="loginForm column" id="idDefaultSiderLogin" runat="server">
            	<div class="title">用户登录</div>
                <div class="content">
                    <uc3:WucUserLogin ID="WucUserLogin1" runat="server" />
                </div>
            </div>
        	
            <div class="loginForm column" id="idDefaultSiderRegister" runat="server">
            	<div class="title">快速注册</div>
                <div class="content">
                    <uc2:WucRegister ID="WucRegister1" runat="server" />
                </div>
            </div>
            
            
            <div class="column">
                <div class="title">联系方式</div>
                <div class="content" style="padding:5px; line-height:25px;">
                    <uc1:WucSiderContact ID="WucSiderContact1" runat="server" />
                </div>
            </div>
 

</asp:Content>

