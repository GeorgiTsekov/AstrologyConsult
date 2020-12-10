namespace AstrologyBlog.Data.Models
{
    using System;

    using AstrologyBlog.Data.Common.Models;

    public class Order : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime BirthDay { get; set; }

        public string BirthTown { get; set; }

        public string Question { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
