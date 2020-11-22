namespace AstrologyBlog.Web.ViewModels.Articles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;

    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Mapping;
    using AutoMapper;

    public class ArticleViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Url => $"/f/{this.Name.Replace(' ', '-')}";

        public string CreatedByUserUserName { get; set; }

        public int CategoryId { get; set; }

        public string ShortDescription
        {
            get
            {
                var description = WebUtility.HtmlDecode(Regex.Replace(this.Description, @"<[^>]+>", string.Empty));
                return description.Length > 300
                        ? description.Substring(0, 300) + "..."
                        : description;
            }
        }

        //public void CreateMapping(IProfileExpression configuration)
        //{
        //    configuration.CreateMap<Article, ArticleViewModel>()
        //        .ForMember(x => x.ImageUrl, opt =>
        //        opt.MapFrom(x =>
        //        x.ImageUrl != null ?
        //        x.ImageUrl :
        //        "/images/articles/" + x.ImageUrl + "." + x.ImageUrl));
        //}

        public IEnumerable<CommentInArticleViewModel> Comments { get; set; }
    }
}
