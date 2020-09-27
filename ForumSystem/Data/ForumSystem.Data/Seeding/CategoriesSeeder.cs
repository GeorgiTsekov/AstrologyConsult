namespace ForumSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categories = new List<string> { "Sport", "Coronavirus", "News", "Music", "Programming", "Cats", "Dogs" };

            foreach (var category in categories)
            {
                await dbContext.Categories.AddAsync(new Models.Category
                {
                    Name = category,
                    Description = category,
                    Title = category,
                });
            }
        }
    }
}
