using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksums;

namespace Sxmobi.Tools
{
    public class FileCtrl
    {
        public FileCtrl()
        { 
        }

        /// <summary>
        /// 写入文件内容
        /// </summary>
        /// <param name="fullfilename">文件名称</param>
        /// <param name="txtcontent"> 文件内容</param>
        public static void ApendText(string fullFileName, string txtContent)
        {
            //如果文件不存在，则创建            
            if (!File.Exists(fullFileName))
            {
                FileStream fs = new FileStream(fullFileName, FileMode.CreateNew);
                fs.Close();
                fs.Dispose();
            }
            File.AppendAllText(fullFileName, txtContent);
        }

        /// <summary>
        /// Zip压缩到文件
        /// </summary>
        /// <param name="data"></param>
        /// <param name="filename">压缩源文件路径</param>
        /// <param name="folderpath">压缩目标文件路径</param>
        public static void Zip(byte[] data, string filename, string folderpath)
        {
            ZipOutputStream zos;
            Crc32 crc = new Crc32();
            zos = new ZipOutputStream(File.Create(folderpath + ".zip"));
            zos.SetLevel(6);
            ZipEntry entry = new ZipEntry(filename);
            entry.DateTime = DateTime.Now;
            entry.Size = data.Length;
            crc.Reset();
            crc.Update(data);
            entry.Crc = crc.Value;
            zos.PutNextEntry(entry);
            zos.Write(data, 0, data.Length);
            zos.Finish();
            zos.Close();
            zos.Dispose();

        }

        /// <summary>
        /// 解压文件
        /// </summary>
        /// <param name="sourceFileName">压缩文件</param>
        /// <param name="destPath">目标文件目录</param>
        public static void Unzip(string sourceFileName, string destPath,string desFileName)
        {
            ZipInputStream s = new ZipInputStream(File.OpenRead(sourceFileName));
            ZipEntry theEntry;

            while ((theEntry = s.GetNextEntry()) != null)
            {
                string fileName = desFileName;
                if (fileName != "")
                {
                    fileName = destPath + "\\" + fileName;
                    if (!Directory.Exists(destPath))
                    {
                        Directory.CreateDirectory(destPath);
                    }
                    FileStream streamWriter = File.Create(fileName);
                    int size = 2048;
                    byte[] data = new byte[2048];
                    while (true)
                    {
                        size = s.Read(data, 0, data.Length);
                        if (size > 0)
                        {
                            streamWriter.Write(data, 0, size);
                        }
                        else
                        {
                            break;
                        }
                    }
                    streamWriter.Close();
                }

            }
            s.Close();
        }
    }
}
