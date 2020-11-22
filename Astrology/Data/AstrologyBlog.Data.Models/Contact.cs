namespace AstrologyBlog.Data.Models
{
    using AstrologyBlog.Data.Common.Models;

    public class Contact : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public string MapAddress { get; set; }
    }
}
