using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Memcached.ClientLibrary;
using System.Collections;

namespace Sxmobi.Utility.Web
{

    /// <summary>
    ///MemCached缓存类
    /// </summary>
    public class MemCachedOp<T> where T : Sxmobi.Utility.IO.ILog, new()
    {
        private string[] _serverlist = null;
        private SockIOPool _pool = null;
        private MemcachedClient _mc = null;
        T log = new T();

        /// <summary>
        /// 实体构造函数
        /// </summary>
        public MemCachedOp(string serverList)
        {
            if (!string.IsNullOrEmpty(serverList))
            {
                _serverlist = serverList.Split(new char[] { ',' });
            }
            InitializePool();
            InitializeClient();
        }

        public MemCachedOp()
            : this(string.Empty)
        {

        }

        private void InitializePool()
        {
            try
            {
                SockIOPool pool = SockIOPool.GetInstance();
                pool.SetServers(_serverlist);

                pool.InitConnections = 3;
                pool.MinConnections = 3;
                pool.MaxConnections = 5;

                pool.SocketConnectTimeout = 1000;
                pool.SocketTimeout = 3000;

                pool.MaintenanceSleep = 30;
                pool.Failover = true;

                pool.Nagle = false;
                pool.Initialize();
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.Message);
                throw ex;
            }
        }

        private void InitializeClient()
        {
            _mc = new MemcachedClient();
            _mc.EnableCompression = false;
        }

        public MemcachedClient Mc
        {
            get { return _mc; }
            set { _mc = value; }
        }

        public string[] Serverlist
        {
            get { return _serverlist; }
            set { _serverlist = value; }
        }

        #region 获取缓存数据
        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object GetCachedValue(string key)
        {
            if (key != null)
            {
                return GetValue(key, 0, null);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object GetCachedValue(string key, int hashCode)
        {
            if (key != null)
            {
                return GetValue(key, hashCode, null);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取缓存数据
        /// </summary>
        public object GetCachedValue(string key, int hashCode, bool? asString)
        {
            if (key != null)
            {
                return GetValue(key, hashCode, asString);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取缓存值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashCode"></param>
        /// <param name="asString"></param>
        /// <returns></returns>
        private object GetValue(string key, int hashCode, bool? asString)
        {
            try
            {
                if (!string.IsNullOrEmpty(key) && hashCode != 0 && asString != null)
                {
                    return _mc.Get(key, hashCode, asString.Value);
                }
                else if (!string.IsNullOrEmpty(key) && hashCode != 0)
                {
                    return _mc.Get(key, hashCode);
                }
                else if (!string.IsNullOrEmpty(key))
                {
                    return _mc.Get(key);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.Message);
                return null;
            }
        }
        #endregion

        #region 插入缓存
        /// <summary>
        /// 插入记录到缓存，如果该键已存在，则更新
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>0正常 -1键或值为null -2插入出现异常 </returns>
        public int InsertCachedValue(string key, object value)
        {
            if (key != null && value != null)
            {
                try
                {
                    _mc.Set(key, value);
                    return 0;
                }
                catch (Exception ex)
                {
                    log.WriteLog(ex.Message);
                    return -2;
                }
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 插入记录到缓存，如果该键已存在，则更新
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>0正常 -1键或值为null -2插入出现异常 </returns>
        public int InsertCachedValue(string key, object value, DateTime expiry)
        {
            if (key != null && value != null)
            {
                try
                {
                    _mc.Set(key, value, expiry);
                    return 0;
                }
                catch (Exception ex)
                {
                    log.WriteLog(ex.Message);
                    return -2;
                }
            }
            else
            {
                return -1;
            }
        }
        #endregion

        #region 删除缓存
        /// <summary>
        /// 从缓存中删除记录
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value">0正常 -1键或值为null -2插入出现异常</param>
        public int DeleteCachedValue(string key)
        {
            if (key != null)
            {
                try
                {
                    _mc.Delete(key);
                    return 0;
                }
                catch (Exception ex)
                {
                    log.WriteLog(ex.Message);
                    return -2;
                }
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 从缓存中删除记录
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value">0正常 -1键或值为null -2插入出现异常</param>
        public int DeleteCachedValue(string key, DateTime expiry)
        {
            if (key != null)
            {
                try
                {
                    _mc.Delete(key, expiry);
                    return 0;
                }
                catch (Exception ex)
                {
                    log.WriteLog(ex.Message);
                    return -2;
                }
            }
            else
            {
                return -1;
            }
        }
        #endregion

        /// <summary>
        /// 是否存在某个对应键的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsKeyExist(string key)
        {
            try
            {
                if (_mc.KeyExists(key))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 清空所有数据
        /// </summary>
        /// <returns></returns>
        public bool DeleteAll()
        {
            try
            {
                _mc.FlushAll();
                return true;
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 清空指定服务器的所有数据
        /// </summary>
        /// <returns></returns>
        public bool DeleteAll(ArrayList serverList)
        {
            try
            {
                _mc.FlushAll(serverList);
                return true;
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 注销资源
        /// </summary>
        public void Dispose()
        {
            try
            {
                if (_pool != null)
                    _pool.Shutdown();
                if (_mc != null)
                    _mc = null;
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.Message);
            }
        }

        /// <summary>
        /// 打印命中率
        /// </summary>
        /// <returns>返回值为百分比，比如是51.2 就表示命中率是51.2%</returns>
        public Dictionary<string, double> GetHits()
        {
            Dictionary<string, double> serverHits = new Dictionary<string, double>();
            try
            {
                IDictionary stats = _mc.Stats();
                foreach (string key1 in stats.Keys)
                {
                    Hashtable values = (Hashtable)stats[key1];
                    double getAll = 0;
                    double getHit = 0;
                    foreach (string key2 in values.Keys)
                    {
                        if (key2 == "cmd_get")
                        {
                            getAll = double.Parse(values[key2].ToString());
                        }
                        else if (key2 == "get_hits")
                        {
                            getHit = double.Parse(values[key2].ToString());
                        }
                    }
                    if (getAll > 0)
                    {
                        serverHits.Add(key1, Math.Round((getHit / getAll) * 100, 2));
                    }
                    else
                    {
                        serverHits.Add(key1, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.Message);
            }
            return serverHits;
        }
    }


}
