using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class wap_about : WapBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append(" <div class=\"article\"> ");

        sb.Append(" <div class=\"title\">关于手机快乐网(m.kuaile.us)</div> ");
        sb.Append(" 欢迎光临快乐网(www.kuaile.us)，我们的口号是“快乐，我们一起分享！”。<br/> ");
        sb.Append(" 电脑网址：www.kuaile.us <br/>  ");
        sb.Append(" 手机网址：m.kuaile.us <br/>   ");

        //sb.Append(" <hr> ");

        sb.Append(" <div class=\"title\">联系方式</div> ");
        sb.Append(" 快乐网(www.kuaile.us)致力打造中国最大的互动分享平台！如果有意加入我们或商业合作，请发送邮件到：Contact#kuaile.us (#换成@) 。<br/> ");
        sb.Append(" 电脑网址：www.kuaile.us <br/>   ");

        sb.Append(" </div> ");

        WritePage("关于我们", sb.ToString());
    }
}
