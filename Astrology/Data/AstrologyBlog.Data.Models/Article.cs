namespace AstrologyBlog.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AstrologyBlog.Data.Common.Models;

    public class Article : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string CreatedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
