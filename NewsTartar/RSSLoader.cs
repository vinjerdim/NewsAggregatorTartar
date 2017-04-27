using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using HtmlAgilityPack;

namespace NewsTartar
{
    public class RSSLoader
    {
        public static List<Feeds> loadFeedList(int newsSource)
        {
            string rssURL;
            string htmlElement;
            switch (newsSource)
            {
                case 1: rssURL = "http://www.antaranews.com/rss/terkini"; htmlElement = "//div[@id='content_news']"; break;
                case 2: rssURL = "http://rss.detik.com/index.php/detikcom"; htmlElement = "//div[@id='detikdetailtext']"; break;
                case 3: rssURL = "http://rss.vivanews.com/get/all"; htmlElement = "//span[@itemprop='description']"; break;
                default: rssURL = ""; htmlElement = ""; break;
            }
            List<Feeds> result = new List<Feeds>();
            XDocument doc = new XDocument();
            doc = XDocument.Load(rssURL);
            var items = (from x in doc.Descendants("item")
                                select new
                                {
                                title = x.Element("title").Value,
                                link = x.Element("link").Value,
                                description = x.Element("description").Value,
                                publishDate = x.Element("pubDate").Value
                                });
            if (items != null)
            {
                foreach (var i in items)
                {
                    string content = getHTMLContent(i.link, htmlElement);
                    if (!content.Equals(""))
                    {
                        Feeds temp = new Feeds
                        {
                            Title = i.title,
                            Link = i.link,
                            PublishDate = i.publishDate,
                            Description = i.description,
                            Content = content
                        };
                        result.Add(temp);
                    }
                }
            }
            return result;
        }

        public static List<Feeds> getSearchResult(List<Feeds> feeds, string keyword, int algorithm)
        {
            List<Feeds> result = new List<Feeds>();
            Feeds temp;
            int idxTitle;
            int idxContent;
            foreach (var i in feeds)
            {
                switch (algorithm)
                {
                    case 1:
                        idxTitle = StringMatcher.KMPMatch(i.Title, keyword);
                        idxContent = StringMatcher.KMPMatch(i.Content, keyword);
                        if (idxTitle != -1)
                        {
                            temp = new Feeds
                            {
                                Title = i.Title,
                                Link = i.Link,
                                PublishDate = i.PublishDate,
                                Description = i.Description,
                                Content = ""
                            };                         
                            result.Add(temp);
                        }
                        break;
                    case 2:
                        idxTitle = StringMatcher.BMMatch(i.Title, keyword);
                        idxContent = StringMatcher.BMMatch(i.Content, keyword);
                        if (idxTitle != -1)
                        {
                            temp = new Feeds
                            {
                                Title = i.Title,
                                Link = i.Link,
                                PublishDate = i.PublishDate,
                                Description = i.Description,
                                Content = ""
                            };                          
                            result.Add(temp);
                        }
                        break;
                    default:
                        break;
                }
            }
            return result;
        }

        public static string getHTMLContent(string url, string element)
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);

            HtmlNode node = doc.DocumentNode.SelectSingleNode(element);
            return (node != null) ? node.InnerText : "";
        }

        public static string limitString(string content, int idx)
        {
            int i = idx;
            int j = idx;
            int count = 0;
            while (count < 100)
            {
                if (j + 1 < content.Length)
                {
                    j++;
                    count++;
                }
                if (i - 1 >= 0)
                {
                    i--;
                    count++;
                }
            }
            string result = content.Substring(i, 100);
            return result;
        }
    }
}