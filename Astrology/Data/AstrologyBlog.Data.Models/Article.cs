namespace AstrologyBlog.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AstrologyBlog.Data.Common.Models;

    public class Article : BaseDeletableModel<int>
    {
        public Article()
        {
            this.Comments = new HashSet<Comment>();
            this.Votes = new HashSet<Vote>();
            this.Images = new HashSet<Image>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string CreatedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }

        public int ArticlesCategoryId { get; set; }

        public virtual ArticlesCategory ArticlesCategory { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Vote> Votes { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
