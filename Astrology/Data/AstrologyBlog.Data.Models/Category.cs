namespace AstrologyBlog.Data.Models
{
    using System.Collections.Generic;

    using AstrologyBlog.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Orders = new HashSet<Order>();
        }

        public string Title { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
