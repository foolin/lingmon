<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WucRegister.ascx.cs" Inherits="WebUserControl_WucRegister" %>



    <dl>
        <dt>用户名：</dt>
        <dd><input type="text" name="RegUserName" id="RegUserName" value="" /><span id="errRegUserName"></span></dd>
        <dt>密 码：</dt>
        <dd><input type="password" name="RegPassword" id="RegPassword" value="" /><span id="errRegPassword"></span></dd>
        <dt>重复密码：</dt>
        <dd><input type="password" name="RegRePassword" id="RegRePassword" value="" /><span id="errRegRePassword"></span></dd>
        <dt>邮 箱：</dt>
        <dd><input type="text" name="RegEmail" id="RegEmail"  value="" /><span id="errRegEmail"></span></dd>
        <dt>验证码：</dt>
        <dd><input type="text" name="RegChkCode" id="RegChkCode"  style="width:50px;" value="" /> 2322
            <span id="errRegChkCode"></span>
        </dd>
        <dd>
            <button id="btnRegister" class="btn" type="button"><b style="font-size:14px; padding:5px 0px;">注册</b> 并同意注册协议</button>
        </dd>
        <dd><a href="Agreement.aspx" target="_blank">《快乐网注册协议》</a></dd>
    </dl>


    
    <script type="text/javascript">
        $(function(){
            
            $("#RegUserName").blur(function(){
			    regCheckUsername();
		    });
		    
		    $("#RegPassword").blur(function(){
			    regCheckPassword();
		    });
		    
		    $("#RegRePassword").blur(function(){
			    regCheckPassword(true);
		    });
		    
		    $("#RegEmail").blur(function(){
		        regCheckEmail();
		    });
            
            
            $("#btnRegister").click(function(){
                /*
                if(!regCheckUsername()){
					return ;
				}
				if(!regCheckPassword(true)){
				    return;
				}
				if(!regCheckPassword(true)){
				    return;
				}
				if(!regCheckEmail()){
				    return;
				}
				*/
				//var username = "hello"
				//$.messager.alert('恭喜，注册成功！', '尊敬的' + username + '，您注册已经成功！欢迎使用本站服务，我们已经发送一封邮件到你们的邮箱，请注意查收！');
				//return ;
				
			    var username = $("#RegUserName").val() + "";
			    var password = $("#RegPassword").val() + "";
			    var repassword = $("#RegRePassword").val() + "";
			    var email = $("#RegEmail").val() + "";
			    
			    reg=/^[a-zA-Z0-9_\-]+$/gi;
                if(username.length < 5){
                    regTip("errRegUserName","用户名不能小于5个字符", -1);
                    return false;
                }
                else if(!reg.test(username)){
                    regTip("errRegUserName","用户名只能字母、数字、下划线", -1);
                    return false;
                }
                
                if(password.length < 6){
                    regTip("errRegPassword","密码不能小于6个字符", -1);
                    return false;
                }
                
                if(repassword != password){
                    regTip("errRegRePassword","两次密码不一致", -1);
                    return false;
                }
                
                reg=/^[a-zA-Z0-9_\-]+@[a-zA-Z0-9\-]+\.[a-zA-Z0-9\-\.]+$/gi;
                if(!reg.test(email) || email==""){
                    regTip("errRegEmail","邮箱不合法", -1);
                    return false;
                }
                
                
			    
			    $(this).html("<b>正在注册，请稍后...<b>");
                $(this).attr("disabled","disabled");
                
                
                //注册
                $.ajax({
                   type: "POST",
                   url: "<%=GB_SitePath %>/Handle/Register.ashx?t=" + new Date().getTime(),
                   //cache: false,
                   data: "UserName=" + username + "&Password=" + password + "&Email=" + email,
                   //dataType: "text",
                   //contentType: "charset=utf-8",
                   success: function(msg){
                     $.messager.alert('恭喜，注册'+ username +'成功！',
                         msg,
                         "info", 
                         function(){
                            top.location.href="<%=GB_SitePath %>/Default.aspx";
                         }
                     );
                     
                   },
                   error: function(xhr, textStatus, errorThrown) {
                     $.messager.alert("Sorry，注册" + username + "失败！",
                         "<font color='red'>" + xhr.responseText  +" 请检查输入是否正确或稍后重试！</font>",
                        "error");
                     $("#btnRegister").html("<b>注册</b> 并同意注册协议");
                     $("#btnRegister").attr("disabled","");
                   }
                });
             
            });
        });
		
		
		
		//检查注册用户名
		function regCheckUsername(){
			var username = $("#RegUserName").val() + "";
			reg=/^[a-zA-Z0-9_\-]+$/gi;
            if(username.length < 5){
                regTip("errRegUserName","用户名不能小于5个字符", -1);
                return false;
            }
            else if(!reg.test(username)){
                alert(username);
                regTip("errRegUserName","用户名只能字母、数字、下划线", -1);
                return false;
            }
			else{
			    regTip("errRegUserName","正在验证...", 0);
				$.get("<%=GB_SitePath %>/Handle/IsExistUser.ashx?username=" + username + "&t=" + new Date(), function(data){
					var isok = parseInt(data);
					if(isok == 1){
				  		regTip("errRegUserName","该用户名可以使用", 1);
						return true;
					}
					else{
						regTip("errRegUserName","" + data, -1);
						return false;
					}
				});
			}
		}
		
		//检查注册密码
		function regCheckPassword(isRepassword){
		    var password = $("#RegPassword").val() + "";
            if(password.length < 6){
                regTip("errRegPassword","密码不能小于6个字符", -1);
                return false;
            }
            else
            {
                regTip("errRegPassword","验证通过", 1);
            }
            if(!isRepassword){
                return true;
            }
            var repassword = $("#RegRePassword").val() + "";
            if(repassword != password){
                regTip("errRegRePassword","两次密码不一致", -1);
                return false;
            }
            else{
                regTip("errRegRePassword","验证通过", 1);
            }
            return true;
		}
		
		//检查邮箱
		function regCheckEmail(){
		    var email = $("#RegEmail").val() + "";
		    reg=/^[a-zA-Z0-9_\-]+@[a-zA-Z0-9\-]+\.[a-zA-Z0-9\-\.]+$/gi;
            if(!reg.test(email) || email==""){
                regTip("errRegEmail","邮箱不合法", -1);
                return false;
            }
            regTip("errRegEmail","正在验证...", 0);
            $.get("<%=GB_SitePath %>/Handle/IsExistEmail.ashx?email=" + email + "&t=" + new Date(), function(data){
				var isok = parseInt(data);
				if(isok == 1){
			  		regTip("errRegEmail","该邮箱可以注册！", 1);
					return true;
				}
				else{
					regTip("errRegEmail","" + data, -1);
					return false;
				}
			});
            return true;
		}
        
        //注册提示，ID,信息，类型：0=无，1=成功，-1=失败
        function regTip(id, msg, type){
            if(type == 1){
                msg = "√ " + msg;
                $("#" + id).css("color","#090");
            }
            else if(type == -1){
                msg = "× " + msg;
                $("#" + id).css("color","#f00");
            }
            else{
                $("#" + id).css("color","#000");
            }
            $("#" + id).html(msg);
        };
        function regTipErr(id, msg){
            $("#" + id).html(msg);
            
        };
    </script>
