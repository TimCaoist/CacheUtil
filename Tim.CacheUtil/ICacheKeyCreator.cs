using Tim.CacheUtil.Models;

namespace Tim.CacheUtil
{
    /// <summary>
    /// Key名字生产器
    /// </summary>
    public interface ICacheKeyCreator
    {
        string GetKey(CacheConfig config, object state);
    }
}
