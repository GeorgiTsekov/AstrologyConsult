namespace AstrologyBlog.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AstrologyBlog.Data.Models;
    using Microsoft.EntityFrameworkCore.Internal;

    public class ArticlesCategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ArticlesCategories.Any())
            {
                return;
            }

            await dbContext.ArticlesCategories.AddAsync(new ArticlesCategory { Name = "Рожден хороскоп" });
            await dbContext.ArticlesCategories.AddAsync(new ArticlesCategory { Name = "Бъдещи събития" });
            await dbContext.ArticlesCategories.AddAsync(new ArticlesCategory { Name = "Връзки, партньорства" });
            await dbContext.ArticlesCategories.AddAsync(new ArticlesCategory { Name = "Кармични уроци" });
            await dbContext.ArticlesCategories.AddAsync(new ArticlesCategory { Name = "Планиране според фазите на луната" });
            await dbContext.ArticlesCategories.AddAsync(new ArticlesCategory { Name = "Бизнес хороскоп" });
            await dbContext.ArticlesCategories.AddAsync(new ArticlesCategory { Name = "Философски и духовни статии" });
            await dbContext.ArticlesCategories.AddAsync(new ArticlesCategory { Name = "Други статии" });
        }
    }
}
