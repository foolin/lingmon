using System;
using System.Web;
using Sxmobi.Utility.IO;


namespace Sxmobi.Utility.Web
{
    /// <summary>
    /// DataCache 缓存类
    /// Author: 刘付灵(Foolin)
    /// Created: 2010-09-16
    /// </summary>
    public class WebCache
    {
        public WebCache()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        private static string Prefix = "LFL_";    //缓存前缀

        /// <summary>
        /// 设置缓存，默认永久缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存值</param>
        /// <returns>返回布尔值</returns>
        public static bool SetCache(string key, object value)
        {
            return SetCache(Prefix, key, value);
        }

        /// <summary>
        /// 设置缓存，默认永久缓存
        /// </summary>
        /// <param name="prefix">前缀</param>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存值</param>
        /// <returns>返回布尔值</returns>
        public static bool SetCache(string prefix, string key, object value)
        {
            bool blReturn = false;
            if (string.IsNullOrEmpty(prefix))
            {
                prefix = Prefix;
            }
            if (value != null)
            {
                try
                {
                    HttpRuntime.Cache.Insert(prefix + key, value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration);
                    blReturn = true;
                }
                catch
                {
                    blReturn = false;
                    throw;
                }
            }
            return blReturn;
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存值</param>
        /// <param name="hours">时</param>
        /// <param name="minutes">分</param>
        /// <param name="seconds">秒</param>
        /// <returns>返回布尔值</returns>
        public static bool SetCache(string key, object value, int hours, int minutes, int seconds)
        {
            return SetCache(Prefix, key, value, hours, minutes, seconds);
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="prefix">前缀</param>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存值</param>
        /// <param name="hours">时</param>
        /// <param name="minutes">分</param>
        /// <param name="seconds">秒</param>
        /// <returns>返回布尔值</returns>
        public static bool SetCache(string prefix ,string key, object value, int hours, int minutes, int seconds)
        {
            bool blReturn = false;
            if (string.IsNullOrEmpty(prefix))
            {
                prefix = Prefix;
            }
            if (value != null)
            {
                try
                {
                    HttpRuntime.Cache.Insert(prefix + key, value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(hours, minutes, seconds));
                    blReturn = true;
                }
                catch
                {
                    blReturn = false;
                    throw;
                    //Log.WriteMessage("写入缓存[" + prefix + key + "]失败：" + ex.Message);
                }
            }
            return blReturn;
        }


        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns>返回对象</returns>
        public static object GetCache(string key)
        {
            return GetCache(Prefix, key);
        }


        /// <summary>
        ///  获取缓存
        /// </summary>
        /// <param name="prefix">前缀</param>
        /// <param name="key">缓存Key</param>
        /// <returns>返回对象</returns>
        public static object GetCache(string prefix, string key)
        {
            object objReturn = null;
            if (string.IsNullOrEmpty(prefix))
            {
                prefix = Prefix;
            }
            if (HttpRuntime.Cache[prefix + key] != null)
            {
                objReturn = HttpRuntime.Cache[prefix + key];
            }
            return objReturn;
        }

        /// <summary>
        /// 清除缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns>返回布尔值：1=成功，0=失败</returns>
        public static bool ClearCache(string key)
        {
            return ClearCache(Prefix, key);
        }

        /// <summary>
        /// 清除缓存
        /// </summary>
        /// <param name="prefix">前缀</param>
        /// <param name="key">缓存Key</param>
        /// <returns>返回布尔值：1=成功，0=失败</returns>
        public static bool ClearCache(string prefix, string key)
        {
            bool blReturn = false;
            if (string.IsNullOrEmpty(prefix))
            {
                prefix = Prefix;
            }
            try
            {
                HttpRuntime.Cache.Remove(prefix + key);
                blReturn = true;
            }
            catch
            {
                blReturn = false;
                throw;
                //Log.WriteMessage("清除缓存[" + prefix + key + "]失败：" + ex.Message);
            }
            return blReturn;
        }

        /// <summary>
        /// 判断是否存在缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsExist(string key)
        {
            return IsExist(Prefix, key);
        }

        /// <summary>
        /// 判断是否存在缓存
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsExist(string prefix, string key)
        {
            return HttpRuntime.Cache[prefix + key] != null;
        }

    }
}
