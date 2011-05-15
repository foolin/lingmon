<%@ Page Title="搜索_快乐网" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Article_Search" %>
<%@ Register Assembly="Utility" Namespace="Utility.Web" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphMain" Runat="Server">


            <div class="listArea">
            
                <asp:Repeater ID="repDataList" runat="server">
                    <ItemTemplate>
                    
                        <div class="item">
                        
                	        <div class="itemContent" style="height:auto;">
                                <%#(Eval("Content") + "").Replace(keyword, "<font color='red'>" + keyword + "</font>") %>
                            </div>
                            <div  class="moreDetail" style="display:none"> <a href="#" onclick="moreDetail(this); return false;">展开全部>></a>  </div>
                            
                            <div class="itemCtrl">
                    	        <span class="left"><a href="?UserID=<%#Eval("UserID") %>"><%#Eval("UserName") %></a> 2011-02-01 00:38:56 发布 </span>
                     	        <span class="right">
                     	            <div id="digArt-<%#Eval("ArtID") %>">
                        	                <a href="javascript:dig(<%#Eval("ArtID") %>, 0);"><img src="../images/digUp.gif" border="0" height="14" />顶</a>(<%#Eval("DigUp") %>) 
                                        &nbsp;&nbsp; 
                        	                <a href="javascript:dig(<%#Eval("ArtID") %>, 1);"><img src="../images/digDown.gif" border="0" height="14" />踩</a>(<%#Eval("DigDown") %>) 
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
                      	             <img id="imgCommentChkCode-<%#Eval("ArtID") %>" src="../Handle/ChkCodeImage.ashx?t=<%=DateTime.Now %>" alt="刷新验证码" style="cursor:pointer;" onclick="refreshCode('#imgCommentChkCode-<%#Eval("ArtID") %>')" />
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
                
                <div id="divNoFound" runat="server" visible="false" style="padding:50px; text-align:center;">
                    对不起，找不到你搜索的“<font color='red'><%=keyword %></font>”关键词！
                </div>

                
                <div class="page">
                	<cc1:Paging ID="Paging1" runat="server" ShowPageGo="True" PageSplitNum="10" PageSize="20">
                    </cc1:Paging>
                </div>
            </div>
            <!-- listArea -->



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CphSider" Runat="Server">
</asp:Content>

