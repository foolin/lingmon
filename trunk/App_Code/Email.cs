using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Net.Mail;

/// <summary>
///Email 的摘要说明
/// </summary>
public class Email
{
    public string SendFrom = SysConfig.Sys_SiteName + "<service@7dong.net>";
    public string SendUsername = "service";
    public string SendPassword = "foolinivy";
    public string SmtpServer = "smtp.qq.com";

    public Email()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 发送邮件，默认内容为HTML
    /// </summary>
    /// <param name="to"></param>
    /// <param name="title"></param>
    /// <param name="content"></param>
    public void SendMail(string to, string title, string content)
    {
        SendMail(to, "", title, content, true);
    }


    /// <summary>
    /// 发送邮件
    /// </summary>
    /// <param name="to"></param>
    /// <param name="title"></param>
    /// <param name="content"></param>
    /// <param name="isHtml"></param>
    public void SendMail(string to, string title, string content, bool isHtml)
    {
        SendMail(to, "", title, content, isHtml);
    }

    /// <summary>
    /// 发送邮件，默认内容为HTML
    /// </summary>
    /// <param name="to"></param>
    /// <param name="cc"></param>
    /// <param name="title"></param>
    /// <param name="content"></param>
    public void SendMail(string to, string cc, string title, string content)
    {
        SendMail(to, cc, title, content, true);
    }

    /// <summary>
    /// 发送邮件
    /// </summary>
    /// <param name="to">接收者</param>
    /// <param name="cc">抄送者</param>
    /// <param name="title">主题</param>
    /// <param name="content">内容</param>
    /// <param name="isHtml">是否Html</param>
    public void SendMail(string to, string cc, string title, string content, bool isHtml)
    {
        System.Web.Mail.MailMessage objMailMessage = null;

        // 创建邮件消息 
        objMailMessage = new System.Web.Mail.MailMessage();
        objMailMessage.From = SendFrom;//源邮件地址 
        //if (string.IsNullOrEmpty(to))
        //{
        //    return;
        //}
        objMailMessage.To = to;//目的邮件地址，也就是发给我哈 
        if (string.IsNullOrEmpty(cc))
        {
            objMailMessage.Cc = cc;
        }
        objMailMessage.Subject = title;//发送邮件的标题 
        objMailMessage.Body = content;//发送邮件的内容
        if (isHtml)
        {
            objMailMessage.BodyFormat = System.Web.Mail.MailFormat.Html;
        }

        // 创建一个附件对象 
        //System.Web.Mail.MailAttachment objMailAttachment; 
        //objMailAttachment = new System.Web.Mail.MailAttachment("D:\\temp\\mail.txt");//发送邮件的附件 
        //objMailMessage.Attachments.Add( objMailAttachment );//将附件附加到邮件消息对象中 

        //接着利用sina的SMTP来发送邮件，需要使用Microsoft .NET Framework SDK v1.1和它以上的版本 
        //基本权限 
        objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
        //用户名 
        objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", SendUsername);
        //密码 
        objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", SendPassword);
        //如果没有上述三行代码，则出现如下错误提示：服务器拒绝了一个或多个收件人地址。服务器响应为: 554 : Client host rejected: Access denied 
        //SMTP地址 
        System.Web.Mail.SmtpMail.SmtpServer = SmtpServer;

        //开始发送邮件 
        System.Web.Mail.SmtpMail.Send(objMailMessage); 
    }


    public void Send()
    {
        string mailServerName = "smtp.exmail.qq.com"; //发送邮件的SMTP服务器
        string mailFrom = "service@7dong.net";   //发件人邮箱（用126的邮件服务器，就必须用126邮箱的用户名）
        string mailTo = "傅零<foolin@liufu.org>,测试<1000@7dong.net>,服务<service@7dong.net>";   //收件人邮箱
        string subject = "用代码方式发送邮件";//邮件主题
        string body = "这里是邮件正文了"; //邮件正文

        //using (MailMessage message = new MailMessage(mailFrom, mailTo, subject, body))
        using (MailMessage message = new MailMessage())
        {
            message.To.Add(new MailAddress(mailTo));

            //MailMessage message = new MailMessage();
            //message.To = mailTo;
            //message.CC = "service@7dong.net";
            //message.From = "service@7dong.net";
            message.From =  new MailAddress("service@7dong.net");
            message.IsBodyHtml = true;
            message.Subject = "启动网欢迎您！";
            message.Body = "尊敬的用户，你正在使用刘傅网服务，详情请访问：http://www.liufu.org";
            message.To.Add("ling@liufu.org");
           // message.Priority = MailPriority.High; //发送邮件的优先等级 
            //SmtpClient是发送邮件的主体，这个构造函数是告知SmtpClient发送邮件时使用哪个SMTP服务器
            SmtpClient mailClient = new SmtpClient(mailServerName);
            //将认证实例赋予mailClient,也就是访问SMTP服务器的用户名和密码
            mailClient.Credentials = new System.Net.NetworkCredential("service@7dong.net", "foolinivy"); 
            //最终的发送方法
            try
            {
                mailClient.Send(message);
               // mailClient.SendAsync(message,message.Body);
            }
            catch (Exception ex)
            {
            }
            finally
            {

            }

        }
    }


}
