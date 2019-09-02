using System;
using System.Web;
using System.Web.Caching;

namespace Tim.CacheUtil
{
    public class WebCacheProxy : BaseCacheProxy
    {
        public readonly static WebCacheProxy Instance = new WebCacheProxy();

        /// <summary>
        /// 当前页面缓存
        /// </summary>
        public static System.Web.Caching.Cache Cache
        {
            get
            {
                return HttpRuntime.Cache;
            }
        }

        /// <summary>
        /// 根据Key值删除缓存
        /// </summary>
        /// <param name="key">需要被删除的缓存Key值</param>
        protected override void RemoveCache(string key)
        {
            Cache.Remove(key);
        }

        public override TReturnData Get<TReturnData>(string key)
        {
            var result = Cache.Get(key);
            if (result == null || !(result is TReturnData))
            {
                return default(TReturnData);
            }

            return (TReturnData)result;
        }

        /// <summary>
        /// 从缓存中获取数据，如果没有则获取
        /// </summary>
        /// <typeparam name="TReturnData">返回数据类型</typeparam>
        /// <param name="key">缓存Key值</param>
        /// <param name="dependencies">缓存依赖项</param>
        /// <param name="getData">获取数据Func</param>
        /// <param name="dataCheck">检查数据Func</param>
        /// <returns>返回数据</returns>
        public override TReturnData GetAndAddData<TReturnData>(string key, int duration, Func<TReturnData> getData, string[] dependKeys)
        {
            var data = Cache.Get(key);

            if (data != null)
            {
                return (TReturnData)data;
            }

            data = getData();
            if (data is TReturnData)
            {
                CacheDependency dependencies = (dependKeys == null || dependKeys.Length == 0) ? null : new CacheDependency(null, dependKeys);
                TimeSpan timeSpan = duration != 0 ? TimeSpan.FromMinutes(duration) : Cache.NoSlidingExpiration;
                Cache.Insert(key, data, dependencies, Cache.NoAbsoluteExpiration, timeSpan);
                return (TReturnData)data;
            }

            RemoveCache(key);
            return default(TReturnData);
        }
    }
}
