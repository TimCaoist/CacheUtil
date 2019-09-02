using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Tim.CacheUtil.Models
{
    [DataContract]
    public class CacheCommonConfig : BaseCacheConfig
    {
        [DataMember(Name = "templates")]
        public IEnumerable<CacheTemplate> Tempaltes { get; set; }

        [DataMember(Name = "type")]
        public CacheProxyType ProxyType { get; set; }
    }
}
