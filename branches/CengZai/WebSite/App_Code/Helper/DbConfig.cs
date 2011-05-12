using System;
using System.Configuration;
namespace BLPin.Helper
{
    /// <summary>
    /// @Description: 数据库配置文件
    /// @Author: Foolin
    /// @Date: 2011-05-08
    /// @Copyright 80Pin Team
    /// </summary>
    public class DbConfig
    {        
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {           
            get 
            {
                string _connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                string _isEncrypt = ConfigurationManager.AppSettings["ConnStringEncrypt"];
                if (_isEncrypt == "true" || _isEncrypt == "1")
                {
                    _connectionString = DESEncrypt.Decrypt(_connectionString);
                }
                return _connectionString; 
            }
        }

        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            string _connectionString = ConfigurationManager.AppSettings[configName];
            string _isEncrypt = ConfigurationManager.AppSettings["ConnStringEncrypt"];
            if (_isEncrypt == "true" || _isEncrypt == "1")
            {
                _connectionString = DESEncrypt.Decrypt(_connectionString);
            }
            return _connectionString;
        }


    }
}
