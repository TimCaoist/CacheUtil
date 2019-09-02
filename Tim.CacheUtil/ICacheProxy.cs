using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tim.CacheUtil.Models;

namespace Tim.CacheUtil
{
    public interface ICacheProxy
    {
        /// <summary>
        /// 根据配置删除缓存
        /// </summary>
        /// <param name="cacheConfig"></param>
        /// <param name="state"></param>
        void Remove(CacheConfig cacheConfig, object state = null);

        TReturnData GetAndAddData<TReturnData>(CacheConfig cacheConfig, Func<TReturnData> getData, object  state = null);

        TReturnData Get<TReturnData>(string key);

        TReturnData GetAndAddData<TReturnData>(string key, Func<TReturnData> getData);

        TReturnData GetAndAddData<TReturnData>(string key, int duration, Func<TReturnData> getData);

        TReturnData GetAndAddData<TReturnData>(string key, int duration, Func<TReturnData> getData, string[] dependKeys);
    }
}
