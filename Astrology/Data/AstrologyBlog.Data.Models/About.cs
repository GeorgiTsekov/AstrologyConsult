namespace AstrologyBlog.Data.Models
{
    using AstrologyBlog.Data.Common.Models;

    public class About : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public virtual Category Category { get; set; }
    }
}
