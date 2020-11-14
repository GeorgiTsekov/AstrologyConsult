namespace AstrologyBlog.Web.ViewModels.Articles
{
    using System.Collections.Generic;

    public class IndexArticleViewModel
    {
        public IEnumerable<ArticleViewModel> Articles { get; set; }
    }
}
