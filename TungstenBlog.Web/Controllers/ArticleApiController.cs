using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThugstenBlog.Service;

namespace TungstenBlog.Web.Controllers
{
    public class ArticleApiController : ApiController
    {
        [HttpGet]
        public List<DTO.ArticleDTO> Get()
        {
            var article = new ArticleService();
            
            var allArticles = article.GetTenLatestArticles();
            List<DTO.ArticleDTO> recentTenArticles = allArticles.OrderBy(x => x.PubDate)
                .Where(n => n.Categories.Contains("Friction"))
                .Take(10)
                .ToList();

            //var listOfArticles = JsonConvert.SerializeObject(recentTenArticles);
            
            return recentTenArticles;
        }
    }
}
