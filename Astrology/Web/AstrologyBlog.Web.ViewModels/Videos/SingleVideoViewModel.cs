namespace AstrologyBlog.Web.ViewModels.Videos
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Mapping;

    public class SingleVideoViewModel : IMapFrom<Video>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string VideoUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public int ArticlesCategoryId { get; set; }
    }
}
