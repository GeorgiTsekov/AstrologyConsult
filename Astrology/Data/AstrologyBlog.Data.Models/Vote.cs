namespace AstrologyBlog.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using AstrologyBlog.Data.Common.Models;

    public class Vote : BaseDeletableModel<int>
    {
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public VoteType Type { get; set; }
    }
}
