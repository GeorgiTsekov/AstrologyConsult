namespace AstrologyBlog.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AstrologyBlog.Data.Common.Repositories;
    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Mapping;

    public class ArticlesService : IArticlesService
    {
        private readonly IDeletableEntityRepository<Article> articlesRepository;

        public ArticlesService(IDeletableEntityRepository<Article> articlesRepository)
        {
            this.articlesRepository = articlesRepository;
        }

        public async Task<int> CreateAsync(string name, string description, string imageUrl, int articlesCategoryId, string userId)
        {
            var article = new Article
            {
                Name = name,
                Description = description,
                ImageUrl = imageUrl,
                ArticlesCategoryId = articlesCategoryId,
                CreatedByUserId = userId,
            };

            await this.articlesRepository.AddAsync(article);
            await this.articlesRepository.SaveChangesAsync();
            return article.Id;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Article> query = this.articlesRepository.All().OrderBy(x => x.Name);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }
    }
}
