using System;
using Tim.CacheUtil.Models;

namespace Tim.CacheUtil
{
    public abstract class BaseCacheProxy : ICacheProxy
    {
        public abstract TReturnData Get<TReturnData>(string key);

        public TReturnData GetAndAddData<TReturnData>(CacheConfig cacheConfig, Func<TReturnData> getData, object state = null)
        {
            CacheUtil.MegreConfig(cacheConfig);
            var key = CacheUtil.GetName(cacheConfig, state);
            return GetAndAddData(key, cacheConfig.Duration.GetValueOrDefault(), getData, cacheConfig.DependencyKeys);
        }

        public void Remove(CacheConfig cacheConfig, object state = null)
        {
            CacheUtil.MegreConfig(cacheConfig);
            var key = CacheUtil.GetName(cacheConfig, state);
            RemoveCache(key);
        }

        protected abstract void RemoveCache(string key);

        public TReturnData GetAndAddData<TReturnData>(string key, Func<TReturnData> getData)
        {
            return GetAndAddData<TReturnData>(key, 0, getData);
        }

        public TReturnData GetAndAddData<TReturnData>(string key, int duration, Func<TReturnData> getData)
        {
            return GetAndAddData<TReturnData>(key, duration, getData, null);
        }

        public abstract TReturnData GetAndAddData<TReturnData>(string key, int duration, Func<TReturnData> getData, string[] dependKeys);
    }
}
