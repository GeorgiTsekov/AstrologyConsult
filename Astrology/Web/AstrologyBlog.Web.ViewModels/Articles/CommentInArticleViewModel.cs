namespace AstrologyBlog.Web.ViewModels.Articles
{
    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Mapping;

    public class CommentInArticleViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string ArticleId { get; set; }

        public string CreatedByUserUserName { get; set; }

        public string Content { get; set; }
    }
}