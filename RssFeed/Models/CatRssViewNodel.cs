using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RssFeed.Models
{
    public class CatRssViewNodel
    {
        public string NameList { get; set; }
        public List<RssViewModel> List { get; set; }
    }
}
