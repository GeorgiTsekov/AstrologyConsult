namespace AstrologyBlog.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AstrologyBlog.Data.Models;
    using Microsoft.EntityFrameworkCore.Internal;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category { Name = "Натална астрология" });
            await dbContext.Categories.AddAsync(new Category { Name = "Прогностика- транзити, прогресии, слънчеви дирекции и слънчево възвръщане" });
            await dbContext.Categories.AddAsync(new Category { Name = "Синастрия" });
            await dbContext.Categories.AddAsync(new Category { Name = "Хорарна и елективна астрология" });
            await dbContext.Categories.AddAsync(new Category { Name = "Кармична астрология" });
            await dbContext.Categories.AddAsync(new Category { Name = "Новолуния, пълнолуния и моменти" });
            await dbContext.Categories.AddAsync(new Category { Name = "Астро прогнози" });
            await dbContext.Categories.AddAsync(new Category { Name = "Философски и духовни статии" });

            await dbContext.SaveChangesAsync();
        }
    }
}
