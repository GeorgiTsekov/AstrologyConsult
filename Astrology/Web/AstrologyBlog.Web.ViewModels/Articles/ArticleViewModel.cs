namespace AstrologyBlog.Web.ViewModels.Articles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Mapping;

    public class ArticleViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Url => $"/f/{this.Name.Replace(' ', '-')}";

        public string CreatedByUserUserName { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<CommentInArticleViewModel> Comments { get; set; }
    }
}
