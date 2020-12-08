namespace AstrologyBlog.Web.ViewModels.Articles
{
    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Mapping;

    public class EditArticleInputModel : BaseArticleInputModel, IMapFrom<Article>
    {
        public int Id { get; set; }
    }
}
