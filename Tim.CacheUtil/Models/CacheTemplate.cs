using System.Runtime.Serialization;

namespace Tim.CacheUtil.Models
{
    [DataContract]
    public class CacheTemplate : BaseCacheConfig
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// 依赖Key
        /// </summary>
        [DataMember(Name = "depend_key")]
        public string DependencyKey { get; set; }
    }
}
