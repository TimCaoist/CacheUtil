using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tim.CacheUtil.Models;

namespace Tim.CacheUtil
{
    public class DefaultCacheKeyCreator : ICacheKeyCreator
    {
        public virtual string GetKey(CacheConfig config, object state)
        {
            return BuildKey(config.KeyPrefix, config.Key);
        }

        protected string BuildKey(string prefix, string key)
        {
            return string.Concat(string.IsNullOrEmpty(prefix) ? string.Empty : prefix, key);
        }
    }
}
