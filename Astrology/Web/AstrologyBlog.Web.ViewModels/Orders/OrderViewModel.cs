namespace AstrologyBlog.Web.ViewModels.Orders
{
    using System;

    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Mapping;

    public class OrderViewModel : IMapFrom<Order>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime BirthDay { get; set; }

        public string BirthTown { get; set; }

        public string Question { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
