using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThugstenBlog.Service;
using TungstenBlog.DTO;

namespace TungstenBlog.Web.Controllers
{
    public class ArticleController : Controller
    {
        public ActionResult Index()
        {
            var article = new ArticleService();

            
            var allArticles = article.GetTenLatestArticles();
            var recentTenArticles = allArticles.OrderBy(x => x.PubDate)
                .Where(n => n.Categories.Contains("Friction"))
                .Take(10)
                .ToList();
            return View(recentTenArticles);
        }
        
        public ActionResult ShowArticle(List<ArticleDTO> articles)
        {
            return PartialView("_ArticleListingForm");

        }
    }
}
