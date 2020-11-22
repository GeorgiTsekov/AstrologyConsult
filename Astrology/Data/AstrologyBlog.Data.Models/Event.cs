namespace AstrologyBlog.Data.Models
{
    using System;

    using AstrologyBlog.Data.Common.Models;

    public class Event : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Place { get; set; }

        public DateTime DateTime { get; set; }

        public string Description { get; set; }

        public int ArticlesCategoryId { get; set; }

        public virtual ArticlesCategory ArticlesCategory { get; set; }
    }
}
