<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="快乐网—我们一起分享|www.kuaile.us" %>
<%@ Register Assembly="Utility" Namespace="Utility.Web" TagPrefix="cc1" %>

<%@ Register src="WebUserControl/WucSiderContact.ascx" tagname="WucSiderContact" tagprefix="uc1" %>

<%@ Register src="WebUserControl/WucRegister.ascx" tagname="WucRegister" tagprefix="uc2" %>

<%@ Register src="WebUserControl/WucUserLogin.ascx" tagname="WucUserLogin" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"> 

    <script src="js/common.js" type="text/javascript"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphMain" Runat="Server">

        	<div class="postArea">
            <div class="areaPadding">
            		<div class="title">来，与我们分享您的快乐：</div>
                    <div class="textareaBox">
                        <textarea name="artContent" id="artContent" style="height:80px; font-size:14px;" tip="请在这里输入你要分享的内容..."></textarea>
                    </div>
                	<div class="btnArea">
                	
                      	验证码：<input type="text" name="artChkCode" id="artChkCode" style="width:50px;" value="" />
                      	 <img id="imgChkCode" src="Handle/ChkCodeImage.ashx?t=<%=DateTime.Now %>" alt="刷新验证码" style="cursor:pointer;" onclick="refreshCode()" />
                      	 <a href="javascript:refreshCode()">看不清？</a>
                      	 
                      	<input type="button" id="btnPostArticle"  class="btn" value="发表"  />
                      	
                      	<script type="text/javascript">
                      	    function refreshCode(){
                      	        $("#imgChkCode").attr("src","Handle/ChkCodeImage.ashx?t=" + new Date().getTime());
                      	    }
                      	    
                      	    //检查是否登录
                      	    $("#artContent").focus(function(){
                      	        $.ajax({
                                   type: "GET",
                                   url: "Handle/IsAuthPost.ashx?t=" + new Date().getTime(),
                                   success: function(data){
                                   },
                                   error: function(xhr){
                                        var errmsg = xhr.responseText + "";
                                        if(errmsg == "")
                                        {
                                            errmsg = "对不起，你暂未有权限发表，请联系本站客服。";
                                        }
                                        $.messager.alert("对不起，没有权限操作",errmsg,"error");
                                   }
                                });
                      	        
                      	    });
                      	    
                      	    //提交
                      	    $("#btnPostArticle").click(function(){
                      	        postArticle()
                      	    });
                      	    
                      	    //提交文章
                      	    function postArticle(){
                      	        //var artContent = HTMLEncode($("#artContent").val() + "");
                      	        var artContent = $("#artContent").val() + "";
                      	        var artChkCode = $("#artChkCode").val() + "";

                      	        if(artContent.length <　5 || artContent == ($("#artContent").attr("tip") + ""))
                      	        {
                      	            $.messager.alert('无法提交！',"您提交的内容不能少于5个字符","error");
                      	            return;
                      	        }
                      	        
                      	        if(artChkCode.length <　1)
                      	        {
                      	            $.messager.alert('无法提交！',"请输入验证码","error");
                      	            return;
                      	        }
                      	        
                      	        $("#btnPostArticle").val("正在提交...");
                      	        $("#btnPostArticle").attr("disabled","disabled");
                      	        
                      	        $.ajax({
                                   type: "POST",
                                   url: "Handle/ArticleAdd.ashx?t=" + new Date().getTime(),
                                   data: { "Content": artContent,
                                            "ChkCode": artChkCode
                                   },
                                   success: function(msg){
                                         if(!msg || msg == ""){
                                            msg = "你提交的帖子成功，请耐心等候我们的审核，谢谢！";
                                         }
                                         $.messager.alert('恭喜，发表成功！',
                                             msg,
                                             "info", 
                                             function(){
                                                top.location.href="Default.aspx";
                                             }
                                         );
                                   },
                                   error: function(xhr){
                                        $("#btnPostArticle").val("发表");
                      	                $("#btnPostArticle").attr("disabled","");
                      	                var errTips = xhr.responseText + "";
                      	                if(errTips == "")
                      	                {
                      	                    errTips = " Sorry，未知错误。请检查输入是否正确，或稍后重试！";
                      	                }
                                        $.messager.alert("发表失败！","<font color='red'>" + xhr.responseText  +"</font>","error");
                                         
                                   }
                                });
                      	    }
                      	</script>
                      	
                    </div>
                    <div class="tips">您发表的内容我们会进行审核，正文中包含链接地址，广告，垃圾信息，政治相关或色情描写的内容将会被删除。<br />同时，为了大家提交的内容是高质量的内容，我们规定每个帐号每天最多只能提交<b>5条</b>内容。</div>
			</div>
          	</div>
            
            <div class="listArea">
            
                <asp:Repeater ID="repDataList" runat="server">
                    <ItemTemplate>
                    
                        <div class="item">
                        
                	        <div class="itemContent">
                                <%#Eval("Content") %>
                            </div>
                            
                            <div class="itemCtrl">
                    	        <span class="left"><a href="">Foolin</a> 2011-02-01 00:38:56 发布 </span>
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
                        	        <textarea name="comment-<%#Eval("ArtID") %>" id="comment-<%#Eval("ArtID") %>"  style="height:40px;" maxlen="200" tip="我也说一句..."></textarea>
                       	        </div>
                                <div class="btnArea">
                                    <input type="button" name="btnPostComment" value="确定" onclick="postComment(<%#Eval("ArtID") %>, this);" />
                                    <span class="tips">您可输入<span class="indicator">0/200</span>个字。</span>
                                </div>
                                <div class="commentList" id="commentList-<%#Eval("ArtID") %>">
                                        评论列表加载中...
<%--                                    <dl>
                                        <dt>第1楼：foolin 发布于2011-02-05 13:21:05</dt>
                                        <dd>楼主真搞！</dd>
                                        <dt>第2楼：foolin 发布于2011-02-05 13:21:05</dt>
                                        <dd>2010年，一美国人到中国旅游，用10万美元兑换到68万人民币。在中国吃喝玩乐了一年，花了18万人民币。2011年，他要回去了，到银行去，因为人 民币兑美元升值到1：5，这位美国人用剩下的50万人民币换到了10万美元。白玩了中国人一回，高高兴兴地回家了... </dd>
                                        <dt>第3楼：foolin 发布于2011-02-05 13:21:05</dt>
                                        <dd>楼主真搞！</dd>
                                    </dl>
                                    <div class="page" style="font-size:12px;">
                                        首页 上一页 下一页 尾页
                                    </div>--%>
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
        
        
        	<div class="search">
            	<input type="text" name="keyword" tip="请输入关键词..." value="" /> <input type="button" name="Search" value="搜索" />
            </div>
            
            <div class="loginForm column">
            	<div class="title">公告区</div>
                <div class="content">
                	<div class="text">
                	    &nbsp;&nbsp;&nbsp;&nbsp;欢迎光临快乐网，我们的口号是“快乐.我们一起分享！”。<br />
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
                    </div>
                    <uc2:WucRegister ID="WucRegister1" runat="server" />
            </div>
            
            
            <div class="column">
                <div class="title">联系方式</div>
                <div class="content" style="padding:5px; line-height:25px;">
                    <uc1:WucSiderContact ID="WucSiderContact1" runat="server" />
                </div>
            </div>
 

</asp:Content>

