using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Sxmobi.Tools
{
    public class ServerLogger
    {
        private string path;


        public ServerLogger()
        {
            //
            this.path = Application.StartupPath + "/Log/";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public ServerLogger(string path)
        {
            //
            this.path = path;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        /// <summary>
        /// libole20080624
        /// </summary>
        /// <param name="message"></param>
        public void WriteMessage(string message)
        {
            StreamWriter writer = null;
            try
            {
                System.DateTime today = System.DateTime.Now;
                string logFileName = path + "\\" + today.ToString("yyyyMMdd") + ".log";
                writer = File.AppendText(logFileName);
                message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ": " + message;
                writer.WriteLine(message);
                writer.Close();
            }
            catch (Exception)
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        /// <summary>
        /// 合并日志文件
        /// </summary>
        /// <param name="message"></param>
        public void WriteMessage(string message, string LogPath)
        {
            StreamWriter writer = null;
            try
            {
                //System.DateTime today = System.DateTime.Now.AddHours(-1);
                //string logFileName = LogPath + "\\" + today.ToString("yyyyMMdd") + ".log";
                writer = File.AppendText(LogPath);
                writer.WriteLine(message);
                writer.Close();
            }
            catch (Exception)
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        public void WriteMessage(string message, string LogPath, string FileName)
        {
            StreamWriter writer = null;
            try
            {
                System.DateTime today = System.DateTime.Now.AddHours(-1);
                string logFileName = LogPath + "\\" + FileName + ".log";
                writer = File.AppendText(logFileName);
                writer.WriteLine(message);
                writer.Close();
            }
            catch (Exception)
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }
    }
}
