using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;
using System.Drawing;

public partial class Ajax_GetThumbImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Generate thumbnail of a webpage at 1024x768 resolution
        Bitmap thumbnail = GenerateScreenshot("http://www.google.com", 1024, 768);

        // Generate thumbnail of a webpage at the webpage's full size (height and width)
        thumbnail = GenerateScreenshot("http://www.google.com");

        // Display Thumbnail in PictureBox control
        thumbnail.Save(Server.MapPath("thumbnail.png"), System.Drawing.Imaging.ImageFormat.Png);

        /*
        // Save Thumbnail to a File
        thumbnail.Save("thumbnail.png", System.Drawing.Imaging.ImageFormat.Png);
        */

    }

    public Bitmap GenerateScreenshot(string url)
    {
        // This method gets a screenshot of the webpage
        // rendered at its full size (height and width)
        return GenerateScreenshot(url, -1, -1);
    }

    public Bitmap GenerateScreenshot(string url, int width, int height)
    {
        // Load the webpage into a WebBrowser control
        WebBrowser wb = new WebBrowser();
        wb.ScrollBarsEnabled = false;
        wb.ScriptErrorsSuppressed = true;
        wb.Navigate(url);
       // while (wb.ReadyState != WebBrowserReadyState.Complete) { Application.DoEvents(); }


        // Set the size of the WebBrowser control
        wb.Width = width;
        wb.Height = height;

        if (width == -1)
        {
            // Take Screenshot of the web pages full width
            wb.Width = wb.Document.Body.ScrollRectangle.Width;
        }

        if (height == -1)
        {
            // Take Screenshot of the web pages full height
            wb.Height = wb.Document.Body.ScrollRectangle.Height;
        }

        // Get a Bitmap representation of the webpage as it's rendered in the WebBrowser control
        Bitmap bitmap = new Bitmap(wb.Width, wb.Height);
        wb.DrawToBitmap(bitmap, new Rectangle(0, 0, wb.Width, wb.Height));
        wb.Dispose();

        return bitmap;
    }
}