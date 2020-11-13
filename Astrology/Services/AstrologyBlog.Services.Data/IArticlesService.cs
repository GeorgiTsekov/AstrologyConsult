namespace AstrologyBlog.Services.Data
{
    using System.Threading.Tasks;

    using AstrologyBlog.Web.ViewModels.Articles;

    public interface IArticlesService
    {
        Task CreateAsync(CreateArticleInputModel input);
    }
}
