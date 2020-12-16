namespace AstrologyBlog.Web.ViewModels.Videos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AstrologyBlog.Web.ViewModels.Articles;

    public abstract class BaseVideoInputModel
    {
        [Required]
        [MinLength(4)]
        public string Title { get; set; }

        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        [MinLength(20)]
        public string Description { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "ArticlesCategory")]
        public int ArticlesCategoryId { get; set; }

        public IEnumerable<ArticlesCategoryDropDowwViewModel> ArticlesCategories { get; set; }
    }
}
