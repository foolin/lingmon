using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Utility.Array
{
    /// <summary>
    /// List<T>泛型序列化类
    /// @Author: Foolin
    /// @Create Date: 2010-10-19
    /// </summary>
    public class ListSerializer
    {

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="list">列表</param>
        /// <returns>xml内容</returns>
        public static string Serialize<T>(List<T> list)
        {
            try
            {
                string strReturn = string.Empty;    //返回结果
                System.IO.MemoryStream ms = new System.IO.MemoryStream();   //流对象
                XmlSerializer ser = new XmlSerializer(typeof(List<T>));  //序列化对象
                //序列化
                ser.Serialize(ms, list);
                //取序列化字符串
                strReturn = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                //关闭流
                ms.Close();
                //返回
                return strReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="xml">xml内容</param>
        /// <returns>反序列化列表</returns>
        public static List<T> Deserialize<T>(string xml)
        {
            try
            {
                //将xml转为流
                System.IO.MemoryStream ms = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(xml));
                //序列化对象
                XmlSerializer ser = new XmlSerializer(typeof(List<T>));
                //反序列化
                List<T> serList = (List<T>)ser.Deserialize(ms);
                //关闭流
                ms.Close();
                //返回结果
                return serList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #region Xml文件的序列化与反序列化 
        /// <summary> 
        /// Xml文件反序列化（将xml文件读取到List中） 
        /// </summary> 
        /// <typeparam name="T">参数类型</typeparam> 
        /// <param name="XmlFilePath">Xml文件的路径</param> 
        public static List<T> Deserial<T>(String XmlFilePath) 
        { 
            try 
            { 
                List<T> list = null; 
                XmlSerializer xs = new XmlSerializer(typeof(List<T>)); 
                XmlReader xr = new XmlTextReader(XmlFilePath); 
                list = (List<T>)xs.Deserialize(xr); 
                xr.Close(); 
                return list; 
            } 
            catch (Exception ex) 
            { 
                throw ex; 
            } 
        } 

        /// <summary> 
        /// Xml序列化（将List保存成xml文件） 
        /// </summary> 
        /// <typeparam name="T">对象类型</typeparam> 
        /// <param name="list">List</param> 
        /// <param name="XmlFilePath">xml文件路径</param> 
        public static void Serial<T>(List<T> list, String XmlFilePath) 
        { 
            try 
            { 
                XmlSerializer xs = new XmlSerializer(typeof(List<T>)); 
                XmlWriter xw = new XmlTextWriter(XmlFilePath, Encoding.UTF8); 
                XmlSerializerNamespaces xsn = new XmlSerializerNamespaces(); 
                xsn.Add(String.Empty, String.Empty); 
                xs.Serialize(xw, list, xsn); 
                xw.Close(); 
            } 
            catch (Exception ex) 
            { 
                throw ex; 
            } 
        } 
        /// <summary> 
        /// Xml序列化（将List保存成xml文件） 
        /// </summary> 
        /// <typeparam name="T">对象类型</typeparam> 
        /// <param name="list">List</param> 
        /// <returns>返回包含xml文件标签的字符串（xml文件的所有内容）</returns> 
        public static String Serial<T>(List<T> list) 
        { 
            try 
            { 
                XmlSerializer xs = new XmlSerializer(typeof(List<T>)); 
                TextWriter tw = new StringWriter(); 
                XmlWriter xw = new XmlTextWriter(tw); 
                XmlSerializerNamespaces xsn = new XmlSerializerNamespaces(); 
                xsn.Add(String.Empty, String.Empty); 
                xs.Serialize(xw, list, xsn); 
                String s = tw.ToString(); 
                xw.Close(); 
                tw.Close(); 
                return s; 
            } 
            catch (Exception ex) 
            { 
                throw ex; 
            } 
        } 
        #endregion

    }
}
