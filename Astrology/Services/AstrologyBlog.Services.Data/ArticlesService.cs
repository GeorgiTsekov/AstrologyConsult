namespace AstrologyBlog.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using AstrologyBlog.Data.Common.Repositories;
    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Mapping;
    using AstrologyBlog.Web.ViewModels.Articles;

    public class ArticlesService : IArticlesService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<Article> articlesRepository;

        public ArticlesService(IDeletableEntityRepository<Article> articlesRepository)
        {
            this.articlesRepository = articlesRepository;
        }

        public async Task<int> CreateAsync(CreateArticleInputModel input, string userId, string imagePath)
        {
            var article = new Article
            {
                Name = input.Name,
                Description = input.Description,
                ArticlesCategoryId = input.ArticlesCategoryId,
                CreatedByUserId = userId,
            };

            Directory.CreateDirectory($"{imagePath}/articles/");
            foreach (var image in input.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImage = new Image
                {
                    AddedByUserId = userId,
                    Extension = extension,
                };
                article.Images.Add(dbImage);

                var physicalPath = $"{imagePath}/articles/{dbImage.Id}.{extension}";
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }

            await this.articlesRepository.AddAsync(article);
            await this.articlesRepository.SaveChangesAsync();
            return article.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var article = this.articlesRepository.All().FirstOrDefault(x => x.Id == id);
            this.articlesRepository.Delete(article);
            await this.articlesRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage)
        {
            var articles = this.articlesRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();

            return articles;
        }

        public T GetById<T>(int id)
        {
            var article = this.articlesRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return article;
        }

        public int GetCount()
        {
            return this.articlesRepository.All().Count();
        }

        public async Task UpdateAsync(int id, EditArticleInputModel input)
        {
            var article = this.articlesRepository.All().FirstOrDefault(x => x.Id == id);
            article.Name = input.Name;
            article.Description = input.Description;
            article.ArticlesCategoryId = input.ArticlesCategoryId;
            await this.articlesRepository.SaveChangesAsync();
        }
    }
}
