using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
