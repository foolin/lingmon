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


namespace CengZai.Helper
{

    /// <summary>
    ///Email 的摘要说明
    /// </summary>
    public class MailUtil
    {
        //用户名：task 密码：sxmobi
        public string mFrom = "曾在网<noreply@cengzai.com>";  //外面配置用：曾在网[noreply@cengzai.com]
        public string mUsername = "noreply@cengzai.com";
        public string mPassword = "lingmon";
        public string mSmtpServer = "smtp.exmail.qq.com";

        public MailUtil()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
            if (Config.MailFrom != "")
            {
                mFrom = Config.MailFrom.Replace('[', '<').Replace(']', '>');
            }
            if (Config.MailUserName != "")
            {
                mUsername = Config.MailUserName;
            }
            if (Config.MailPassword != "")
            {
                mPassword = Config.MailPassword;
            }
            if (Config.MailSmtpServer != "")
            {
                mSmtpServer = Config.MailSmtpServer;
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
                        Log.Add("Email地址非法：" + feTo + ",原因：" + ex.Message);
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
                        Log.Add("Email地址非法：" + feCc + ",原因：" + ex.Message);
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
                Log.Add("发送邮件出错！异常：" + ex.Message);
                throw ex;   //底层不捕捉异常
            }
            
        }



    }


    

}
