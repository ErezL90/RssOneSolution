using RssFeed.Models;

namespace RssFeed.BusinessLogic
{
    public interface IRssCache
    {
        void AddToCache(string key, CatRssViewNodel catRss);
        CatRssViewNodel GetCacheRss(string key);
    }
}