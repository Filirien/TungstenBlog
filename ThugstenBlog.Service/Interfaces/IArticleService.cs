using System.Collections.Generic;
using TungstenBlog.DTO;

namespace ThugstenBlog.Service.Interfaces
{
    public interface IArticleService
    {
        List<ArticleDTO> GetTenLatestArticles();
    }
}
