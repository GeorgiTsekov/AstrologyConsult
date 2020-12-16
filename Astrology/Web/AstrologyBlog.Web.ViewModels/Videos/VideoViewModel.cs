namespace AstrologyBlog.Web.ViewModels.Videos
{
    using System;
    using System.Net;
    using System.Text.RegularExpressions;

    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Mapping;
    using Ganss.XSS;

    public class VideoViewModel : IMapFrom<Video>
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
