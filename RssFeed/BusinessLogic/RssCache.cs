using Microsoft.Extensions.Caching.Memory;
using RssFeed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RssFeed.BusinessLogic
{
    public class RssCache : IRssCache
    {
        private readonly IMemoryCache _memoryCache;
        WallaRssService wallaRss = new WallaRssService();

        public RssCache(IMemoryCache memoryCache)
        {
            this._memoryCache = memoryCache;
        }

        public void AddToCache(string key, CatRssViewNodel catRss)
        {
            var options = new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromSeconds(30),
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(90)
            };

            _memoryCache.Set<CatRssViewNodel>(key, catRss, options);
        }

        public CatRssViewNodel GetCacheRss(string key)
        {
            CatRssViewNodel catRss;
            if (!_memoryCache.TryGetValue(key, out catRss))
            {
                catRss = wallaRss.GetData(key);
                AddToCache(key, catRss);
            }
            return catRss;
        }
    }
}
