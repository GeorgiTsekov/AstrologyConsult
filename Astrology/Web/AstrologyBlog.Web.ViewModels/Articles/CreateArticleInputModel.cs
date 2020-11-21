namespace AstrologyBlog.Web.ViewModels.Articles
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AstrologyBlog.Data.Models;

    public class CreateArticleInputModel
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        [MinLength(100)]
        public string Description { get; set; }

        // TODO imgfile
        [Required]
        public string ImageUrl { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryDropDowwViewModel> Categories { get; set; }
    }
}
