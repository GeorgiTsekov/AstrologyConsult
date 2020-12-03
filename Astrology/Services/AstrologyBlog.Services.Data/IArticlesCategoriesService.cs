namespace AstrologyBlog.Services.Data
{
    using System.Collections.Generic;

    public interface IArticlesCategoriesService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        T GetByName<T>(string name);
    }
}
