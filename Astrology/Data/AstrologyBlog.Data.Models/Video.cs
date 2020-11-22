namespace AstrologyBlog.Data.Models
{
    using AstrologyBlog.Data.Common.Models;

    public class Video : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string VideoUrl { get; set; }

        public int ArticlesCategoryId { get; set; }

        public virtual ArticlesCategory ArticlesCategory { get; set; }
    }
}
