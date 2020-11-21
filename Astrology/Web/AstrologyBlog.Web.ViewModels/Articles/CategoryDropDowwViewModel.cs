using AstrologyBlog.Data.Models;
using AstrologyBlog.Services.Mapping;

namespace AstrologyBlog.Web.ViewModels.Articles
{
    public class CategoryDropDowwViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}