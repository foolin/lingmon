using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

public partial class ImageVal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ranum = this.Request.QueryString["id"];
        ranum = LFL.Utility.Security.MD5Util.ToMD5(ranum);
        ranum = ranum.Replace("-", "").Replace("A", "").Replace("B", "").Replace("C", "").Replace("D", "").Replace("E", "").Replace("F", "").Substring(0, 4);
        this.ValidateCode(ranum);
    }

    private Random r = new Random();


    private void ValidateCode(string VNum)
    {
        //生成验证code 
        System.Drawing.Bitmap img;
        System.Drawing.Graphics g;
        System.IO.MemoryStream ms;
        int gwidth = Convert.ToInt32(VNum.Length * 11.5);
        //gheight为图片宽度,根据字符长度自动更改图片宽度 
        img = new Bitmap(gwidth, 20);
        g = Graphics.FromImage(img);

        //画图片的背景噪音线


        for (int i = 0; i < 25; i++)
        {
            int x1 = r.Next(img.Width);
            int x2 = r.Next(img.Width);
            int y1 = r.Next(img.Height);
            int y2 = r.Next(img.Height);
            g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
        }

        //在矩形内绘制字串（字串，字体，画笔颜色，左上x.左上y） 
        g.DrawString(VNum, new Font("Arial", 11, System.Drawing.FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 3, 3);
        ms = new MemoryStream();

        //画图片的前景噪音点


        img.SetPixel(r.Next(img.Width), r.Next(img.Height), Color.FromArgb(r.Next()));

        img.Save(ms, ImageFormat.Png);
        Response.ClearContent(); //需要输出图象信息 要修改HTTP头 
        Response.ContentType = "image/png";
        Response.BinaryWrite(ms.ToArray());
        g.Dispose();
        img.Dispose();
        Response.End();
    } 
}
