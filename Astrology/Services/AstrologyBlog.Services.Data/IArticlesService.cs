namespace AstrologyBlog.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AstrologyBlog.Web.ViewModels.Articles;

    public interface IArticlesService
    {
        Task<int> CreateAsync(CreateArticleInputModel input, string userId, string imagePath);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 10);

        int GetCount();

        T GetById<T>(int id);
    }
}
