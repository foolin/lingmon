<%@ WebHandler Language="C#" Class="ChkCodeImage" %>

using System;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

public class ChkCodeImage : IHttpHandler, System.Web.SessionState.IRequiresSessionState{
    
    public void ProcessRequest (HttpContext context) {

        Random r = new Random();
        string codeNum = ((int)(new Random().NextDouble() * 100000)).ToString();

        context.Session["KL_ChkCode"] = codeNum;
        
        
        //生成验证code 
        System.Drawing.Bitmap img;
        System.Drawing.Graphics g;
        System.IO.MemoryStream ms;
        int gwidth = Convert.ToInt32(codeNum.Length * 11.5);
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
        g.DrawString(codeNum, new Font("Arial", 11, System.Drawing.FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 3, 3);
        ms = new MemoryStream();

        //画图片的前景噪音点


        img.SetPixel(r.Next(img.Width), r.Next(img.Height), Color.FromArgb(r.Next()));

        img.Save(ms, ImageFormat.Png);
        context.Response.ClearContent(); //需要输出图象信息 要修改HTTP头 
        context.Response.ContentType = "image/png";
        context.Response.BinaryWrite(ms.ToArray());
        g.Dispose();
        img.Dispose();
        context.Response.End();
    }

 
    public bool IsReusable {
        get {
            return false;
        }
    }

}