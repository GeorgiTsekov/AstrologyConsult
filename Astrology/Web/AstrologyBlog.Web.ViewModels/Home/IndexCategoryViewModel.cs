namespace AstrologyBlog.Web.ViewModels.Home
{
    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Mapping;

    public class IndexCategoryViewModel : IMapFrom<Category>
    {
        public string Title { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Url => $"/f/{this.Name.Replace(' ', '-')}";
    }
}