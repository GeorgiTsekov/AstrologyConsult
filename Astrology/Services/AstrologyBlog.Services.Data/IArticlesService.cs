namespace AstrologyBlog.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AstrologyBlog.Web.ViewModels.Articles;

    public interface IArticlesService
    {
        Task CreateAsync(CreateArticleInputModel input);

        IEnumerable<T> GetAll<T>(int? count = null);
    }
}
