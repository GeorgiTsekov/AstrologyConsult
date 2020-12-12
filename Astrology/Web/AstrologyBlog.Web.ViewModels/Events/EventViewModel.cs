namespace AstrologyBlog.Web.ViewModels.Events
{
    using System;

    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Mapping;

    public class EventViewModel : IMapFrom<Event>
    {
        public string Title { get; set; }

        public string Name { get; set; }

        public string Date { get; set; }

        public string Place { get; set; }

        public string Description { get; set; }
    }
}
