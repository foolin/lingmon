using System;
using System.IO;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Collections;

using System.Messaging;

namespace Utility.Web
{
	/// <summary>
	/// Name:Web代理
	/// Description:实现Web页面常用功能
	/// Author:Foolin
	/// CreateDate:2010-09-16
	/// </summary>	
	public class WebAgent
	{
        /// <summary>
        /// 制作压缩图片
        /// </summary>
        /// <param name="originalImagePath"></param>
        /// <param name="thumbnailPath"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="mode"></param>
        /// <param name="imgFormat"></param>
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode, ImageFormat imgFormat)
        {
            Image image = Image.FromFile(originalImagePath);
            int num = width;
            int num2 = height;
            int x = 0;
            int y = 0;
            int num5 = image.Width;
            int num6 = image.Height;
            string text = mode;
            if ((text != null) && (text != "HW"))
            {
                if (text == "W")
                {
                    num2 = (image.Height * width) / image.Width;
                }
                else if (text == "H")
                {
                    num = (image.Width * height) / image.Height;
                }
                else if (text == "Cut")
                {
                    if ((((double)image.Width) / ((double)image.Height)) > (((double)num) / ((double)num2)))
                    {
                        num6 = image.Height;
                        num5 = (image.Height * num) / num2;
                        y = 0;
                        x = (image.Width - num5) / 2;
                    }
                    else
                    {
                        num5 = image.Width;
                        num6 = (image.Width * height) / num;
                        x = 0;
                        y = (image.Height - num6) / 2;
                    }
                }
            }
            Image image2 = new Bitmap(num, num2);
            Graphics graphics = Graphics.FromImage(image2);
            graphics.InterpolationMode = InterpolationMode.High;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(Color.Transparent);
            graphics.DrawImage(image, new Rectangle(0, 0, num, num2), new Rectangle(x, y, num5, num6), GraphicsUnit.Pixel);
            try
            {
                try
                {
                    image2.Save(thumbnailPath, (imgFormat == null) ? ImageFormat.Jpeg : imgFormat);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
                image.Dispose();
                image2.Dispose();
                graphics.Dispose();
            }
        }

        /// <summary>
        /// 提取字符串的左边length个字符
        /// </summary>
        /// <param name="input">从中提取的字符串</param>
        /// <param name="length">左起要提取的长度</param>
        /// <param name="keepAlt">是否保留alt说明</param>
        /// <returns>左起length个字符（带tag标签）</returns>
        public static string GetLeft(string input, int length, bool keepAlt)
        {
            if (input == null)
                return "";

            if (input.Length <= length)
                return input;
            else
                if (keepAlt)
                    return "<span title='" + input.Replace("'", "\"") + "'>" + input.Substring(0, length) + "...</span>";
                else
                    return input.Substring(0, length) + "...";
        }

        public static string GetLeft(object str, int len)
        {
            if (str is string == false)
            {
                return str.ToString();
            }
            string s = str.ToString();
            if (s.Length >= len)
            {
                if (!Regex.IsMatch(s, ".*([^\x00-\xff])+.*"))
                {
                    len = len * 2;
                }

                Regex my = new Regex(@"&[a-zA-Z]+;", RegexOptions.IgnoreCase);
                int record = my.Matches(s).Count;

                //len = len + record * 5;

                if (s.Length > len)
                {
                    s = s.Substring(0, len);
                }
            }

            return s;
        }
        /// <summary>
        /// 上传并压缩图片，只适应宽度
        /// </summary>
        /// <param name="file"></param>
        /// <param name="saveOrginalTo"></param>
        /// <param name="saveTo"></param>
        /// <param name="maxWidth"></param>
        public static void SaveFile(HttpPostedFile file, string saveOrginalTo, string saveTo, int maxWidth)
        {
            string contentType = file.ContentType;
            Image image = Image.FromStream(file.InputStream);
            int width = image.Width;
            int height = image.Height;
            double a = 0;
            double num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = width;
            int num8 = height;
            if ((maxWidth == 0) || (width <= maxWidth))
            {
                maxWidth = width;
            }
            a = width;
            num4 = height;
            if (width > maxWidth)
            {
                a = maxWidth;
                num4 = height * (a / ((double)width));
            }
            num5 = int.Parse(Math.Ceiling(a).ToString());
            num6 = int.Parse(Math.Ceiling(num4).ToString());
            if (saveOrginalTo != string.Empty)
            {
                image.Save(saveOrginalTo);
            }
            if (num5 != width)
            {
                ImageFormat imageFormat = GetImageFormat(contentType);
                string filename = saveTo + ".temp";
                image.Save(filename, imageFormat);
                MakeThumbnail(filename, saveTo, num5, num6, "W", imageFormat);
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
            }
            else
            {
                image.Save(saveTo);
            }
            image.Dispose();
            file.InputStream.Close();
        }



		/// <summary>
		/// 保存上传的文件,并生成缩略图
		/// </summary>
		/// <param name="file">上传的文件</param>
		/// <param name="saveTo">保存的文件路径</param>
		/// <param name="maxWidth">缩略图最大宽度</param>
		/// <param name="maxHeight">缩略图最大高度</param>
		public static void SaveFile( HttpPostedFile file, string saveTo, int maxWidth, int maxHeight, out int orginalWidth, out int orginalHeight, bool orginal)
		{
			string contentType = file.ContentType;
			Image img = System.Drawing.Image.FromStream(file.InputStream);//, simg;
			int w = img.Width, h = img.Height;
			double w1 = 0, h1 = 0;int w0 = 0, h0 = 0;
			
			orginalWidth = w;
			orginalHeight = h;
			
			if(maxWidth == 0) maxWidth = w;
			if(maxHeight == 0) maxHeight = h;
			//计算缩放比例
			w1 = w; h1 = h;
			if(w > maxWidth)
			{
				w1 = maxWidth;
				h1 = h * (w1 / w);
			}
			if(h1 > maxHeight)
			{
				w1 = w1 * (maxHeight / h1);
				h1 = maxHeight;
			}
			w0 = int.Parse(System.Math.Ceiling(w1).ToString()); h0 = int.Parse(System.Math.Ceiling(h1).ToString());

			if(orginal) img.Save( saveTo.Replace("S_", ""));

			if( w0 != w || h1 != h)	//当高或宽不相同时生成缩略图
			{
                //simg = img.GetThumbnailImage(w0, h0, null, System.IntPtr.Zero);
                //simg.Save( saveTo, GetImageFormat(contentType));
                //simg.Dispose();
                ImageFormat imageFormat = GetImageFormat(contentType);
                string filename = saveTo + ".temp";
                img.Save(filename, imageFormat);
                MakeThumbnail(filename, saveTo, w0, h0, "W", imageFormat);
                if (File.Exists(filename)) File.Delete(filename);
			}
			else
			{
				img.Save( saveTo);
			}
						
			img.Dispose();

			file.InputStream.Close();
		}
        
		public static void SaveFile( HttpPostedFile file, string saveTo, out int orginalWidth, out int orginalHeight)
		{
			string contentType = file.ContentType;
			Image img = System.Drawing.Image.FromStream(file.InputStream);
			int w = img.Width, h = img.Height;
			
			orginalWidth = w;
			orginalHeight = h;

			img.Save( saveTo);
						
			img.Dispose();

			file.InputStream.Close();
		}

        /// <summary>
        /// 保存并产生缩略图
        /// </summary>
        /// <param name="file"></param>
        /// <param name="saveOrginalTo">保存原大小的图片的路径</param>
        /// <param name="saveTo">保存压缩后的图片的路径</param>
        /// <param name="maxWidth"></param>
        /// <param name="maxHeight"></param>
        /// <param name="orginalWidth"></param>
        /// <param name="orginalHeight"></param>
        public static void SaveFile(HttpPostedFile file , string saveOrginalTo , string saveTo , int maxWidth , int maxHeight , out int orginalWidth , out int orginalHeight)
        {

            string contentType = file.ContentType;

            Image img = System.Drawing.Image.FromStream( file.InputStream );// , simg;
            int w = img.Width , h = img.Height;
            double w1 = 0 , h1 = 0; int w0 = 0 , h0 = 0;

            orginalWidth = w;
            orginalHeight = h;

            if ( maxWidth == 0 ) maxWidth = w;
            if ( maxHeight == 0 ) maxHeight = h;
            //计算缩放比例
            w1 = w; h1 = h;
            if ( w > maxWidth )
            {
                w1 = maxWidth;
                h1 = h * ( w1 / w );
            }
            if ( h1 > maxHeight )
            {
                w1 = w1 * ( maxHeight / h1 );
                h1 = maxHeight;
            }
            w0 = int.Parse( System.Math.Ceiling( w1 ).ToString() ); h0 = int.Parse( System.Math.Ceiling( h1 ).ToString() );

            if ( saveOrginalTo != string.Empty ) img.Save( saveOrginalTo );

            if ( w0 != w || h1 != h )	//当高或宽不相同时生成缩略图
            {
                //simg = img.GetThumbnailImage(w0, h0, null, System.IntPtr.Zero);
                //simg.Save( saveTo, GetImageFormat(contentType));
                //simg.Dispose();
                ImageFormat imageFormat = GetImageFormat( contentType );
                string filename = saveTo + ".temp";
                img.Save( filename , imageFormat );
                MakeThumbnail( filename , saveTo , w0 , h0 , "W" , imageFormat );
                if ( File.Exists( filename ) ) File.Delete( filename );
            }
            else
            {
                img.Save( saveTo );
            }

            img.Dispose();

            file.InputStream.Close();
        }

        /// <summary>
        /// 压缩本地图片
        /// </summary>
        /// <param name="oldFile">本地图片路径</param>
        /// <param name="saveTo">保存后路径</param>
        /// <param name="maxWidth"></param>
        /// <param name="maxHeight"></param>
        /// <param name="orginalWidth"></param>
        /// <param name="orginalHeight"></param>
        public static void SaveFile(string oldFile  , string saveTo , int maxWidth , int maxHeight , out int orginalWidth , out int orginalHeight)
        {
            string contentType = Path.GetExtension(oldFile);;

            FileStream fs = new FileStream( oldFile , FileMode.Open );

            Image img = System.Drawing.Image.FromStream( fs ) ;
            int w = img.Width , h = img.Height;
            double w1 = 0 , h1 = 0; int w0 = 0 , h0 = 0;

            orginalWidth = w;
            orginalHeight = h;

            if ( maxWidth == 0 ) maxWidth = w;
            if ( maxHeight == 0 ) maxHeight = h;
            //计算缩放比例
            w1 = w; h1 = h;
            if ( w > maxWidth )
            {
                w1 = maxWidth;
                h1 = h * ( w1 / w );
            }
            if ( h1 > maxHeight )
            {
                w1 = w1 * ( maxHeight / h1 );
                h1 = maxHeight;
            }
            w0 = int.Parse( System.Math.Ceiling( w1 ).ToString() ); h0 = int.Parse( System.Math.Ceiling( h1 ).ToString() );

            //if ( saveOrginalTo != string.Empty ) img.Save( saveOrginalTo );

            if ( w0 != w || h1 != h )	//当高或宽不相同时生成缩略图
            {
                //simg = img.GetThumbnailImage(w0, h0, null, System.IntPtr.Zero);
                //simg.Save( saveTo, GetImageFormat(contentType));
                //simg.Dispose();
                ImageFormat imageFormat = GetImageType( contentType );
                string filename = saveTo + ".temp";
                img.Save( filename , imageFormat );
                MakeThumbnail( filename , saveTo , w0 , h0 , "W" , imageFormat );
                if ( File.Exists( filename ) ) File.Delete( filename );
            }
            else
            {
                img.Save( saveTo );
            }

            img.Dispose();

            fs.Close();
        }

        public static void SaveFile(string oldFile,out int orginalWidth, out int orginalHeight,params CompressionImage[] compressions)
        {
            string contentType = Path.GetExtension(oldFile); ;

            FileStream fs = new FileStream(oldFile, FileMode.Open);

            Image img = System.Drawing.Image.FromStream(fs);
            int w = img.Width, h = img.Height;
            double w1 = 0, h1 = 0; int w0 = 0, h0 = 0;

            orginalWidth = w;
            orginalHeight = h;
            foreach (CompressionImage compression in compressions)
            {
                int maxWidth = compression.Width;
                int maxHeight = compression.Height;

                if (maxWidth == 0) maxWidth = w;
                if (maxHeight == 0) maxHeight = h;

                w1 = w; h1 = h;
                if (w > maxWidth)
                {
                    w1 = maxWidth;
                    h1 = h * (w1 / w);
                }
                if (h1 > maxHeight)
                {
                    w1 = w1 * (maxHeight / h1);
                    h1 = maxHeight;
                }
                w0 = int.Parse(System.Math.Ceiling(w1).ToString()); h0 = int.Parse(System.Math.Ceiling(h1).ToString());
                
                if (w0 != w || h1 != h)	//当高或宽不相同时生成缩略图
                {
                    //simg = img.GetThumbnailImage(w0, h0, null, System.IntPtr.Zero);
                    //simg.Save( saveTo, GetImageFormat(contentType));
                    //simg.Dispose();
                    ImageFormat imageFormat = GetImageType(contentType);
                    string filename = compression.FileName + ".temp";
                    img.Save(filename, imageFormat);
                    MakeThumbnail(filename, compression.FileName, w0, h0, "W", imageFormat);
                    if (File.Exists(filename)) File.Delete(filename);
                }
                else
                {
                    img.Save(compression.FileName);
                }

            }

            img.Dispose();

            fs.Close();
        }

		/// <summary>
		/// 保存上传的文件生成缩略图
		/// </summary>
		/// <param name="file">上传的文件</param>
		/// <param name="saveTo">保存的文件路径</param>
		/// <param name="maxWidth">缩略图最大宽度</param>
		/// <param name="maxHeight">缩略图最大高度</param>
		/// <param name="orginal">是否保存原图</param>
		public static void SaveFile( HttpPostedFile file, string saveTo, int maxWidth, int maxHeight, bool orginal)
		{
			int w,h;
			SaveFile( file, saveTo, maxWidth, maxHeight, out w, out h, orginal);
		}

		/// <summary>
		/// 保存上传的文件生成缩略图
		/// </summary>
		/// <param name="file">上传的文件</param>
		/// <param name="saveTo">保存的文件路径</param>
		/// <param name="maxWidth">缩略图最大宽度</param>
		/// <param name="maxHeight">缩略图最大高度</param>
		/// 
		public static void SaveFile( HttpPostedFile file, string saveTo, int maxWidth, int maxHeight)
		{
			int w,h;
			SaveFile( file, saveTo, maxWidth, maxHeight, out w, out h, true);
		}

		//获取图片文件类型
		static System.Drawing.Imaging.ImageFormat GetImageFormat(string strContentType)
		{
			switch (strContentType.ToString().ToLower())
			{
				case "image/pjpeg":
					return System.Drawing.Imaging.ImageFormat.Jpeg;
				case "image/gif":
					return System.Drawing.Imaging.ImageFormat.Gif;
				case "image/bmp":
					return System.Drawing.Imaging.ImageFormat.Bmp;
				case "image/tiff":
					return System.Drawing.Imaging.ImageFormat.Tiff;
				case "image/x-icon":
					return System.Drawing.Imaging.ImageFormat.Icon;
				case "image/x-png":
					return System.Drawing.Imaging.ImageFormat.Png;
				case "image/x-emf":
					return System.Drawing.Imaging.ImageFormat.Emf;
				case "image/x-exif":
					return System.Drawing.Imaging.ImageFormat.Exif;
				case "image/x-wmf":
					return System.Drawing.Imaging.ImageFormat.Wmf;
				default:
					return System.Drawing.Imaging.ImageFormat.MemoryBmp;
			}
		}

        static System.Drawing.Imaging.ImageFormat GetImageType(string strContentType)
        {
            switch ( strContentType.ToString().ToLower() )
            {
                case "jpeg":
                    return System.Drawing.Imaging.ImageFormat.Jpeg;
                case "gif":
                    return System.Drawing.Imaging.ImageFormat.Gif;
                case "bmp":
                    return System.Drawing.Imaging.ImageFormat.Bmp;
                case "tiff":
                    return System.Drawing.Imaging.ImageFormat.Tiff;
                case "icon":
                    return System.Drawing.Imaging.ImageFormat.Icon;
                case "png":
                    return System.Drawing.Imaging.ImageFormat.Png;
                case "emf":
                    return System.Drawing.Imaging.ImageFormat.Emf;
                case "exif":
                    return System.Drawing.Imaging.ImageFormat.Exif;
                case "wmf":
                    return System.Drawing.Imaging.ImageFormat.Wmf;
                default:
                    return System.Drawing.Imaging.ImageFormat.MemoryBmp;
            }
        }

		/// <summary>
		/// 判断是否为图片
		/// </summary>
		/// <param name="strContentType">POST过来的ContentType文件类型信息</param>
		/// <returns>是图片为true,否则为false</returns>
		public static  bool IsImage(string strContentType)
		{
			switch (strContentType.ToString().ToLower())
			{
				case "image/pjpeg":
				case "image/gif":
				case "image/bmp":
				case "image/tiff":
				case "image/x-icon":
				case "image/x-png":
				case "image/x-emf":
				case "image/x-exif":
				case "image/x-wmf":
					return true;
				default:
					return false;
			}
		}

		/// <summary>
		/// 判断是否为图片
		/// </summary>
		/// <param name="strContentType">POST过来的ContentType文件类型信息</param>
		/// <returns>图片类型</returns>
		public static string GetImageFix(string strContentType)
		{
			switch (strContentType.ToString().ToLower())
			{
				case "image/pjpeg":		return ".jpg";
				case "image/gif":		return ".gif";
				case "image/bmp":		return ".bmp";
				case "image/tiff":		return ".tiff";
				case "image/x-icon":	return ".icon";
				case "image/x-png":		return ".png";
				case "image/x-emf":		return ".emf";
				case "image/x-exif":	return ".exif";
				case "image/x-wmf":		return ".wmf";
				default:				return ".gif";
			}
		}
		
		/// <summary>
		/// 判断字符串是否是为字符和数字
		/// Author:Turboc
		/// Date:2006-2-6
		/// </summary>
		public static bool IsString(string str)
		{
			Regex rex = new Regex(@"\W");
			return !rex.IsMatch(str);
		}

		/// <summary>
		/// 判断字符串是否是数字
		/// </summary>
		public static bool IsNumeric( string s )
		{
			if( s == null || s.Equals(String.Empty) )
			{
				return false;
			}

			foreach(char c in s)
			{
				if( !Char.IsNumber(c))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// 判断字符串是否是Int32数字(系统预设9位)
		/// </summary>
		public static bool IsInt32( string s )
		{

			if( s == null || s.Equals(String.Empty) || s.Length > 9)
			{
				return false;
			}

            if (s.Substring(0, 1) == "-")
                s = s.Substring(1);

			foreach(char c in s)
			{
				if( !Char.IsNumber(c))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// 判断字符串是否是Int16数字(系统预设4位)
		/// </summary>
		public static bool IsInt16( string s )
		{
			if( s == null || s.Equals(String.Empty) || s.Length > 4)
			{
				return false;
			}

			foreach(char c in s)
			{
				if( !Char.IsNumber(c))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// 判断字符串是否是日期类型
		/// </summary>
		public static bool IsDate( string s )
		{
			if( s == null || s.Equals(String.Empty))
				return false;
			else
				return Regex.IsMatch(s, "^\\s*((\\d{4})|(\\d{2}))([-./])(\\d{1,2})\\4(\\d{1,2})\\s*$");
		}

		/// <summary>
		/// 判断字符串是否是有效的Url地址
		/// </summary>
		public static bool IsUrl( string s )
		{
			return Regex.IsMatch( s, @"http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?" );
		}

		/// <summary>
		/// 判断字符串是否是有效的电子邮件地址
		/// </summary>
		public static bool IsEmail( string s )
		{
			return Regex.IsMatch( s, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" );
		}

		/// <summary>
		/// 判断字符串是否是有效的身份证号码
		/// </summary>
		public static bool IsIDCard( string s )
		{
			return Regex.IsMatch( s, @"\d{18}|\d{15}" );
		}

		public static string NewKey()
		{
			return NewKey( KeyCreationType.Time);
		}

		public static string NewKey( KeyCreationType t)
		{
			switch (t)
			{
				case KeyCreationType.Time:
				{
					return DateTime.Now.Ticks.ToString();
				}
				default:return NewKey( KeyCreationType.Time);
			}
		}

        public static string[] Split(string source, string separator)
        {
            int len = separator.Length;
            ArrayList al = new ArrayList();
            int start = 0; //开始位置
            int j = -1; //匹配索引位置
            while (true)
            {
                j = source.IndexOf(separator, start);
                if (j > -1)
                {
                    al.Add(source.Substring(start, j - start));
                    int s = j - start;
                    start = j + len;
                }
                else
                {
                    al.Add(source.Substring(start));
                    break;
                }
            }
            string[] result;
            if (al.Count == 0)
            {
                string[] r = new string[1];
                r[0] = source;
                result = r;
            }
            else
            {
                string[] r = new string[al.Count];
                for (int i = 0; i < al.Count; i++)
                {
                    r[i] = al[i].ToString();
                }
                result = r;
            }
            return result;
        }

		/// <summary>
		/// 转换UBB代码
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string UbbCode(string str)
		{   
			str = str.Replace("\n", "<br>");
			str = Regex.Replace(str, @"\[b](?<x>[^\[]*)\[/b]", "<B>$1</B>", RegexOptions.IgnoreCase);
			str = Regex.Replace(str, @"\[u](?<x>[^\[]*)\[/u]", "<U>$1</U>", RegexOptions.IgnoreCase);
			str = Regex.Replace(str, @"\[i](?<x>[^\[]*)\[/i]", "<I>$1</I>", RegexOptions.IgnoreCase);
			str = Regex.Replace(str, @"\[em(?<x>([0-9]*))]", "<img src='http://public.anyp.net/images/ubb/em/$1.gif'>", RegexOptions.IgnoreCase);

			//str = Regex.Replace(str, @"\[em=(?<x>([0-9]*))\]", "<img src='http://public.anyp.net/images/ubb/em/$1.gif'>", RegexOptions.IgnoreCase);

			str = Regex.Replace(str, @"\[pic](?<x>[^\]]*)\[/pic]", "<img src='$1'>", RegexOptions.IgnoreCase);

			str = Regex.Replace(str, @"\[url](?<x>[^\]]*)\[/url]", "<a href='$1' target='_blank'>$1</a>", RegexOptions.IgnoreCase);
			str = Regex.Replace(str, @"\[color=(?<x>[^\]]*)](?<y>[^\]]*)\[/color]", "<font color='$1'>$2</font>", RegexOptions.IgnoreCase);
			str = Regex.Replace(str, @"\[url=(?<x>[^\]]*)](?<y>[^\]]*)\[/url]", "<a href='$1' target='_blank'>$2</a>", RegexOptions.IgnoreCase);

			//str = Regex.Replace(str, @"\[mp=(?<x>([0-9]*)),(?<y>([0-9]*))](?<z>[^\]]*)\[/mp]", "<OBJECT ID='Windows Media Player' WIDTH='$1' HEIGHT='$2' CLASSID='CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6'><param name=url value='$1'></OBJECT>", RegexOptions.IgnoreCase);

			str = Regex.Replace(str, @"\[flash=(?<x>([0-9]*)),(?<y>([0-9]*))](?<z>[^\]]*)\[/flash]", "<embed src='$3' width='$1' height='$2' quality='high' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash' name='Adodb MacroMedia Flash Player'></embed>", RegexOptions.IgnoreCase);
			//str = Regex.Replace(str, @"\[rm=(?<x>([0-9]*)),(?<y>([0-9]*))](?<z>[^\]]*)\[/rm]", "<OBJECT classid=clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA class=OBJECT id=RAOCX width=$1 height=$2><PARAM NAME=SRC VALUE='$3'><PARAM NAME=CONSOLE VALUE=Clip1><PARAM NAME=CONTROLS VALUE=imagewindow><PARAM NAME=AUTOSTART VALUE=true></OBJECT><br><OBJECT classid=CLSID:CFCDAA03-8BE4-11CF-B84B-0020AFBBCCFA height=32 id=video2 width=$1><PARAM NAME=SRC VALUE='$3'><PARAM NAME=AUTOSTART VALUE=-1><PARAM NAME=CONTROLS VALUE=controlpanel><PARAM NAME=CONSOLE VALUE=Clip1></OBJECT>", RegexOptions.IgnoreCase);
			return str;
		}

		/// <summary>
		/// 修正IP,最后一段用*代替
		/// </summary>
		/// <param name="ip">完整IP</param>
		/// <returns></returns>
		public static string FixIP( string ip)
		{
			if( ip.IndexOf('.') > 0)
				return ip.Substring(0, ip.LastIndexOf('.') + 1) + '*';
			else
				return ip;
		}



        /// <summary>
        /// 取IP
        /// </summary>
        /// <returns></returns>
        public static string GetIP()
        {
            string user_IP = "";
            if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                user_IP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else
            {
                user_IP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            return user_IP;
        }


        /// <summary>
        /// 获取主机URL，包括虚拟目录
        /// </summary>
        /// <returns></returns>
        public static string GetDomainURL()
        {
            string strUrl = "http://" + HttpContext.Current.Request.ServerVariables["HTTP_HOST"].ToString();
            if (HttpContext.Current.Request.ApplicationPath.Length > 1)
            {
                strUrl += HttpContext.Current.Request.ApplicationPath;
            }
            return strUrl;

        }


        /// <summary>
        /// 创建弹出信息
        /// </summary>
        /// <param name="msg">弹出的信息</param>
        public static void Alert(string msg)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>alert('" + msg.Replace("'", "").Replace("\n","\\n").Replace("\r","\\r") + "');</script>");
        }

        /// <summary>
        /// 创建弹出信息并返回原页面
        /// </summary>
        /// <param name="msg">弹出的信息</param>
        public static void AlertAndBack(string msg)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write("<script language='javascript'>alert('" + msg.Replace("'", "").Replace("\n", "\\n").Replace("\r", "\\r") + "');history.go(-1);</script>");
            HttpContext.Current.Response.End();
        }

        public static void ConfirmAndGo(string msg, string trueUrl, string falseUrl)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(string.Format("<script language='javascript'>if( confirm('{0}')) document.location.href='{1}'; else document.location.href='{2}';</script>", msg.Replace("'", "").Replace("\n", "\\n").Replace("\r", "\\r"), trueUrl, falseUrl));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 弹出一条消息,点确定后跳转到指定Url
        /// </summary>
        /// <param name="msg">弹出的信息</param>
        /// <param name="goUrl">要跳转的Url</param>
        public static void AlertAndGo(string msg, string goUrl)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(String.Format("<script language='javascript'>alert('{0}');document.location.href='{1}';</script>", msg.Replace("'", "").Replace("\n", "\\n").Replace("\r", "\\r"), goUrl));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 创建弹出信息并返回刷新
        /// </summary>
        /// <param name="msg">弹出的信息</param>
        public static void AlertAndRefresh(string msg)
        {
            AlertAndGo(msg, HttpContext.Current.Request.ServerVariables["HTTP_REFERER"].ToString());
        }


        /// <summary>
        /// 在页面上停留一段时间(通常是几钞钟),显示一条等待信息,然后跳转到指定页面
        /// </summary>
        /// <param name="sec">停留时间(单位:秒)</param>
        /// <param name="alterMsg">等待信息内容</param>
        /// <param name="goUrl">跳转的地址</param>
        /// <param name="clearResp">是否清除响应内容</param>
        public static void WaitAndGo(int sec, string alterMsg, string goUrl, bool clearResp)
        {
            if (clearResp)
            {
                HttpContext.Current.Response.Clear();
            }

            HttpContext.Current.Response.Write(alterMsg);
            HttpContext.Current.Response.Write(String.Format("<script language='javascript'>setTimeout(\"document.location.href='{1}';\", {2}*1000);</script>", alterMsg.Replace("'", "").Replace("\n", "\\n").Replace("\r", "\\r"), goUrl, sec));

            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 在当前请求中输出一个隐藏的Iframe
        /// </summary>
        /// <param name="url">Iframe在源地址</param>
        public static void CreateHiddenIFrame(string url)
        {
            HttpContext.Current.Response.Write("<iframe style='width:100px;height:100px;' frameborder=0 src='" + url + "'></iframe>");
        }



        /// <summary>
        /// 取文本，格式化掉HTML
        /// </summary>
        /// <param name="htmlText"></param>
        /// <returns></returns>
        public static string GetText(string htmlText)
        {
            if (string.IsNullOrEmpty(htmlText))
                return htmlText;

            Regex regexStripHTML = new Regex("<[^>]+>", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
            htmlText = regexStripHTML.Replace(htmlText, "");
            regexStripHTML = new Regex("&[a-zA-Z]*;", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
            htmlText = regexStripHTML.Replace(htmlText, "");
            return htmlText;
        }

        /// <summary>
        /// 将路径转为绝对路径
        /// </summary>
        /// <param name="strPath">传入的路径</param>
        /// <returns>返回全路径</returns>
        public static string ToFullPath(string strPath)
        {
            string strReturn = string.Empty;
            //判断是否存在绝对路径
            if (strPath.Substring(1, 1) != ":")
            {
                strReturn = AppDomain.CurrentDomain.BaseDirectory;
            }
            strReturn += strPath;
            ////如果后面没有\，则添加\
            //string lastChar = strPath.Substring(strPath.Length - 1, 1);
            //if (lastChar != "\\" && lastChar != "/")
            //{
            //    strReturn += "\\";
            //}
            return strReturn.Replace("/", "\\");
        }

        /// <summary>
        /// 获取当前网址
        /// </summary>
        /// <returns></returns>
        public static string GetURL()
        {
            return HttpContext.Current.Request.Url.AbsoluteUri;
        }


	}

	public enum KeyCreationType
	{
		Time = 1
	}

    public struct CompressionImage
    {
        public string FileName;
        public int Height;
        public int Width;
    }
}
