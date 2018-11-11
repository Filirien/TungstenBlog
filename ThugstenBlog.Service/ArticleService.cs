using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;
using TungstenBlog.DTO;
using System.Linq;
using System.Globalization;
using ThugstenBlog.Service.Interfaces;

namespace ThugstenBlog.Service
{
    public class ArticleService : IArticleService
    {
        public List<ArticleDTO> GetTenLatestArticles()
        {
            var URLString = "https://www.tungsten-network.com/rss-resource-library/";
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(URLString);

            var nodes = myXmlDocument.DocumentElement.GetElementsByTagName("item");
            var articles = new List<ArticleDTO>();
            foreach (XmlNode node in nodes)
            {
                var title = node["title"].InnerText;
                var guid = node["guid"].InnerText;
                var pubDate = node["pubDate"].InnerText;
                var creator = node["dc:creator"].InnerText;
                XmlNodeList categories = node.SelectNodes("category");
                var element = node["enclosure"];


                var length = int.Parse(element.GetAttribute("length"));
                var url = (string)element.GetAttribute("url");
                var type = (string)element.GetAttribute("type");

                var enclosure = new EnclosureDTO()
                {
                    Length = length,
                    Url = url,
                    Type = type
                };


                var listOfCategories = new List<string>();

                foreach (var category in categories)
                {
                    listOfCategories.Add((category as XmlNode).InnerText);
                }

                var description = node["description"].InnerText;

                var article = new ArticleDTO()
                {
                    Title = title,
                    Guid = guid,
                    PubDate = pubDate,
                    Creator = creator,
                    Categories = listOfCategories,
                    Description = description,
                    Enclosure = enclosure
                };
                articles.Add(article);
            }

            return articles;
        }
    }
}
