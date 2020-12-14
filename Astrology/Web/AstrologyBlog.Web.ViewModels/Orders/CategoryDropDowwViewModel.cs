namespace AstrologyBlog.Web.ViewModels.Orders
{
    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Mapping;

    public class CategoryDropDowwViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
