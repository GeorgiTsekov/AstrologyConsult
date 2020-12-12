namespace AstrologyBlog.Data.Models
{
    using System.Collections.Generic;

    using AstrologyBlog.Data.Common.Models;

    public class ArticlesCategory : BaseDeletableModel<int>
    {
        public ArticlesCategory()
        {
            this.Articles = new HashSet<Article>();
            this.Videos = new HashSet<Video>();
        }

        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public virtual ICollection<Video> Videos { get; set; }
    }
}
