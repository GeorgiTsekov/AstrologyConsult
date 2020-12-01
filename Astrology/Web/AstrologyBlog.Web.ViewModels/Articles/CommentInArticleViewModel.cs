namespace AstrologyBlog.Web.ViewModels.Articles
{
    using System;

    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Mapping;
    using Ganss.XSS;

    public class CommentInArticleViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string UserUserName { get; set; }
    }
}