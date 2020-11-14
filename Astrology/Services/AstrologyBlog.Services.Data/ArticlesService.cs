namespace AstrologyBlog.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AstrologyBlog.Data.Common.Repositories;
    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Mapping;
    using AstrologyBlog.Web.ViewModels.Articles;

    public class ArticlesService : IArticlesService
    {
        private readonly IDeletableEntityRepository<Article> articlesRepository;

        public ArticlesService(IDeletableEntityRepository<Article> articlesRepository)
        {
            this.articlesRepository = articlesRepository;
        }

        public async Task CreateAsync(CreateArticleInputModel input)
        {
            var article = new Article
            {
                CategoryId = input.CategoryId,
                Name = input.Name,
                Description = input.Description,
                ImageUrl = input.ImageUrl,
                Comments = input.Comments,
            };

            await this.articlesRepository.AddAsync(article);
            await this.articlesRepository.SaveChangesAsync();
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
