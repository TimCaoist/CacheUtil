using System.Runtime.Serialization;

namespace Tim.CacheUtil.Models
{
    [DataContract]
    public class BaseCacheConfig
    {
        /// <summary>
        /// 每次访问缓存，延期时间, 如果为null或者0则永不过期
        /// </summary>

        [DataMember(Name = "duration")]
        public int? Duration { get; set; }

        /// <summary>
        /// Key的前缀
        /// </summary>
        [DataMember(Name = "prefix")]
        public string KeyPrefix { get; set; }

        /// <summary>
        /// 依赖Keys
        /// </summary>
        [DataMember(Name = "depend_keys")]
        public string[] DependencyKeys { get; set; }
    }
}
