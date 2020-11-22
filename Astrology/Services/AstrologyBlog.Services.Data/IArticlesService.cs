namespace AstrologyBlog.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArticlesService
    {
        Task<int> CreateAsync(string name, string description, string imageUrl, int articleCategoryId, string userId);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12);
    }
}
