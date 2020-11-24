namespace AstrologyBlog.Web.ViewModels.Articles
{
    using System.Collections.Generic;

    public class IndexArticleViewModel : PagingViewModel
    {
        public IEnumerable<ArticleViewModel> Articles { get; set; }
    }
}
