namespace AstrologyBlog.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using AstrologyBlog.Data.Common.Repositories;
    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Mapping;

    public class ArticlesCategoriesService : IArticlesCategoriesService
    {
        private readonly IDeletableEntityRepository<ArticlesCategory> articlesCategoriesRepository;

        public ArticlesCategoriesService(IDeletableEntityRepository<ArticlesCategory> articlesCategoriesRepository)
        {
            this.articlesCategoriesRepository = articlesCategoriesRepository;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<ArticlesCategory> query = this.articlesCategoriesRepository.All().OrderBy(x => x.Name);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }
    }
}
