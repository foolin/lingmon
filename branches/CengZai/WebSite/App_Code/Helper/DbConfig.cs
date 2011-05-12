using System;
using System.Configuration;
namespace BLPin.Helper
{
    /// <summary>
    /// @Description: ���ݿ������ļ�
    /// @Author: Foolin
    /// @Date: 2011-05-08
    /// @Copyright 80Pin Team
    /// </summary>
    public class DbConfig
    {        
        /// <summary>
        /// ��ȡ�����ַ���
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
        /// �õ�web.config������������ݿ������ַ�����
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
