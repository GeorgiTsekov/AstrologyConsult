namespace AstrologyBlog.Data.Models
{
    using AstrologyBlog.Data.Common.Models;

    public class Event : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public string Name { get; set; }

        public string Date { get; set; }

        public string Place { get; set; }

        public string Description { get; set; }
    }
}
