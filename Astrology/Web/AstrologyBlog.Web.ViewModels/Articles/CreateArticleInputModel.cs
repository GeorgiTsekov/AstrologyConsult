using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AstrologyBlog.Web.ViewModels.Articles
{
    public class CreateArticleInputModel
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        [MinLength(100)]
        public string Description { get; set; }

        // TODO imgfile
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }
    }
}
