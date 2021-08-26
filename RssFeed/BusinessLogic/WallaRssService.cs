using Nancy.Json;
using Newtonsoft.Json;
using RssFeed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace RssFeed.BusinessLogic
{
    public class WallaRssService
    {
        #region GetRSS
        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public CatRssViewNodel GetData(string category)
        {
            string ApiUrl = $"https://rss.walla.co.il/feed/{category}";
            List<RssViewModel> listRSS = new List<RssViewModel>();
            CatRssViewNodel catRssViewNodel = new CatRssViewNodel();
            try
            {
                XmlDocument doc = new XmlDocument();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                doc.Load(ApiUrl);
                //XmlNode node = doc.DocumentElement.SelectSingleNode(@"/rss/channel");
                var jsonText = JsonConvert.SerializeXmlNode(doc);

                dynamic jsonObject = serializer.Deserialize<dynamic>(jsonText);
                
                dynamic title = jsonObject["rss"]["channel"]["title"];
                dynamic listItems = jsonObject["rss"]["channel"]["item"];


                for (int i = 0; i < listItems.Count; i++)
                {
                    listRSS.Add(
                        new RssViewModel
                        {
                            Description = Convert.ToString(listItems[i].Description),
                            Title = Convert.ToString(listItems[i].Title),
                            PubDate = listItems[i].pubDate
                        });
                }
                catRssViewNodel.NameList = title.ToString();
                catRssViewNodel.List = listRSS;
            }
            catch (Exception ex)
            {
                listRSS.Add(new RssViewModel { Title = "ERR", Description = ex.Message, PubDate = DateTime.Now.ToString() });
            }
            return catRssViewNodel;
        }
        #endregion

    }

}
