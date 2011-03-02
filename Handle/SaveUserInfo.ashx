<%@ WebHandler Language="C#" Class="SaveUserInfo" %>

using System;
using System.Web;
using KuaiLe.Us.Model;
using KuaiLe.Us.DAL;
using KuaiLe.Us.BLL;
using KuaiLe.Us.Common;

public class SaveUserInfo : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        if (context.Session["KL_LoginUser"] == null || context.Session["KL_LoginOK"] == null)
        {
            context.Response.StatusCode = 400;
            context.Response.Write("你尚未<a href='Login.aspx'>登录</a>！请先<a href='Login.aspx'>登录</a>或者<a href='Register.aspx'>注册</a>！");
            return;
        }

        UserModel user = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(context.Session["KL_LoginUser"].ToString());
        if (user == null)
        {
            context.Response.StatusCode = 400;
            context.Response.Write("你尚未<a href='Login.aspx'>登录</a>！请先<a href='Login.aspx'>登录</a>或者<a href='Register.aspx'>注册</a>！");
            return;
        }


        #region  ___取值并验证___
        /***  提交内容取值并验证 ******/
        
        //昵称
        string rqNickName = context.Request["nickname"] + "";
        if (rqNickName.Length > 20)
        {
            context.Response.StatusCode = 400;
            context.Response.Write("昵称不能超过20个字符");
            return;
        }
        //性别
        int rqSex = -1;
        try
        {
            rqSex = Convert.ToInt32(context.Request["sex"]);
        }
        catch
        {
        }
        //生日
        DateTime? rqBirth = null;
        try
        {
            rqBirth = Convert.ToDateTime(context.Request["birth"]);
        }
        catch
        {
            rqBirth = null;
        }
        //电话
        string rqPhone = context.Request["phone"] + "";
        if (rqPhone.Length > 20)
        {
            context.Response.StatusCode = 400;
            context.Response.Write("电话不正确，电话长度不能超过20位！");
            return;
        }
        //手机
        string rqMobile = context.Request["mobile"] + "";
        if (rqMobile.Length > 11)
        {
            context.Response.StatusCode = 400;
            context.Response.Write("手机不正确，手机号码不能超过11位！");
            return;
        }
        //地址
        string rqAddress = context.Request["address"] + "";
        if (rqAddress.Length > 50)
        {
            context.Response.StatusCode = 400;
            context.Response.Write("地址不能超过50个字符！");
            return;
        }
        //签名
        string rqMotto = context.Request["motto"] + "";
        if (rqMotto.Length > 50)
        {
            context.Response.StatusCode = 400;
            context.Response.Write("签名不能超过50个字符！");
            return;
        }
        //简介
        string rqIntro = context.Request["intro"] + "";
        if (rqMotto.Length > 300)
        {
            context.Response.StatusCode = 400;
            context.Response.Write("简介不能超过300个字符！");
            return;
        }
        //密码
        string rqPassword = Utility.Security.MD5Util.ToMD5(context.Request["password"] + "", 32);
        if (rqPassword != user.Password)
        {
            context.Response.StatusCode = 400;
            context.Response.Write("密码不正确，无法修改资料！");
            return;
        }

        #endregion

        /**** 赋值 *****/
        //昵称
        if (rqNickName.Length > 0)
        {
            user.Nickname = rqNickName;
        }
        if (rqSex >= 0 && rqSex <= 2)
        {
            user.Sex = rqSex;
        }
        if (rqBirth != null)
        {
            user.Birth = rqBirth;
        }
        else if(user.Birth == null)
        {
            user.Birth = user.RegTime;
        }
        user.Phone = rqPhone;
        user.Mobile = rqMobile;
        user.Address = rqAddress;
        user.Motto = rqMotto;
        user.Intro = rqIntro;
        
        //更新
        
        try
        {
            UserBll bll = new UserBll();
            bll.Update(user);
            WebLog.WriteInfoLog("用户" + user.UserName + "更新资料成功！");
        }
        catch(Exception ex)
        {
            WebLog.WriteErrLog("用户"+ user.UserName +"更新资料异常：" + ex.Message);
            context.Response.StatusCode = 400;
            context.Response.Write("更新资料失败，请检查输入或者稍后再试！");
            return;
        }

        context.Response.StatusCode = 200;
        context.Response.Write("更新资料成功！");
        context.Session["KL_LoginUser"] = Newtonsoft.Json.JsonConvert.SerializeObject(user);
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}