using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tim.CacheUtil.Models;

namespace Tim.CacheUtil
{
    public static class CacheUtil
    {
        private static CacheCommonConfig commConfig = new CacheCommonConfig {  Duration = 20, Tempaltes = Enumerable.Empty<CacheTemplate>()};

        private static ICacheKeyCreator cacheKeyCreator = new DefaultCacheKeyCreator();

        public static void ApplyConfig(CacheCommonConfig config)
        {
            commConfig = config;
        }

        public static void UseCacheKeyCreator(ICacheKeyCreator creator)
        {
            cacheKeyCreator = creator;
        }

        public static string GetName(CacheConfig cacheConfig, object state)
        {
            return cacheKeyCreator.GetKey(cacheConfig, state);
        }

        public static void MegreConfig(CacheConfig cacheConfig)
        {
            var tempalte = string.IsNullOrEmpty(cacheConfig.Template) ? null :commConfig.Tempaltes.FirstOrDefault(t => t.Name == cacheConfig.Template);
            ICollection<BaseCacheConfig> baseCacheConfigs = new List<BaseCacheConfig>();
            if (tempalte != null)
            {
                baseCacheConfigs.Add(tempalte);
            }

            baseCacheConfigs.Add(commConfig);
            SetConfig(cacheConfig, baseCacheConfigs);
        }

        private static void SetConfig(BaseCacheConfig config, IEnumerable<BaseCacheConfig> cacheConfigs)
        {
            if (!config.Duration.HasValue)
            {
                foreach (var item in cacheConfigs)
                {
                    config.Duration = item.Duration;
                    if (config.Duration.HasValue)
                    {
                        break;
                    }
                }
            }

            if (string.IsNullOrEmpty(config.KeyPrefix))
            {
                foreach (var item in cacheConfigs)
                {
                    config.KeyPrefix = item.KeyPrefix;
                    if (!string.IsNullOrEmpty(config.KeyPrefix))
                    {
                        break;
                    }
                }
            }

            if (config.DependencyKeys == null)
            {
                foreach (var item in cacheConfigs)
                {
                    config.DependencyKeys = item.DependencyKeys;
                    if (config.DependencyKeys != null)
                    {
                        break;
                    }
                }
            }
        }

        public static ICacheProxy Create()
        {
            if (commConfig == null)
            {
                throw new ArgumentNullException("Config");
            }

            return new WebCacheProxy();
        }
    }
}
