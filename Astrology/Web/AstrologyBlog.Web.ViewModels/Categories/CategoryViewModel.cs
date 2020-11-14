namespace AstrologyBlog.Web.ViewModels.Categories
{
    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
