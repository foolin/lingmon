using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.IO;
using System.Web;

namespace Utility.IO
{
    public class FileUtil
    {
        /// <summary>
        /// 按指定路径按年月日分级目录和随机文件名保存文件
        /// </summary>
        /// <param name="oFile">要上传的文件</param>
        /// <param name="sExt">指定允许上传的文件类型，要带点</param>
        /// <param name="iSize">最大上传文件大小</param>
        /// <param name="sFilePath">保存的目录</param>
        /// <returns></returns>
        public static string SaveAs(FileUpload oFile, string sExt, int iSize, string sFilePath)
        {
            if (oFile.HasFile)
            {
                string ext = Path.GetExtension(oFile.FileName.ToLower());
                if (!sExt.Contains(ext))
                {
                    //文件类型不匹配
                    return "1";
                }
                int size = oFile.FileBytes.Length / 1024;
                if (iSize < size)
                {
                    //文件大小超出最大限制
                    return "2";
                }
                string SavePath = sFilePath + "/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
                if (CreateFolder(SavePath))
                {
                    Random rnd = new Random();
                    SavePath += "/" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + rnd.Next(1000, 9999).ToString() + ext;
                    oFile.SaveAs(HttpContext.Current.Server.MapPath(SavePath));
                    return SavePath;
                }
                else
                {
                    //创建目录失败
                    return "3";
                }
            }
            else
            {
                //没有选择文件
                return "0";
            }
        }

        /// <summary>
        /// 按指定路径指定文件名保存文件
        /// </summary>
        /// <param name="oFile">要上传的文件</param>
        /// <param name="sExt">指定允许上传的文件类型，要带点</param>
        /// <param name="iSize">最大上传文件大小</param>
        /// <param name="sFilePath">保存的目录</param>
        /// <returns></returns>
        public static string SaveAs(FileUpload oFile, string sExt, int iSize, string sFilePath, string sFileName)
        {
            if (oFile.HasFile)
            {
                string ext = Path.GetExtension(oFile.FileName.ToLower());
                if (!sExt.Contains(ext))
                {
                    //文件类型不匹配
                    return "1";
                }
                int size = oFile.FileBytes.Length / 1024;
                if (iSize < size)
                {
                    //文件大小超出最大限制
                    return "2";
                }
                string SavePath = sFilePath;
                if (CreateFolder(SavePath))
                {
                    SavePath += "/" + sFileName;
                    oFile.SaveAs(HttpContext.Current.Server.MapPath(SavePath));
                    return SavePath;
                }
                else
                {
                    //创建目录失败
                    return "3";
                }
            }
            else
            {
                //没有选择文件
                return "0";
            }
        }

        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="sFolder"></param>
        /// <returns></returns>
        private static bool CreateFolder(string sFolder)
        {
            try
            {
                string LocalFolder = HttpContext.Current.Server.MapPath(sFolder);
                if (!Directory.Exists(LocalFolder))
                {
                    Directory.CreateDirectory(LocalFolder);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 生成日期目录
        /// </summary>
        /// <param name="SaveDir">文件保存路径</param>
        /// <returns>日期目录</returns>
        public static string MakeDateDirectory(string SaveDir)
        {
            string DateDir = DateTime.Now.ToString("yyyyMMdd") + "/";
            if (!Directory.Exists(SaveDir + DateDir))     //如果目录不存在 
            {
                Directory.CreateDirectory(SaveDir + DateDir);//创建日期目录
            }
            return DateDir;
        }


        /// <summary>
        /// 生成新的文件名
        /// </summary>
        /// <param name="file_ex">文件的扩展名</param>
        public static string MakeFileName(string file_ex)
        {
            Random random = new Random();
            int number = random.Next(1000, 9999);
            return DateTime.Now.ToString("yyMMddmmssfff") + number.ToString() + file_ex;
        }

        /// <summary>
        /// 获取文件Size(KB)
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static int GetFileSize(string filePath)
        {
            if (File.Exists(filePath))
            {
                FileInfo fileInfo = new FileInfo(filePath);
                int intBytes = (int)fileInfo.Length;
                fileInfo = null;
                int KBytes = intBytes / 1024;
                if (intBytes % 1024 > 0)
                    KBytes++;
                return KBytes;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filePath"></param>
        public static void DeleteFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            catch
            {
            }
        }






        #region 一些输出操作

        /// <summary> 
        /// 将 byte[] 转成 Stream 
        /// </summary> 
        public static Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }


        /// <summary>
        /// 提供下载流，下载
        /// </summary>
        /// <param name="_Request">Page.Request对象</param>
        /// <param name="_Response">Page.Response对象</param>
        /// <param name="_fileName">下载文件名</param>
        /// <param name="_fullPath">带文件名下载路径</param>
        /// <param name="_speed">每秒允许下载的字节数</param>
        /// <returns>返回是否成功</returns>
        public static bool ResponseFile(HttpRequest _Request, HttpResponse _Response, string _fileName, string _fullPath, string _contentType)
        {
            FileStream myFile = new FileStream(_fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BinaryReader br = new BinaryReader(myFile);
            br.BaseStream.Seek(0, SeekOrigin.Begin);
            byte[] contentBytes = br.ReadBytes((int)myFile.Length);
            br.Close();
            myFile.Close();
            return ResponseContent(_Request, _Response, contentBytes, _fileName, _contentType);
        }

        /// <summary>
        /// 提供下载流，下载
        /// </summary>
        /// <param name="_Request">Page.Request对象</param>
        /// <param name="_Response">Page.Response对象</param>
        /// <param name="_fileName">下载文件名</param>
        /// <param name="_fullPath">带文件名下载路径</param>
        /// <param name="_speed">每秒允许下载的字节数</param>
        /// <returns>返回是否成功</returns>
        public static bool ResponseFile(HttpRequest _Request, HttpResponse _Response, byte[] content, string _fileName, string _contentType)
        {
            return ResponseContent(_Request, _Response, content, _fileName, _contentType);
        }

        /// <summary>
        /// 输出硬盘文件，提供下载
        /// </summary>
        /// <param name="_Request">Page.Request对象</param>
        /// <param name="_Response">Page.Response对象</param>
        /// <param name="_fileName">下载文件名</param>
        /// <param name="_fullPath">带文件名下载路径</param>
        /// <param name="_speed">每秒允许下载的字节数</param>
        /// <returns>返回是否成功</returns>
        public static bool ResponseContent(HttpRequest _Request, HttpResponse _Response, byte[] content, string _fileName, string _contentType)
        {

            //try
            //{

            _Response.AddHeader("Accept-Ranges", "bytes");
            _Response.Buffer = false;
            int fileLength = content.Length;
            _Response.AddHeader("Content-Range", string.Format(" bytes {0}-{1}/{2}", 0, fileLength - 1, fileLength));
            _Response.AddHeader("Content-Length", fileLength.ToString());
            _Response.ContentType = _contentType;
            _Response.Charset = "Unicode";
            _Response.ContentEncoding = Encoding.Unicode;
            _Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(_fileName, Encoding.ASCII));
            _Response.BinaryWrite(content);

            _Response.End();
            _Response.Flush();

            #region...... BAK.....................

            //_Response.AddHeader("Accept-Ranges", "bytes");
            //_Response.Buffer = false;
            //long fileLength = stream.Length;
            //long startBytes = 0;

            //int pack = 10240; //10K bytes

            //int sleep = (int)Math.Floor((decimal)1000 * pack / _speed) + 1;
            //if (_Request.Headers["Range"] != null)
            //{
            //    _Response.StatusCode = 206;
            //    string[] range = _Request.Headers["Range"].Split(new char[] { '=', '-' });
            //    startBytes = Convert.ToInt64(range[1]);
            //}
            //_Response.AddHeader("Content-Length", (fileLength - startBytes).ToString());
            //if (startBytes != 0)
            //{
            //    _Response.AddHeader("Content-Range", string.Format(" bytes {0}-{1}/{2}", startBytes, fileLength - 1, fileLength));
            //}
            //_Response.AddHeader("Connection", "Keep-Alive");
            //_Response.ContentType = _contentType;
            //_Response.Charset = "Unicode";
            //_Response.ContentEncoding = Encoding.Unicode;
            //_Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(_fileName, Encoding.ASCII));

            //br.BaseStream.Seek(startBytes, SeekOrigin.Begin);

            //int maxCount = (int)Math.Floor((decimal)(fileLength - startBytes) / pack) + 1;

            //for (int i = 0; i < maxCount; i++)
            //{
            //    if (_Response.IsClientConnected)
            //    {
            //        _Response.BinaryWrite(br.ReadBytes(pack));
            //        Thread.Sleep(sleep);
            //    }
            //    else
            //    {
            //        i = maxCount;
            //    }
            //}
            //_Response.End();

            #endregion

            //}
            //catch(Exception ex)
            //{
            //    Log.Add("downLoad:"+_fileName+","+ex.Message);
            //    return false;
            //}
            //finally
            //{


            //}

            return true;
        }

        #endregion


    }
}
