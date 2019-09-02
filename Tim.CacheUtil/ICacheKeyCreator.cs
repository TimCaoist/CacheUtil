using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tim.CacheUtil.Models;

namespace Tim.CacheUtil
{
    public interface ICacheKeyCreator
    {
        string GetKey(CacheConfig config, object state);
    }
}
