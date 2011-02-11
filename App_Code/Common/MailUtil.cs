using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;


namespace KuaiLe.Us.Common
{

    /// <summary>
    ///Email 的摘要说明
    /// </summary>
    public class MailUtil
    {
        //用户名：task 密码：sxmobi
        public string mFrom = "快乐网<service@kuaile.us>";  //外面配置用：快乐网[service@kuaile.us]
        public string mUsername = "service@kuaile.us";
        public string mPassword = "lingmon";
        public string mSmtpServer = "smtp.exmail.qq.com";

        public MailUtil()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
            if (SysConfig.MailFrom != "")
            {
                mFrom = SysConfig.MailFrom.Replace('[', '<').Replace(']', '>');
            }
            if (SysConfig.MailUserName != "")
            {
                mUsername = SysConfig.MailUserName;
            }
            if (SysConfig.MailPassword != "")
            {
                mPassword = SysConfig.MailPassword;
            }
            if (SysConfig.MailSmtpServer != "")
            {
                mSmtpServer = SysConfig.MailSmtpServer;
            }
        }

        /// <summary>
        /// 发送邮件，默认内容为HTML
        /// </summary>
        /// <param name="to"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        public void Send(string to, string title, string content)
        {
            Send(to, "", title, content, true);
        }


        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="to"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="isHtml"></param>
        public void Send(string to, string title, string content, bool isHtml)
        {
            Send(to, "", title, content, isHtml);
        }

        /// <summary>
        /// 发送邮件，默认内容为HTML
        /// </summary>
        /// <param name="to"></param>
        /// <param name="cc"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        public void Send(string to, string cc, string title, string content)
        {
            Send(to, cc, title, content, true);
        }

        ///// <summary>
        ///// 发送邮件
        ///// </summary>
        ///// <param name="to">接收者</param>
        ///// <param name="cc">抄送者</param>
        ///// <param name="title">主题</param>
        ///// <param name="content">内容</param>
        ///// <param name="isHtml">是否Html</param>
        //public void SendMail(string to, string cc, string title, string content, bool isHtml)
        //{
        //    Send(to, cc, title, content, isHtml);   //转到新版发送邮件

        //    #region 旧版- Deleted at 2010-12-24 缺陷：如果某人邮箱地址不存在，导致整个邮件无法发送
        //    /*
        //    content += GetContentFooter();
        //    to = to.Replace('[','<').Replace(']','>');
        //    cc = cc.Replace('[', '<').Replace(']', '>');

        //    content = "<div style=\"font-size:14px; line-height:25px;\">\r\n\r\n" + content + "\r\n\r\n</div>";

        //    System.Web.Mail.MailMessage objMailMessage = null;

        //    // 创建邮件消息 
        //    objMailMessage = new System.Web.Mail.MailMessage();
        //    objMailMessage.From = mFrom;//源邮件地址 
        //    //if (string.IsNullOrEmpty(to))
        //    //{
        //    //    return;
        //    //}
        //    objMailMessage.To = to;//目的邮件地址，也就是发给我哈 
        //    if (!string.IsNullOrEmpty(cc))
        //    {
        //        objMailMessage.Cc = cc;
        //    }
        //    objMailMessage.Subject = title;//发送邮件的标题 
        //    objMailMessage.Body = content;//发送邮件的内容
        //    if (isHtml)
        //    {
        //        objMailMessage.BodyFormat = System.Web.Mail.MailFormat.Html;
        //    }

        //    // 创建一个附件对象 
        //    //System.Web.Mail.MailAttachment objMailAttachment; 
        //    //objMailAttachment = new System.Web.Mail.MailAttachment("D:\\temp\\mail.txt");//发送邮件的附件 
        //    //objMailMessage.Attachments.Add( objMailAttachment );//将附件附加到邮件消息对象中 

        //    //接着利用sina的SMTP来发送邮件，需要使用Microsoft .NET Framework SDK v1.1和它以上的版本 
        //    //基本权限 
        //    objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
        //    //用户名 
        //    objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", mUsername);
        //    //密码 
        //    objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", mPassword);
        //    //如果没有上述三行代码，则出现如下错误提示：服务器拒绝了一个或多个收件人地址。服务器响应为: 554 : Client host rejected: Access denied 
        //    //SMTP地址 
        //    System.Web.Mail.SmtpMail.SmtpServer = mSmtpServer;

        //    //开始发送邮件 
        //    System.Web.Mail.SmtpMail.Send(objMailMessage);
        //     */
        //    #endregion
        //}


        /// <summary>
        /// 新版
        /// </summary>
        /// <param name="to"></param>
        /// <param name="cc"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="isHtml"></param>
        public void Send(string to, string cc, string title, string content, bool isHtml)
        {
            to = to.Replace('[', '<').Replace(']', '>');
            cc = cc.Replace('[', '<').Replace(']', '>');

            
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.From = new System.Net.Mail.MailAddress(mFrom);
            message.IsBodyHtml = isHtml;
            message.Subject = title;
            message.Body = content;

            string[] arrTo = to.Split(';');
            string[] arrCc = cc.Split(';');

            //添加多接收人
            foreach(string feTo in arrTo)
            {
                if (feTo.IndexOf('@') != -1)
                {
                    try
                    {
                        message.To.Add(new System.Net.Mail.MailAddress(feTo));
                    }
                    catch(Exception ex)
                    {
                        WebLog.WriteErrLog("Email地址非法：" + feTo + ",原因：" + ex.Message);
                    }
                }
            }

            //添加多抄送人
            foreach (string feCc in arrCc)
            {
                if (feCc.IndexOf('@') != -1)
                {
                    try
                    {
                        message.CC.Add(new System.Net.Mail.MailAddress(feCc));
                    }
                    catch (Exception ex)
                    {
                        WebLog.WriteErrLog("Email地址非法：" + feCc + ",原因：" + ex.Message);
                    }
                }
            }

            try
            {

                System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient(mSmtpServer);
                smtpClient.Credentials = new System.Net.NetworkCredential(mUsername, mPassword);
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                WebLog.WriteErrLog("发送邮件出错！异常：" + ex.Message);
                throw ex;   //底层不捕捉异常
            }
            
        }



    }


    

}
