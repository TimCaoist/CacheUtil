using System.Runtime.Serialization;

namespace Tim.CacheUtil.Models
{
    [DataContract]
    public class CacheConfig : BaseCacheConfig
    {
        /// <summary>
        /// 使用的模板名称
        /// </summary>
        [DataMember(Name = "template")]
        public string Template { get; set; }

        /// <summary>
        /// Key
        /// </summary>
        [DataMember(Name = "key")]
        public string Key { get; set; }

        /// <summary>
        /// 其他需要的信息
        /// </summary>

        [DataMember(Name = "data")]
        public string Data { get; set; }
    }
}
