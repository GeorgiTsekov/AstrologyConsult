namespace AstrologyBlog.Web.ViewModels.Articles
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseArticleInputModel
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        [MinLength(300)]
        public string Description { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "ArticlesCategory")]
        public int ArticlesCategoryId { get; set; }

        public IEnumerable<CategoryDropDowwViewModel> ArticlesCategories { get; set; }
    }
}
