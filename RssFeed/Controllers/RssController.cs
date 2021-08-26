using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RssFeed.BusinessLogic;
using RssFeed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RssFeed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RssController : ControllerBase
    {
        private readonly IRssCache _rssCache;

        public RssController(IRssCache rssCache)
        {
            this._rssCache = rssCache;
        }
        #region Get Data
        /// <summary>
        /// Get data & save to DB
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>

        [HttpGet]
        public CatRssViewNodel Get(string con)
        {
            return _rssCache.GetCacheRss(con);
        }
        #endregion
    }
}
