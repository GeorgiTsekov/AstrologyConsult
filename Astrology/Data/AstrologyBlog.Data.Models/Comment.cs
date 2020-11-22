namespace AstrologyBlog.Data.Models
{

    using AstrologyBlog.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }

        public int? ParentId { get; set; }

        public virtual Comment Parent { get; set; }

        public string Content { get; set; }

        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
